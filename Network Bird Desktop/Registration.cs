using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Threading;
using System.IO;

namespace Network_Bird_Desktop
{
    public partial class Registration : MaterialSkin.Controls.MaterialForm
    {
        string log;
        string mail;
        public Registration()
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

        private void Registration_Load(object sender, EventArgs e)
        {
            RegUN.Hint = "Nickname";
            RegPass.Hint = "Password";
            RegMail.Hint = "E-mail";
            materialDivider1.BackColor = Color.FromArgb(25, 118, 210);
            if (Properties.Settings.Default.lang_selector == "ukr")
            {

                this.Text = "Реєстрація";
                materialLabel1.Text = ":Ваш нікнейм в чаті";
                materialLabel2.Text = ":Ваш пароль";
                materialLabel3.Text = ":Ваша електронна пошта";
                label1.Text = "!Реєстрація успішно завершена";
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            
            using (var connection = new OleDbConnection("Provider=" + "Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + "\\Data\\data.mdb"))
            {
                connection.Open();
                OleDbCommand command_1 = connection.CreateCommand();
                OleDbCommand command_2 = connection.CreateCommand();

                command_1.CommandText = "SELECT * FROM [Users] WHERE User_name = '" + RegUN.Text + "';";
                OleDbDataReader reader_1 = command_1.ExecuteReader();
                command_2.CommandText = "SELECT * FROM [Users] WHERE User_mail = '" + RegMail.Text + "';";
                OleDbDataReader reader_2 = command_2.ExecuteReader();
                while (reader_1.Read())
                {
                    log = reader_1[0].ToString();
                   
                }
                while (reader_2.Read())
                {
                    mail = reader_2[0].ToString();
                }
                if ((log == RegUN.Text) ||( mail == RegMail.Text))
                {
                    MessageBox.Show("User aviable", "Network bird", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    else
                    {
                        if ((string.IsNullOrWhiteSpace(RegUN.Text)) || (string.IsNullOrWhiteSpace(RegMail.Text)) || (string.IsNullOrWhiteSpace(RegPass.Text)))
                        {
                        MessageBox.Show("One or more fields is empty, please enter the data", "Network bird", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                        RegInit();
                        }
                    }
                reader_1.Close();
                reader_2.Close();
            } 
        }
        public void RegInit()
        {
            try
            {
                using (var connection = new OleDbConnection("Provider=" + "Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + "\\Data\\data.mdb"))
                {
                    connection.Open();
                    OleDbCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO [Users] (User_name, User_pass, User_mail) values ('" + RegUN.Text + "', '" + RegPass.Text + "', '" + RegMail.Text + "');";
                    command.ExecuteNonQuery();

                    connection.Close();
                }

                if ((pictureBox1.Visible == false) && (label1.Visible == false))
                {

                    animator1.ShowSync(label1);
                    animator2.ShowSync(pictureBox1);
                    animator1.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
                    animator2.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic;
                    Thread.Sleep(300);
                    animator1.HideSync(label1);
                    animator2.HideSync(pictureBox1);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
