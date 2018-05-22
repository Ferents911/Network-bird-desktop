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

namespace Network_Bird_Desktop
{
    

    public partial class NBmain : MaterialSkin.Controls.MaterialForm
    {
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
            string message = userName + " leaves chat";
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

            bunifuFlatButton3.Enabled = true;
            userName = userNameTextBox.Text;
            userNameTextBox.Enabled = false;

            try
            {
                client = new UdpClient(LOCALPORT);
                // присоединяемся к групповой рассылке
                client.JoinMulticastGroup(groupAddress, TTL);

                // запускаем задачу на прием сообщений
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();

                // отправляем первое сообщение о входе нового пользователя
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

        private void NBmain_Load(object sender, EventArgs e)
        {
            bunifuFlatButton3.Enabled = false;
            materialDivider1.BackColor = Color.FromArgb(25, 118, 210);
            materialDivider2.BackColor = Color.FromArgb(25, 118, 210);
            chatTextBox.Cursor = null;
            userNameTextBox.Hint = "Nickname";
            PasswordTextBox.Hint = "Password";
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
            Settings set = new Settings();
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
            Settings set = new Settings();
            set.Show();
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bunifuFlatButton3.Enabled = false;
            ExitChat();
        }
    }
    }
