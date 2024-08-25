namespace HealthMate_UI.Screens
{
    partial class Calories_Tracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calories_Tracker));
            this.Breakfast = new Guna.UI2.WinForms.Guna2Button();
            this.ExtraMeal = new Guna.UI2.WinForms.Guna2Button();
            this.Dinner = new Guna.UI2.WinForms.Guna2Button();
            this.Lunch = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.CalHistory = new LiveCharts.WinForms.CartesianChart();
            this.Back = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Backlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Breakfast
            // 
            this.Breakfast.Animated = true;
            this.Breakfast.BorderRadius = 15;
            this.Breakfast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Breakfast.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Breakfast.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Breakfast.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Breakfast.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Breakfast.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.Breakfast.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Breakfast.ForeColor = System.Drawing.Color.White;
            this.Breakfast.Location = new System.Drawing.Point(31, 126);
            this.Breakfast.Name = "Breakfast";
            this.Breakfast.Size = new System.Drawing.Size(113, 34);
            this.Breakfast.TabIndex = 97;
            this.Breakfast.Text = "+ Breakfast";
            this.Breakfast.Click += new System.EventHandler(this.Breakfast_Click);
            // 
            // ExtraMeal
            // 
            this.ExtraMeal.Animated = true;
            this.ExtraMeal.BorderRadius = 15;
            this.ExtraMeal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExtraMeal.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ExtraMeal.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ExtraMeal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ExtraMeal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ExtraMeal.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.ExtraMeal.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.ExtraMeal.ForeColor = System.Drawing.Color.White;
            this.ExtraMeal.Location = new System.Drawing.Point(437, 126);
            this.ExtraMeal.Name = "ExtraMeal";
            this.ExtraMeal.Size = new System.Drawing.Size(131, 34);
            this.ExtraMeal.TabIndex = 94;
            this.ExtraMeal.Text = "+ Extra meal";
            this.ExtraMeal.Click += new System.EventHandler(this.ExtraMeal_Click);
            // 
            // Dinner
            // 
            this.Dinner.Animated = true;
            this.Dinner.BorderRadius = 15;
            this.Dinner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Dinner.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Dinner.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Dinner.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Dinner.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Dinner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.Dinner.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Dinner.ForeColor = System.Drawing.Color.White;
            this.Dinner.Location = new System.Drawing.Point(307, 126);
            this.Dinner.Name = "Dinner";
            this.Dinner.Size = new System.Drawing.Size(100, 34);
            this.Dinner.TabIndex = 95;
            this.Dinner.Text = "+ Dinner";
            this.Dinner.Click += new System.EventHandler(this.Dinner_Click);
            // 
            // Lunch
            // 
            this.Lunch.Animated = true;
            this.Lunch.BorderRadius = 15;
            this.Lunch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Lunch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Lunch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Lunch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Lunch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Lunch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.Lunch.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Lunch.ForeColor = System.Drawing.Color.White;
            this.Lunch.Location = new System.Drawing.Point(176, 126);
            this.Lunch.Name = "Lunch";
            this.Lunch.Size = new System.Drawing.Size(100, 34);
            this.Lunch.TabIndex = 96;
            this.Lunch.Text = "+ Lunch";
            this.Lunch.Click += new System.EventHandler(this.Lunch_Click);
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.Image = global::HealthMate_UI.Properties.Resources.lunch;
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(176, 73);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.Size = new System.Drawing.Size(100, 52);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox4.TabIndex = 101;
            this.guna2PictureBox4.TabStop = false;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.Image = global::HealthMate_UI.Properties.Resources.dinner1;
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(307, 73);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(100, 47);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 100;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::HealthMate_UI.Properties.Resources.extra_meal;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(443, 41);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(115, 82);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 99;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::HealthMate_UI.Properties.Resources.breakfast;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(31, 38);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(113, 87);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 98;
            this.guna2PictureBox1.TabStop = false;
            // 
            // CalHistory
            // 
            this.CalHistory.BackColor = System.Drawing.Color.Transparent;
            this.CalHistory.Location = new System.Drawing.Point(12, 172);
            this.CalHistory.Name = "CalHistory";
            this.CalHistory.Size = new System.Drawing.Size(571, 218);
            this.CalHistory.TabIndex = 102;
            this.CalHistory.Text = "cartesianChart1";
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
            this.Back.TabIndex = 103;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Backlbl
            // 
            this.Backlbl.AutoSize = true;
            this.Backlbl.Location = new System.Drawing.Point(34, 12);
            this.Backlbl.Name = "Backlbl";
            this.Backlbl.Size = new System.Drawing.Size(46, 25);
            this.Backlbl.TabIndex = 104;
            this.Backlbl.Text = "Back";
            this.Backlbl.Click += new System.EventHandler(this.Back_Click);
            // 
            // Calories_Tracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 390);
            this.Controls.Add(this.Backlbl);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.CalHistory);
            this.Controls.Add(this.guna2PictureBox4);
            this.Controls.Add(this.guna2PictureBox3);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.Breakfast);
            this.Controls.Add(this.Lunch);
            this.Controls.Add(this.Dinner);
            this.Controls.Add(this.ExtraMeal);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "Calories_Tracker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HealthMate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calories_Tracker_FormClosing);
            this.Load += new System.EventHandler(this.Calories_Tracker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button Breakfast;
        private Guna.UI2.WinForms.Guna2Button ExtraMeal;
        private Guna.UI2.WinForms.Guna2Button Dinner;
        private Guna.UI2.WinForms.Guna2Button Lunch;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private LiveCharts.WinForms.CartesianChart CalHistory;
        private Guna.UI2.WinForms.Guna2CircleButton Back;
        private System.Windows.Forms.Label Backlbl;
    }
}