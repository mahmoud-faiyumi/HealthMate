namespace HealthMate_UI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Subtitle = new System.Windows.Forms.Label();
            this.UserNameLable = new System.Windows.Forms.Label();
            this.PasswordLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Username = new Guna.UI2.WinForms.Guna2TextBox();
            this.Password = new Guna.UI2.WinForms.Guna2TextBox();
            this.LoginButton = new Guna.UI2.WinForms.Guna2Button();
            this.CreateAccbtn = new Guna.UI2.WinForms.Guna2Button();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Themes = new System.Windows.Forms.ToolStripDropDownButton();
            this.lightThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            this.arabicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.About = new System.Windows.Forms.ToolStripButton();
            this.PasswordVisibility = new Guna.UI2.WinForms.Guna2Button();
            this.ResetPassword = new Guna.UI2.WinForms.Guna2Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.Font = new System.Drawing.Font("El Messiri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitle.Location = new System.Drawing.Point(238, 33);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(138, 37);
            this.Subtitle.TabIndex = 3;
            this.Subtitle.Text = "HealthMate";
            // 
            // UserNameLable
            // 
            this.UserNameLable.AutoSize = true;
            this.UserNameLable.Location = new System.Drawing.Point(52, 99);
            this.UserNameLable.Name = "UserNameLable";
            this.UserNameLable.Size = new System.Drawing.Size(87, 25);
            this.UserNameLable.TabIndex = 1;
            this.UserNameLable.Text = "Username:";
            // 
            // PasswordLable
            // 
            this.PasswordLable.AutoSize = true;
            this.PasswordLable.Location = new System.Drawing.Point(346, 99);
            this.PasswordLable.Name = "PasswordLable";
            this.PasswordLable.Size = new System.Drawing.Size(84, 25);
            this.PasswordLable.TabIndex = 2;
            this.PasswordLable.Text = "Password:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(197, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "If you do not have an account";
            // 
            // Username
            // 
            this.Username.Animated = true;
            this.Username.BorderRadius = 15;
            this.Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Username.DefaultText = "";
            this.Username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Username.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Username.ForeColor = System.Drawing.Color.Black;
            this.Username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Username.Location = new System.Drawing.Point(57, 127);
            this.Username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Username.Name = "Username";
            this.Username.PasswordChar = '\0';
            this.Username.PlaceholderText = "";
            this.Username.SelectedText = "";
            this.Username.Size = new System.Drawing.Size(204, 33);
            this.Username.TabIndex = 1;
            this.Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsernameTextBox_KeyDown);
            // 
            // Password
            // 
            this.Password.Animated = true;
            this.Password.BorderRadius = 15;
            this.Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password.DefaultText = "";
            this.Password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Password.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Password.ForeColor = System.Drawing.Color.Black;
            this.Password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Password.Location = new System.Drawing.Point(351, 127);
            this.Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '\0';
            this.Password.PlaceholderText = "";
            this.Password.SelectedText = "";
            this.Password.Size = new System.Drawing.Size(204, 33);
            this.Password.TabIndex = 2;
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextBox_KeyDown);
            // 
            // LoginButton
            // 
            this.LoginButton.Animated = true;
            this.LoginButton.BorderRadius = 15;
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LoginButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LoginButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LoginButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LoginButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.LoginButton.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(263, 220);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(84, 35);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Login";
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // CreateAccbtn
            // 
            this.CreateAccbtn.Animated = true;
            this.CreateAccbtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            this.CreateAccbtn.BorderRadius = 15;
            this.CreateAccbtn.BorderThickness = 1;
            this.CreateAccbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateAccbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CreateAccbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CreateAccbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CreateAccbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CreateAccbtn.FillColor = System.Drawing.Color.White;
            this.CreateAccbtn.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.CreateAccbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CreateAccbtn.Location = new System.Drawing.Point(229, 322);
            this.CreateAccbtn.Name = "CreateAccbtn";
            this.CreateAccbtn.Size = new System.Drawing.Size(162, 37);
            this.CreateAccbtn.TabIndex = 20;
            this.CreateAccbtn.Text = "Create an account";
            this.CreateAccbtn.Click += new System.EventHandler(this.CreateAccbtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Themes,
            this.SelectLanguage,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.About});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(595, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Themes
            // 
            this.Themes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightThemeToolStripMenuItem,
            this.darkThemeToolStripMenuItem});
            this.Themes.Image = global::HealthMate_UI.Properties.Resources.Light;
            this.Themes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Themes.Name = "Themes";
            this.Themes.Size = new System.Drawing.Size(77, 22);
            this.Themes.Text = "Themes";
            this.Themes.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Themes_DropDownItemClicked);
            // 
            // lightThemeToolStripMenuItem
            // 
            this.lightThemeToolStripMenuItem.Name = "lightThemeToolStripMenuItem";
            this.lightThemeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.lightThemeToolStripMenuItem.Text = "Light Theme";
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.darkThemeToolStripMenuItem.Text = "Dark Theme";
            // 
            // SelectLanguage
            // 
            this.SelectLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arabicToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.SelectLanguage.Image = global::HealthMate_UI.Properties.Resources.EN;
            this.SelectLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectLanguage.Name = "SelectLanguage";
            this.SelectLanguage.Size = new System.Drawing.Size(88, 22);
            this.SelectLanguage.Text = "Language";
            this.SelectLanguage.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SelectLanguage_DropDownItemClicked);
            // 
            // arabicToolStripMenuItem
            // 
            this.arabicToolStripMenuItem.Name = "arabicToolStripMenuItem";
            this.arabicToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.arabicToolStripMenuItem.Text = "العربية";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // About
            // 
            this.About.Image = global::HealthMate_UI.Properties.Resources.info;
            this.About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(60, 22);
            this.About.Text = "About";
            // 
            // PasswordVisibility
            // 
            this.PasswordVisibility.Animated = true;
            this.PasswordVisibility.BackColor = System.Drawing.Color.Transparent;
            this.PasswordVisibility.BorderRadius = 5;
            this.PasswordVisibility.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PasswordVisibility.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.PasswordVisibility.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.PasswordVisibility.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.PasswordVisibility.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.PasswordVisibility.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.PasswordVisibility.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.PasswordVisibility.ForeColor = System.Drawing.Color.Black;
            this.PasswordVisibility.Image = global::HealthMate_UI.Properties.Resources.hide_eye;
            this.PasswordVisibility.ImageSize = new System.Drawing.Size(28, 28);
            this.PasswordVisibility.Location = new System.Drawing.Point(522, 127);
            this.PasswordVisibility.Name = "PasswordVisibility";
            this.PasswordVisibility.Size = new System.Drawing.Size(33, 33);
            this.PasswordVisibility.TabIndex = 18;
            this.PasswordVisibility.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PasswordVisibility.Click += new System.EventHandler(this.PasswordVisibility_Click);
            // 
            // ResetPassword
            // 
            this.ResetPassword.Animated = true;
            this.ResetPassword.BorderRadius = 8;
            this.ResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ResetPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ResetPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ResetPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ResetPassword.FillColor = System.Drawing.Color.Red;
            this.ResetPassword.Font = new System.Drawing.Font("El Messiri SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPassword.ForeColor = System.Drawing.Color.White;
            this.ResetPassword.Location = new System.Drawing.Point(244, 261);
            this.ResetPassword.Name = "ResetPassword";
            this.ResetPassword.Size = new System.Drawing.Size(125, 25);
            this.ResetPassword.TabIndex = 21;
            this.ResetPassword.Text = "Forget password?";
            this.ResetPassword.Click += new System.EventHandler(this.ResetPassword_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 380);
            this.Controls.Add(this.ResetPassword);
            this.Controls.Add(this.CreateAccbtn);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordVisibility);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Subtitle);
            this.Controls.Add(this.PasswordLable);
            this.Controls.Add(this.UserNameLable);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HealthMate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginEN_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Subtitle;
        private System.Windows.Forms.Label UserNameLable;
        private System.Windows.Forms.Label PasswordLable;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox Username;
        private Guna.UI2.WinForms.Guna2TextBox Password;
        private Guna.UI2.WinForms.Guna2Button PasswordVisibility;
        private Guna.UI2.WinForms.Guna2Button LoginButton;
        private Guna.UI2.WinForms.Guna2Button CreateAccbtn;
        private System.Windows.Forms.ToolStripDropDownButton Themes;
        private System.Windows.Forms.ToolStripMenuItem lightThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton SelectLanguage;
        private System.Windows.Forms.ToolStripMenuItem arabicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton About;
        private Guna.UI2.WinForms.Guna2Button ResetPassword;
    }
}

