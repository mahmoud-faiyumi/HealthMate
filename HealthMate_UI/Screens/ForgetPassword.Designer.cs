namespace HealthMate_UI.Screens
{
    partial class ForgetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPassword));
            this.Email = new Guna.UI2.WinForms.Guna2TextBox();
            this.SendResetEmailBtn = new Guna.UI2.WinForms.Guna2Button();
            this.PINcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResetPasswordBtn = new Guna.UI2.WinForms.Guna2Button();
            this.NoInternet = new Guna.UI2.WinForms.Guna2Button();
            this.CountDown = new System.Windows.Forms.Label();
            this.Backlbl = new System.Windows.Forms.Label();
            this.Back = new Guna.UI2.WinForms.Guna2CircleButton();
            this.SuspendLayout();
            // 
            // Email
            // 
            this.Email.Animated = true;
            this.Email.BorderRadius = 15;
            this.Email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Email.DefaultText = "Enter your email";
            this.Email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Email.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Email.ForeColor = System.Drawing.Color.Black;
            this.Email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Email.Location = new System.Drawing.Point(159, 38);
            this.Email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Email.Name = "Email";
            this.Email.PasswordChar = '\0';
            this.Email.PlaceholderText = "";
            this.Email.SelectedText = "";
            this.Email.Size = new System.Drawing.Size(204, 32);
            this.Email.TabIndex = 4;
            this.Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Email.Enter += new System.EventHandler(this.Email_Enter);
            this.Email.Leave += new System.EventHandler(this.Email_Leave);
            // 
            // SendResetEmailBtn
            // 
            this.SendResetEmailBtn.Animated = true;
            this.SendResetEmailBtn.BorderRadius = 10;
            this.SendResetEmailBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendResetEmailBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SendResetEmailBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SendResetEmailBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SendResetEmailBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SendResetEmailBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.SendResetEmailBtn.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.SendResetEmailBtn.ForeColor = System.Drawing.Color.White;
            this.SendResetEmailBtn.Location = new System.Drawing.Point(173, 77);
            this.SendResetEmailBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendResetEmailBtn.Name = "SendResetEmailBtn";
            this.SendResetEmailBtn.Size = new System.Drawing.Size(181, 24);
            this.SendResetEmailBtn.TabIndex = 9;
            this.SendResetEmailBtn.Text = "Send code via email";
            this.SendResetEmailBtn.Click += new System.EventHandler(this.SendResetLinkButton_Click);
            // 
            // PINcode
            // 
            this.PINcode.Animated = true;
            this.PINcode.BorderRadius = 10;
            this.PINcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PINcode.DefaultText = "Enter PIN Code";
            this.PINcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PINcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PINcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PINcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PINcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PINcode.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.PINcode.ForeColor = System.Drawing.Color.Black;
            this.PINcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PINcode.Location = new System.Drawing.Point(191, 205);
            this.PINcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PINcode.Name = "PINcode";
            this.PINcode.PasswordChar = '\0';
            this.PINcode.PlaceholderText = "";
            this.PINcode.SelectedText = "";
            this.PINcode.Size = new System.Drawing.Size(152, 31);
            this.PINcode.TabIndex = 91;
            this.PINcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PINcode.Enter += new System.EventHandler(this.PINcode_Enter);
            this.PINcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PINcode_KeyPress);
            this.PINcode.Leave += new System.EventHandler(this.PINcode_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 52);
            this.label1.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(495, 22);
            this.label2.TabIndex = 93;
            // 
            // ResetPasswordBtn
            // 
            this.ResetPasswordBtn.Animated = true;
            this.ResetPasswordBtn.BorderRadius = 10;
            this.ResetPasswordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetPasswordBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ResetPasswordBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ResetPasswordBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ResetPasswordBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ResetPasswordBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.ResetPasswordBtn.Font = new System.Drawing.Font("El Messiri SemiBold", 8F, System.Drawing.FontStyle.Bold);
            this.ResetPasswordBtn.ForeColor = System.Drawing.Color.White;
            this.ResetPasswordBtn.Location = new System.Drawing.Point(350, 207);
            this.ResetPasswordBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetPasswordBtn.Name = "ResetPasswordBtn";
            this.ResetPasswordBtn.Size = new System.Drawing.Size(107, 26);
            this.ResetPasswordBtn.TabIndex = 94;
            this.ResetPasswordBtn.Text = "Reset Password";
            this.ResetPasswordBtn.Click += new System.EventHandler(this.ResetPasswordBtn_Click);
            // 
            // NoInternet
            // 
            this.NoInternet.Animated = true;
            this.NoInternet.BorderRadius = 10;
            this.NoInternet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NoInternet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.NoInternet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.NoInternet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.NoInternet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.NoInternet.FillColor = System.Drawing.Color.Red;
            this.NoInternet.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.NoInternet.ForeColor = System.Drawing.Color.White;
            this.NoInternet.Location = new System.Drawing.Point(173, 5);
            this.NoInternet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NoInternet.Name = "NoInternet";
            this.NoInternet.Size = new System.Drawing.Size(181, 26);
            this.NoInternet.TabIndex = 95;
            this.NoInternet.Text = "لا يوجد اتصال بالانترنت";
            // 
            // CountDown
            // 
            this.CountDown.AutoSize = true;
            this.CountDown.Location = new System.Drawing.Point(100, 207);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(0, 25);
            this.CountDown.TabIndex = 97;
            // 
            // Backlbl
            // 
            this.Backlbl.AutoSize = true;
            this.Backlbl.Location = new System.Drawing.Point(34, 12);
            this.Backlbl.Name = "Backlbl";
            this.Backlbl.Size = new System.Drawing.Size(46, 25);
            this.Backlbl.TabIndex = 107;
            this.Backlbl.Text = "Back";
            this.Backlbl.Click += new System.EventHandler(this.Back_Click);
            // 
            // Back
            // 
            this.Back.Animated = true;
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Back.FillColor = System.Drawing.Color.Transparent;
            this.Back.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Back.ForeColor = System.Drawing.Color.Transparent;
            this.Back.Image = global::HealthMate_UI.Properties.Resources.Back;
            this.Back.ImageSize = new System.Drawing.Size(30, 30);
            this.Back.Location = new System.Drawing.Point(7, 7);
            this.Back.Name = "Back";
            this.Back.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Back.Size = new System.Drawing.Size(35, 35);
            this.Back.TabIndex = 106;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // ForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(519, 262);
            this.Controls.Add(this.Backlbl);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.CountDown);
            this.Controls.Add(this.NoInternet);
            this.Controls.Add(this.ResetPasswordBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PINcode);
            this.Controls.Add(this.SendResetEmailBtn);
            this.Controls.Add(this.Email);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "ForgetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HealthMate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ForgetPassword_FormClosing);
            this.Load += new System.EventHandler(this.ForgetPasword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox Email;
        private Guna.UI2.WinForms.Guna2Button SendResetEmailBtn;
        private Guna.UI2.WinForms.Guna2TextBox PINcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button ResetPasswordBtn;
        private Guna.UI2.WinForms.Guna2Button NoInternet;
        private System.Windows.Forms.Label CountDown;
        private System.Windows.Forms.Label Backlbl;
        private Guna.UI2.WinForms.Guna2CircleButton Back;
    }
}