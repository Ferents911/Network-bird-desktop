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
    public partial class About : MaterialSkin.Controls.MaterialForm
    {
        public About()
        {
            MaterialSkinManager SM = MaterialSkinManager.Instance;
            SM.AddFormToManage(this);
            SM.Theme = MaterialSkinManager.Themes.Dark;
            SM.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.BlueGrey500, Accent.Blue700, TextShade.White);
            InitializeComponent();
            MaximizeBox = false;
            MaximumSize = this.Size;
            MinimumSize = this.Size;
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(25, 118, 210);
            if (Properties.Settings.Default.lang_selector == "ukr")
            {
                this.Text = "Про програму";
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
