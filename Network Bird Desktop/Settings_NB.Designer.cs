namespace Network_Bird_Desktop
{
    partial class Settings_NB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_NB));
            this.ukr_RB = new MaterialSkin.Controls.MaterialRadioButton();
            this.eng_RB = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ukr_RB
            // 
            this.ukr_RB.AutoSize = true;
            this.ukr_RB.Depth = 0;
            this.ukr_RB.Font = new System.Drawing.Font("Nazanintar", 11F);
            this.ukr_RB.Location = new System.Drawing.Point(16, 18);
            this.ukr_RB.Margin = new System.Windows.Forms.Padding(0);
            this.ukr_RB.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ukr_RB.MouseState = MaterialSkin.MouseState.Hover;
            this.ukr_RB.Name = "ukr_RB";
            this.ukr_RB.Ripple = true;
            this.ukr_RB.Size = new System.Drawing.Size(92, 30);
            this.ukr_RB.TabIndex = 1;
            this.ukr_RB.TabStop = true;
            this.ukr_RB.Text = "Ukrainian";
            this.ukr_RB.UseVisualStyleBackColor = true;
            // 
            // eng_RB
            // 
            this.eng_RB.AutoSize = true;
            this.eng_RB.Depth = 0;
            this.eng_RB.Font = new System.Drawing.Font("Nazanintar", 11F);
            this.eng_RB.Location = new System.Drawing.Point(16, 64);
            this.eng_RB.Margin = new System.Windows.Forms.Padding(0);
            this.eng_RB.MouseLocation = new System.Drawing.Point(-1, -1);
            this.eng_RB.MouseState = MaterialSkin.MouseState.Hover;
            this.eng_RB.Name = "eng_RB";
            this.eng_RB.Ripple = true;
            this.eng_RB.Size = new System.Drawing.Size(76, 30);
            this.eng_RB.TabIndex = 3;
            this.eng_RB.TabStop = true;
            this.eng_RB.Text = "English";
            this.eng_RB.UseVisualStyleBackColor = true;
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 106);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.Hover;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(364, 198);
            this.materialTabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tabPage1.Controls.Add(this.materialRaisedButton2);
            this.tabPage1.Controls.Add(this.eng_RB);
            this.tabPage1.Controls.Add(this.ukr_RB);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(356, 172);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Language";
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.materialRaisedButton2.Icon = null;
            this.materialRaisedButton2.Location = new System.Drawing.Point(258, 121);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.Hover;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(80, 33);
            this.materialRaisedButton2.TabIndex = 4;
            this.materialRaisedButton2.Text = "OK";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 64);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.Hover;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(531, 28);
            this.materialTabSelector1.TabIndex = 6;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // Settings_NB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 313);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings_NB";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_NB_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        public MaterialSkin.Controls.MaterialRadioButton ukr_RB;
        public MaterialSkin.Controls.MaterialRadioButton eng_RB;
        public MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
    }
}