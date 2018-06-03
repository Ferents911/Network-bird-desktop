namespace Network_Bird_Desktop
{
    partial class Restoration
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
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.RestoreTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.HostLabel = new System.Windows.Forms.Label();
            this.IpLabel = new System.Windows.Forms.Label();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.SuspendLayout();
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(255, 192);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.Hover;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(88, 30);
            this.materialRaisedButton1.TabIndex = 0;
            this.materialRaisedButton1.Text = "Restore";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // RestoreTextBox
            // 
            this.RestoreTextBox.Depth = 0;
            this.RestoreTextBox.EnterToTab = false;
            this.RestoreTextBox.Hint = "";
            this.RestoreTextBox.Location = new System.Drawing.Point(75, 101);
            this.RestoreTextBox.MaxLength = 32767;
            this.RestoreTextBox.MouseState = MaterialSkin.MouseState.Hover;
            this.RestoreTextBox.Name = "RestoreTextBox";
            this.RestoreTextBox.PasswordChar = '\0';
            this.RestoreTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RestoreTextBox.SelectedText = "";
            this.RestoreTextBox.SelectionLength = 0;
            this.RestoreTextBox.SelectionStart = 0;
            this.RestoreTextBox.Size = new System.Drawing.Size(268, 30);
            this.RestoreTextBox.TabIndex = 1;
            this.RestoreTextBox.TabStop = false;
            this.RestoreTextBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.RestoreTextBox.UseSystemPasswordChar = false;
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HostLabel.Location = new System.Drawing.Point(59, 278);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(20, 23);
            this.HostLabel.TabIndex = 2;
            this.HostLabel.Text = "1";
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IpLabel.Location = new System.Drawing.Point(59, 327);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(20, 23);
            this.IpLabel.TabIndex = 3;
            this.IpLabel.Text = "1";
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.Silver;
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(50, 252);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.Hover;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(350, 2);
            this.materialDivider1.TabIndex = 4;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.Silver;
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(50, 367);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.Hover;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(350, 2);
            this.materialDivider2.TabIndex = 5;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // Restoration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.materialDivider2);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.HostLabel);
            this.Controls.Add(this.RestoreTextBox);
            this.Controls.Add(this.materialRaisedButton1);
            this.Name = "Restoration";
            this.Text = "Restoration";
            this.Load += new System.EventHandler(this.Restoration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialSingleLineTextField RestoreTextBox;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.Label IpLabel;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
    }
}