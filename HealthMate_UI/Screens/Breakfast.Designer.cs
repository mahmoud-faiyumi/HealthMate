namespace HealthMate_UI.Screens
{
    partial class Breakfast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Breakfast));
            this.label1 = new System.Windows.Forms.Label();
            this.BrkFstCal = new Guna.UI2.WinForms.Guna2TextBox();
            this.Enter = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "How much caloris in your meal?";
            // 
            // BrkFstCal
            // 
            this.BrkFstCal.BorderRadius = 15;
            this.BrkFstCal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BrkFstCal.DefaultText = "";
            this.BrkFstCal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BrkFstCal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BrkFstCal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BrkFstCal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BrkFstCal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BrkFstCal.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.BrkFstCal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BrkFstCal.Location = new System.Drawing.Point(91, 44);
            this.BrkFstCal.Name = "BrkFstCal";
            this.BrkFstCal.PasswordChar = '\0';
            this.BrkFstCal.PlaceholderText = "";
            this.BrkFstCal.SelectedText = "";
            this.BrkFstCal.Size = new System.Drawing.Size(96, 36);
            this.BrkFstCal.TabIndex = 17;
            // 
            // Enter
            // 
            this.Enter.BorderRadius = 15;
            this.Enter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Enter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Enter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Enter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Enter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.Enter.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Enter.ForeColor = System.Drawing.Color.White;
            this.Enter.Location = new System.Drawing.Point(100, 89);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(79, 33);
            this.Enter.TabIndex = 16;
            this.Enter.Text = "Enter";
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // Breakfast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 138);
            this.Controls.Add(this.BrkFstCal);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Breakfast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Breakfast";
            this.Load += new System.EventHandler(this.Breakfast_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox BrkFstCal;
        private Guna.UI2.WinForms.Guna2Button Enter;
    }
}