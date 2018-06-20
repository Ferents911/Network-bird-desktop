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

namespace Network_Bird_Desktop
{
    public partial class Settings_NB : MaterialSkin.Controls.MaterialForm
    {
        public Settings_NB()
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

        private void Settings_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.lang_selector == "ukr")
            {
                
                this.Text = "Налаштування";
                tabPage1.Text = "Мова";
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            if (ukr_RB.Checked == true)
            {
                Properties.Settings.Default.curent_lang = ukr_RB.Checked;
                Properties.Settings.Default.lang_selector = "ukr";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.curent_lang = eng_RB.Checked;
                Properties.Settings.Default.lang_selector = "eng";
                Properties.Settings.Default.Save();
            }
            this.Close();
        }

        private void Settings_NB_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}

