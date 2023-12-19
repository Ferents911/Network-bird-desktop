using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Net;
using System.Net.Sockets;
using System.Data.OleDb;
using System.IO;
using Network_Bird_Desktop.Properties;

namespace Network_Bird_Desktop
{


    public partial class NBmain : MaterialSkin.Controls.MaterialForm
    {
        private Settings_NB sett;
        private Restoration res;
        private Registration reg;
        private About ab;
        public string log;
        string pass;
        Image img1 = Image.FromFile(@"D:\coding\projects\С#\Windows\Network Bird Desktop\Network Bird Desktop\Resources\white_settings.png");
        bool alive = false; // будет ли работать поток для приема
        UdpClient client;
        const int LOCALPORT = 8001; // порт для приема сообщений
        const int REMOTEPORT = 8001; // порт для отправки сообщений
        const int TTL = 20;
        const string HOST = "235.5.5.1"; // хост для групповой рассылки
        IPAddress groupAddress; // адрес для групповой рассылки

        string userName;

        public NBmain()
        {
            MaterialSkinManager SM = MaterialSkinManager.Instance;
            SM.AddFormToManage(this);
            SM.Theme = MaterialSkinManager.Themes.Dark;
            SM.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.BlueGrey500, Accent.Blue700, TextShade.White);
            InitializeComponent();
            MaximizeBox = false;
            MaximumSize = this.Size;
            MinimumSize = this.Size;
            loginButton.Enabled = true; // кнопка входа
            logoutButton.Enabled = false; // кнопка выхода
            sendButton.Enabled = false; // кнопка отправки
            chatTextBox.ReadOnly = true; // поле для сообщений
            groupAddress = IPAddress.Parse(HOST);

        }
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);

                    // добавляем полученное сообщение в текстовое поле
                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.Text = time + " " + message + "\r\n" + chatTextBox.Text;
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            ExitChat();
         
        }
        private void ExitChat()
        {
            string message = userName + " leave from chat";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, HOST, REMOTEPORT);
            client.DropMulticastGroup(groupAddress);

            alive = false;
            client.Close();

            loginButton.Enabled = true;
            bunifuFlatButton3.Enabled = false;
            sendButton.Enabled = false;
           
        }

        private void NBmain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (alive)
                ExitChat();
            Application.Exit();
        }

        public void loginButton_Click_1(object sender, EventArgs e)
        {
            if (materialCheckBox1.Checked == true)
            {
              
                Properties.Settings.Default.chk = "+";
                Properties.Settings.Default.log = userNameTextBox.Text;
                Properties.Settings.Default.pass = PasswordTextBox.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
               
                Properties.Settings.Default.lang_selector = "-";
                Properties.Settings.Default.Save();
            }


            using (var connection = new OleDbConnection("Provider=" + "Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + "\\Data\\data.mdb"))
            {
                connection.Open();
                OleDbCommand command_1 = connection.CreateCommand();
                OleDbCommand command_2 = connection.CreateCommand();

                command_1.CommandText = "SELECT * FROM [Users] WHERE User_name = '" + userNameTextBox.Text + "';";
                OleDbDataReader reader_1 = command_1.ExecuteReader();
                command_2.CommandText = "SELECT * FROM [Users] WHERE User_pass = '" + PasswordTextBox.Text + "';";
                OleDbDataReader reader_2 = command_2.ExecuteReader();
                while (reader_1.Read())
                {
                    log = reader_1[0].ToString();

                }
                while (reader_2.Read())
                {
                    pass = reader_2[0].ToString();
                }
                if ((string.IsNullOrWhiteSpace(PasswordTextBox.Text)) || (string.IsNullOrWhiteSpace(userNameTextBox.Text)))
                {
                    MessageBox.Show("One or more fields is empty, please enter the data", "Network bird", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((pass == null) || (log == null))
                    {
                        MessageBox.Show("Incorect login or password ", "Network bird", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Enter();
                    }
                }
                reader_1.Close();
                reader_2.Close();
            }

        }

        public void Enter()
        {
            bunifuFlatButton3.Enabled = true;
            userName = userNameTextBox.Text;
            userNameTextBox.Enabled = false;
            try
            {
                client = new UdpClient(LOCALPORT);
                client.JoinMulticastGroup(groupAddress, TTL);
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();
                string message = userName + " join";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendButton_Click_1(object sender, EventArgs e)
        {
           
            
        }

        private void NBmain_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.chk == "+")
            {
              userNameTextBox.Text = Properties.Settings.Default.log;
              PasswordTextBox.Text = Properties.Settings.Default.pass;
            }
            
            bunifuFlatButton3.Enabled = false;
            materialDivider1.BackColor = Color.FromArgb(25, 118, 210);
            materialDivider2.BackColor = Color.FromArgb(25, 118, 210);
            chatTextBox.Cursor = null;
            userNameTextBox.Hint = "Nickname";
            PasswordTextBox.Hint = "Password";
            if (Properties.Settings.Default.lang_selector == "ukr")
            {
                materialCheckBox1.Text = "Запам'ятати мене";
                loginButton.Text = "Вхід";
                label1.Text = "?Забули ваш пароль";
                label2.Text = "!Зареєструватись зараз";
                label2.Location = new Point(73, 293);
                bunifuFlatButton1.ButtonText = "      Налаштування";
                bunifuFlatButton2.ButtonText = "     Про програму";
                bunifuFlatButton3.ButtonText = "         Вийти";
                userNameTextBox.Hint = "введіть Ваш логін";
                PasswordTextBox.Hint = "пароль Ваш пароль";
               
            }
           

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ExitChat();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 283)
            {
                panel1.Visible = false;
                panel1.Width = 50;
                chatTextBox.Location = new Point(51, 65);
                messageTextBox.Location = new Point(51, 498);   
                messageTextBox.Width = 720;
                chatTextBox.Width = 797;
                animator1.ShowSync(panel1);
            }
            else
            {
                panel1.Visible = false;
                panel1.Width = 283;
                chatTextBox.Location = new Point(284, 65);
                messageTextBox.Location = new Point(284, 498);
                messageTextBox.Width = 488;
                chatTextBox.Width = 564;
                animator1.ShowSync(panel1);
            }
        }

        private void chatTextBox_MouseHover(object sender, EventArgs e)
        {
 
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Settings_NB set = new Settings_NB();
            set.Show();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_MouseHover(object sender, EventArgs e)
        {
           
        }


        private void bunifuFlatButton1_Click_2(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Settings_NB>().Count() == 1)
                Application.OpenForms.OfType<Settings_NB>().First().Close();

            Settings_NB frm = new Settings_NB();
             frm.Show();

        }

 


        private void materialLabel2_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<Registration>().Count() == 1)
                Application.OpenForms.OfType<Registration>().First().Close();
            Registration reg = new Registration();
            reg.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bunifuFlatButton3.Enabled = true;
            ExitChat();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Restoration>().Count() == 1)
                Application.OpenForms.OfType<Restoration>().First().Close();
            Restoration res = new Restoration();
            res.Show();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName, messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton2_Click_2(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<About>().Count() == 1)
                Application.OpenForms.OfType<About>().First().Close();
            About ab = new About();
            ab.Show();
        }

        private void materialLabel1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(25, 118, 210);
            label2.ForeColor = Color.FromArgb(25, 118, 210);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Restoration>().Count() == 1)
                Application.OpenForms.OfType<Restoration>().First().Close();
            Restoration res = new Restoration();
            res.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Registration>().Count() == 1)
                Application.OpenForms.OfType<Registration>().First().Close();
            Registration reg = new Registration();
            reg.Show();
        }
    }
 }
