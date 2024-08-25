namespace HealthMate_UI.Screens
{
    partial class ResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassword));
            this.PasswordVisibilityRE = new Guna.UI2.WinForms.Guna2Button();
            this.RePassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.PasswordVisibility = new Guna.UI2.WinForms.Guna2Button();
            this.Password = new Guna.UI2.WinForms.Guna2TextBox();
            this.UpdateUsrInfo = new Guna.UI2.WinForms.Guna2Button();
            this.PasswordStrengthLabel = new System.Windows.Forms.Label();
            this.PasswordMatchLabel = new System.Windows.Forms.Label();
            this.RePassLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PasswordVisibilityRE
            // 
            this.PasswordVisibilityRE.Animated = true;
            this.PasswordVisibilityRE.BackColor = System.Drawing.Color.Transparent;
            this.PasswordVisibilityRE.BorderRadius = 5;
            this.PasswordVisibilityRE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PasswordVisibilityRE.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.PasswordVisibilityRE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.PasswordVisibilityRE.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.PasswordVisibilityRE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.PasswordVisibilityRE.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.PasswordVisibilityRE.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.PasswordVisibilityRE.ForeColor = System.Drawing.Color.Transparent;
            this.PasswordVisibilityRE.Image = global::HealthMate_UI.Properties.Resources.hide_eye;
            this.PasswordVisibilityRE.ImageSize = new System.Drawing.Size(28, 28);
            this.PasswordVisibilityRE.Location = new System.Drawing.Point(269, 130);
            this.PasswordVisibilityRE.Name = "PasswordVisibilityRE";
            this.PasswordVisibilityRE.Size = new System.Drawing.Size(33, 33);
            this.PasswordVisibilityRE.TabIndex = 103;
            this.PasswordVisibilityRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PasswordVisibilityRE.Click += new System.EventHandler(this.PasswordVisibilityREBtn_Click);
            // 
            // RePassword
            // 
            this.RePassword.BorderRadius = 15;
            this.RePassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RePassword.DefaultText = "";
            this.RePassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.RePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.RePassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.RePassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.RePassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RePassword.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.RePassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RePassword.Location = new System.Drawing.Point(98, 130);
            this.RePassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RePassword.Name = "RePassword";
            this.RePassword.PasswordChar = '\0';
            this.RePassword.PlaceholderText = "";
            this.RePassword.SelectedText = "";
            this.RePassword.Size = new System.Drawing.Size(204, 33);
            this.RePassword.TabIndex = 105;
            this.RePassword.TextChanged += new System.EventHandler(this.RePassword_TextChanged);
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
            this.PasswordVisibility.ForeColor = System.Drawing.Color.Transparent;
            this.PasswordVisibility.Image = global::HealthMate_UI.Properties.Resources.hide_eye;
            this.PasswordVisibility.ImageSize = new System.Drawing.Size(28, 28);
            this.PasswordVisibility.Location = new System.Drawing.Point(269, 43);
            this.PasswordVisibility.Name = "PasswordVisibility";
            this.PasswordVisibility.Size = new System.Drawing.Size(33, 33);
            this.PasswordVisibility.TabIndex = 102;
            this.PasswordVisibility.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PasswordVisibility.Click += new System.EventHandler(this.PasswordVisibilityBtn_Click);
            // 
            // Password
            // 
            this.Password.BorderRadius = 15;
            this.Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password.DefaultText = "";
            this.Password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Password.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Password.Location = new System.Drawing.Point(98, 43);
            this.Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '\0';
            this.Password.PlaceholderText = "";
            this.Password.SelectedText = "";
            this.Password.Size = new System.Drawing.Size(204, 33);
            this.Password.TabIndex = 104;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // UpdateUsrInfo
            // 
            this.UpdateUsrInfo.Animated = true;
            this.UpdateUsrInfo.BorderRadius = 15;
            this.UpdateUsrInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateUsrInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.UpdateUsrInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.UpdateUsrInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.UpdateUsrInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.UpdateUsrInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.UpdateUsrInfo.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.UpdateUsrInfo.ForeColor = System.Drawing.Color.White;
            this.UpdateUsrInfo.Location = new System.Drawing.Point(122, 201);
            this.UpdateUsrInfo.Name = "UpdateUsrInfo";
            this.UpdateUsrInfo.Size = new System.Drawing.Size(156, 33);
            this.UpdateUsrInfo.TabIndex = 101;
            this.UpdateUsrInfo.Text = "Update Password";
            this.UpdateUsrInfo.Click += new System.EventHandler(this.UpdateUsrInfo_Click);
            // 
            // PasswordStrengthLabel
            // 
            this.PasswordStrengthLabel.AutoSize = true;
            this.PasswordStrengthLabel.Font = new System.Drawing.Font("El Messiri", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordStrengthLabel.ForeColor = System.Drawing.Color.Black;
            this.PasswordStrengthLabel.Location = new System.Drawing.Point(95, 81);
            this.PasswordStrengthLabel.Name = "PasswordStrengthLabel";
            this.PasswordStrengthLabel.Size = new System.Drawing.Size(0, 17);
            this.PasswordStrengthLabel.TabIndex = 100;
            // 
            // PasswordMatchLabel
            // 
            this.PasswordMatchLabel.AutoSize = true;
            this.PasswordMatchLabel.Font = new System.Drawing.Font("El Messiri", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordMatchLabel.ForeColor = System.Drawing.Color.Red;
            this.PasswordMatchLabel.Location = new System.Drawing.Point(95, 168);
            this.PasswordMatchLabel.Name = "PasswordMatchLabel";
            this.PasswordMatchLabel.Size = new System.Drawing.Size(0, 17);
            this.PasswordMatchLabel.TabIndex = 99;
            // 
            // RePassLabel
            // 
            this.RePassLabel.AutoSize = true;
            this.RePassLabel.Location = new System.Drawing.Point(124, 102);
            this.RePassLabel.Name = "RePassLabel";
            this.RePassLabel.Size = new System.Drawing.Size(152, 25);
            this.RePassLabel.TabIndex = 98;
            this.RePassLabel.Text = "Re-Enter Password:";
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Location = new System.Drawing.Point(141, 13);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(119, 25);
            this.PassLabel.TabIndex = 97;
            this.PassLabel.Text = "New Password:";
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 257);
            this.Controls.Add(this.PasswordVisibilityRE);
            this.Controls.Add(this.RePassword);
            this.Controls.Add(this.PasswordVisibility);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UpdateUsrInfo);
            this.Controls.Add(this.PasswordStrengthLabel);
            this.Controls.Add(this.PasswordMatchLabel);
            this.Controls.Add(this.RePassLabel);
            this.Controls.Add(this.PassLabel);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HealthMate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResetPassword_FormClosing);
            this.Load += new System.EventHandler(this.ResetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button PasswordVisibilityRE;
        private Guna.UI2.WinForms.Guna2TextBox RePassword;
        private Guna.UI2.WinForms.Guna2Button PasswordVisibility;
        private Guna.UI2.WinForms.Guna2TextBox Password;
        private Guna.UI2.WinForms.Guna2Button UpdateUsrInfo;
        private System.Windows.Forms.Label PasswordStrengthLabel;
        private System.Windows.Forms.Label PasswordMatchLabel;
        private System.Windows.Forms.Label RePassLabel;
        private System.Windows.Forms.Label PassLabel;
    }
}