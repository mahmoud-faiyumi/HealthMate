namespace HealthMate_UI.Screens
{
    partial class DietPlaner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DietPlaner));
            this.AddPreference = new Guna.UI2.WinForms.Guna2Button();
            this.AddAllergy = new Guna.UI2.WinForms.Guna2Button();
            this.listBoxDietPlan = new System.Windows.Forms.ListBox();
            this.SuggestDiet = new Guna.UI2.WinForms.Guna2Button();
            this.MealPreferences = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Backlbl = new System.Windows.Forms.Label();
            this.Back = new Guna.UI2.WinForms.Guna2CircleButton();
            this.NoOfMeals = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddPreference
            // 
            this.AddPreference.BorderRadius = 15;
            this.AddPreference.DefaultAutoSize = true;
            this.AddPreference.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddPreference.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddPreference.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddPreference.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddPreference.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.AddPreference.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.AddPreference.ForeColor = System.Drawing.Color.White;
            this.AddPreference.Location = new System.Drawing.Point(13, 105);
            this.AddPreference.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddPreference.Name = "AddPreference";
            this.AddPreference.Size = new System.Drawing.Size(142, 37);
            this.AddPreference.TabIndex = 0;
            this.AddPreference.Text = "Add Preference";
            this.AddPreference.Click += new System.EventHandler(this.btnAddPreference_Click);
            // 
            // AddAllergy
            // 
            this.AddAllergy.BorderRadius = 15;
            this.AddAllergy.DefaultAutoSize = true;
            this.AddAllergy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddAllergy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddAllergy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddAllergy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddAllergy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.AddAllergy.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.AddAllergy.ForeColor = System.Drawing.Color.White;
            this.AddAllergy.Location = new System.Drawing.Point(13, 56);
            this.AddAllergy.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddAllergy.Name = "AddAllergy";
            this.AddAllergy.Size = new System.Drawing.Size(114, 37);
            this.AddAllergy.TabIndex = 1;
            this.AddAllergy.Text = "Add Allergy";
            this.AddAllergy.Click += new System.EventHandler(this.btnAddAllergy_Click);
            // 
            // listBoxDietPlan
            // 
            this.listBoxDietPlan.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.listBoxDietPlan.FormattingEnabled = true;
            this.listBoxDietPlan.ItemHeight = 20;
            this.listBoxDietPlan.Location = new System.Drawing.Point(282, 17);
            this.listBoxDietPlan.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.listBoxDietPlan.Name = "listBoxDietPlan";
            this.listBoxDietPlan.Size = new System.Drawing.Size(266, 224);
            this.listBoxDietPlan.TabIndex = 2;
            // 
            // SuggestDiet
            // 
            this.SuggestDiet.BorderRadius = 15;
            this.SuggestDiet.DefaultAutoSize = true;
            this.SuggestDiet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SuggestDiet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SuggestDiet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SuggestDiet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SuggestDiet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.SuggestDiet.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.SuggestDiet.ForeColor = System.Drawing.Color.White;
            this.SuggestDiet.Location = new System.Drawing.Point(132, 210);
            this.SuggestDiet.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SuggestDiet.Name = "SuggestDiet";
            this.SuggestDiet.Size = new System.Drawing.Size(122, 37);
            this.SuggestDiet.TabIndex = 3;
            this.SuggestDiet.Text = "Suggest Diet";
            this.SuggestDiet.Click += new System.EventHandler(this.btnSuggestDiet_Click);
            // 
            // MealPreferences
            // 
            this.MealPreferences.BackColor = System.Drawing.Color.Transparent;
            this.MealPreferences.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MealPreferences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MealPreferences.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MealPreferences.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MealPreferences.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.MealPreferences.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.MealPreferences.ItemHeight = 30;
            this.MealPreferences.Location = new System.Drawing.Point(12, 210);
            this.MealPreferences.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MealPreferences.Name = "MealPreferences";
            this.MealPreferences.Size = new System.Drawing.Size(112, 36);
            this.MealPreferences.TabIndex = 4;
            // 
            // Backlbl
            // 
            this.Backlbl.AutoSize = true;
            this.Backlbl.Location = new System.Drawing.Point(39, 17);
            this.Backlbl.Name = "Backlbl";
            this.Backlbl.Size = new System.Drawing.Size(46, 25);
            this.Backlbl.TabIndex = 109;
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
            this.Back.Location = new System.Drawing.Point(12, 12);
            this.Back.Name = "Back";
            this.Back.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Back.Size = new System.Drawing.Size(35, 35);
            this.Back.TabIndex = 108;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // NoOfMeals
            // 
            this.NoOfMeals.AutoSize = true;
            this.NoOfMeals.Location = new System.Drawing.Point(12, 179);
            this.NoOfMeals.Name = "NoOfMeals";
            this.NoOfMeals.Size = new System.Drawing.Size(50, 25);
            this.NoOfMeals.TabIndex = 110;
            this.NoOfMeals.Text = "label1";
            // 
            // DietPlaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(570, 261);
            this.Controls.Add(this.NoOfMeals);
            this.Controls.Add(this.Backlbl);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.MealPreferences);
            this.Controls.Add(this.SuggestDiet);
            this.Controls.Add(this.listBoxDietPlan);
            this.Controls.Add(this.AddAllergy);
            this.Controls.Add(this.AddPreference);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "DietPlaner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HealthMate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DietPlaner_FormClosing);
            this.Load += new System.EventHandler(this.DietPlaner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button AddPreference;
        private Guna.UI2.WinForms.Guna2Button AddAllergy;
        private System.Windows.Forms.ListBox listBoxDietPlan;
        private Guna.UI2.WinForms.Guna2Button SuggestDiet;
        private Guna.UI2.WinForms.Guna2ComboBox MealPreferences;
        private System.Windows.Forms.Label Backlbl;
        private Guna.UI2.WinForms.Guna2CircleButton Back;
        private System.Windows.Forms.Label NoOfMeals;
    }
}