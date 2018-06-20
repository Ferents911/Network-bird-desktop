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
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using OpenXNet;

namespace Network_Bird_Desktop
{
    public partial class Restoration : MaterialSkin.Controls.MaterialForm
    {
        string OutputText;
        string nameHost = Dns.GetHostName();
        string name;
        string path;
        string pass;
        public Restoration()
        {
            
            MaterialSkinManager SM = MaterialSkinManager.Instance;
            SM.AddFormToManage(this);
            SM.Theme = MaterialSkinManager.Themes.Dark;
            SM.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.BlueGrey500, Accent.Blue700, TextShade.White);
            InitializeComponent();
            MaximizeBox = false;
            MaximumSize = this.Size;
            MinimumSize = this.Size;
        }

        private void Restoration_Load(object sender, EventArgs e)
        {
            RestoreTextBox.Hint = "Enter your e-mail for restoring";
            materialDivider1.BackColor = Color.FromArgb(25, 118, 210);
            materialDivider2.BackColor = Color.FromArgb(25, 118, 210);
            if (Properties.Settings.Default.lang_selector == "ukr")
            {

                this.Text = "Відновлення";
                IpLabel.Text = "Поточна IP комп'ютера";
                HostLabel.Text = "Ім'я комп'ютера";
                RestoreTextBox.Hint = "введіть вашу електронну скриньку";
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            path = Directory.GetCurrentDirectory(); // визначаю поточний шлях розташування проекту
            using (var connection = new OleDbConnection("Provider=" + "Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + "\\Data\\data.mdb"))
            {
                connection.Open();
                OleDbCommand command_1 = connection.CreateCommand();
                OleDbCommand command_2 = connection.CreateCommand();


                command_1.CommandText = "SELECT User_pass FROM [Users] WHERE User_mail = '" + RestoreTextBox.Text + "';";
                OleDbDataReader reader_1 = command_1.ExecuteReader();
                while (reader_1.Read())
                {
                  pass = reader_1[0].ToString();

                }

                command_2.CommandText = "SELECT User_name FROM [Users] WHERE User_mail = '" + RestoreTextBox.Text + "';";
                OleDbDataReader reader_2 = command_2.ExecuteReader();

                while (reader_2.Read())
                {
                    name = reader_2[0].ToString();

                }

                if ((string.IsNullOrWhiteSpace(RestoreTextBox.Text)))
                {
                    MessageBox.Show("One or more fields is empty, please enter the data", "Network bird", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (pass == null)
                    {
                        MessageBox.Show("Mail not exist!", "Network bird", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MailSender();
                        HostLabel.Text = nameHost;
                    }
                }
                reader_1.Close();
            }
            path = "";
        }

        public void MailSender()
        {
           
            HostLabel.Text = nameHost;
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress addr in localIPs) // повторення вкладених операторів для кожного IP
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork) // якщо поточна IP адреса - IPv4...
                {
                    IpLabel.Text = addr.ToString(); // присвоєння текстовому полю значення поточної IP адреси
                }
            }
           
                OutputText ="Restoring host: " + HostLabel.Text + "\r\n" + "Restoring IP address: " + IpLabel.Text + "\r\n" + "Dear, " + name +" your password is: " + pass; // формую вихідну текстову змінну для запису в текстовий файл на основі зібраної інформації.
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"); // host
                mail.From = new MailAddress("ferents911@gmail.com"); // from
                mail.To.Add(RestoreTextBox.Text); // to
                mail.Subject = "Restoring your password";
                mail.Body = OutputText;
                SmtpServer.Port = 587; // port
                SmtpServer.Credentials = new NetworkCredential("ferents911@gmail.com", "kolyaferents619"); 
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
        }
    }
