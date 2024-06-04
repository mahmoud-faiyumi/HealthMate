namespace HealthMate_UI.Screens
{
    partial class Dinner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dinner));
            this.label1 = new System.Windows.Forms.Label();
            this.DinnerCal = new Guna.UI2.WinForms.Guna2TextBox();
            this.Enterbtn = new Guna.UI2.WinForms.Guna2Button();
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
            this.label1.TabIndex = 8;
            this.label1.Text = "How much caloris in your meal?";
            // 
            // DinnerCal
            // 
            this.DinnerCal.BorderRadius = 15;
            this.DinnerCal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DinnerCal.DefaultText = "";
            this.DinnerCal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.DinnerCal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.DinnerCal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.DinnerCal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.DinnerCal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DinnerCal.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.DinnerCal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DinnerCal.Location = new System.Drawing.Point(91, 44);
            this.DinnerCal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DinnerCal.Name = "DinnerCal";
            this.DinnerCal.PasswordChar = '\0';
            this.DinnerCal.PlaceholderText = "";
            this.DinnerCal.SelectedText = "";
            this.DinnerCal.Size = new System.Drawing.Size(96, 36);
            this.DinnerCal.TabIndex = 15;
            this.DinnerCal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DinnerCal_KeyDown);
            // 
            // Enterbtn
            // 
            this.Enterbtn.BorderRadius = 15;
            this.Enterbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Enterbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Enterbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Enterbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Enterbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.Enterbtn.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Enterbtn.ForeColor = System.Drawing.Color.White;
            this.Enterbtn.Location = new System.Drawing.Point(100, 89);
            this.Enterbtn.Name = "Enterbtn";
            this.Enterbtn.Size = new System.Drawing.Size(79, 33);
            this.Enterbtn.TabIndex = 14;
            this.Enterbtn.Text = "Enter";
            this.Enterbtn.Click += new System.EventHandler(this.Enter_Click);
            // 
            // Dinner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 138);
            this.Controls.Add(this.DinnerCal);
            this.Controls.Add(this.Enterbtn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dinner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Dinner";
            this.Load += new System.EventHandler(this.Dinner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox DinnerCal;
        private Guna.UI2.WinForms.Guna2Button Enterbtn;
    }
}