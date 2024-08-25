namespace HealthMate_UI.Screens
{
    partial class Lunch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lunch));
            this.label1 = new System.Windows.Forms.Label();
            this.Enterbtn = new Guna.UI2.WinForms.Guna2Button();
            this.LunchCal = new Guna.UI2.WinForms.Guna2TextBox();
            this.CategoryList = new Guna.UI2.WinForms.Guna2ComboBox();
            this.FoodList = new Guna.UI2.WinForms.Guna2ComboBox();
            this.portion = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckBox2 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(103, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "How much caloris in your meal?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Enterbtn.Location = new System.Drawing.Point(182, 126);
            this.Enterbtn.Name = "Enterbtn";
            this.Enterbtn.Size = new System.Drawing.Size(79, 33);
            this.Enterbtn.TabIndex = 6;
            this.Enterbtn.Text = "Enter";
            this.Enterbtn.Click += new System.EventHandler(this.Enter_Click);
            // 
            // LunchCal
            // 
            this.LunchCal.BorderRadius = 15;
            this.LunchCal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LunchCal.DefaultText = "";
            this.LunchCal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.LunchCal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.LunchCal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.LunchCal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.LunchCal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LunchCal.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.LunchCal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LunchCal.Location = new System.Drawing.Point(173, 88);
            this.LunchCal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LunchCal.Name = "LunchCal";
            this.LunchCal.PasswordChar = '\0';
            this.LunchCal.PlaceholderText = "";
            this.LunchCal.SelectedText = "";
            this.LunchCal.Size = new System.Drawing.Size(96, 30);
            this.LunchCal.TabIndex = 7;
            this.LunchCal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LunchCal_KeyDown);
            // 
            // CategoryList
            // 
            this.CategoryList.BackColor = System.Drawing.Color.Transparent;
            this.CategoryList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CategoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryList.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryList.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CategoryList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CategoryList.ItemHeight = 25;
            this.CategoryList.Location = new System.Drawing.Point(12, 209);
            this.CategoryList.Name = "CategoryList";
            this.CategoryList.Size = new System.Drawing.Size(124, 31);
            this.CategoryList.Sorted = true;
            this.CategoryList.TabIndex = 8;
            this.CategoryList.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);
            // 
            // FoodList
            // 
            this.FoodList.BackColor = System.Drawing.Color.Transparent;
            this.FoodList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FoodList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FoodList.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FoodList.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FoodList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FoodList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.FoodList.ItemHeight = 25;
            this.FoodList.Location = new System.Drawing.Point(148, 209);
            this.FoodList.Name = "FoodList";
            this.FoodList.Size = new System.Drawing.Size(167, 31);
            this.FoodList.Sorted = true;
            this.FoodList.TabIndex = 9;
            // 
            // portion
            // 
            this.portion.BorderRadius = 15;
            this.portion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.portion.DefaultText = "";
            this.portion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.portion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.portion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.portion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.portion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.portion.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.portion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.portion.Location = new System.Drawing.Point(327, 209);
            this.portion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portion.Name = "portion";
            this.portion.PasswordChar = '\0';
            this.portion.PlaceholderText = "";
            this.portion.SelectedText = "";
            this.portion.Size = new System.Drawing.Size(96, 31);
            this.portion.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("El Messiri SemiBold", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(17, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "او أدخل طعامك";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("El Messiri SemiBold", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(17, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "ادخل عدد السعرات";
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CheckBox2.CheckedState.BorderRadius = 0;
            this.CheckBox2.CheckedState.BorderThickness = 0;
            this.CheckBox2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CheckBox2.Location = new System.Drawing.Point(2, 162);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(15, 14);
            this.CheckBox2.TabIndex = 14;
            this.CheckBox2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CheckBox2.UncheckedState.BorderRadius = 0;
            this.CheckBox2.UncheckedState.BorderThickness = 0;
            this.CheckBox2.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CheckBox1.CheckedState.BorderRadius = 0;
            this.CheckBox1.CheckedState.BorderThickness = 0;
            this.CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CheckBox1.Location = new System.Drawing.Point(2, 49);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(15, 14);
            this.CheckBox1.TabIndex = 15;
            this.CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CheckBox1.UncheckedState.BorderRadius = 0;
            this.CheckBox1.UncheckedState.BorderThickness = 0;
            this.CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(109, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "عدد سعراتك";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "عدد سعراتك";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(148, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "عدد سعراتك";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(326, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "عدد سعراتك";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 270);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.CheckBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portion);
            this.Controls.Add(this.FoodList);
            this.Controls.Add(this.CategoryList);
            this.Controls.Add(this.LunchCal);
            this.Controls.Add(this.Enterbtn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Lunch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Lunch";
            this.Load += new System.EventHandler(this.Lunch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button Enterbtn;
        private Guna.UI2.WinForms.Guna2TextBox LunchCal;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryList;
        private Guna.UI2.WinForms.Guna2ComboBox FoodList;
        private Guna.UI2.WinForms.Guna2TextBox portion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2CheckBox CheckBox2;
        private Guna.UI2.WinForms.Guna2CheckBox CheckBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}