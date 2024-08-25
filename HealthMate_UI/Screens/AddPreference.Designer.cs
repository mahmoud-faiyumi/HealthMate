namespace HealthMate_UI
{
    partial class AddPreference
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPreference));
            this.AddPreferenceBtn = new Guna.UI2.WinForms.Guna2Button();
            this.FoodList = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CategoryList = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
            // 
            // AddPreferenceBtn
            // 
            this.AddPreferenceBtn.BorderRadius = 15;
            this.AddPreferenceBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddPreferenceBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddPreferenceBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddPreferenceBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddPreferenceBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.AddPreferenceBtn.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.AddPreferenceBtn.ForeColor = System.Drawing.Color.White;
            this.AddPreferenceBtn.Location = new System.Drawing.Point(111, 135);
            this.AddPreferenceBtn.Margin = new System.Windows.Forms.Padding(5);
            this.AddPreferenceBtn.Name = "AddPreferenceBtn";
            this.AddPreferenceBtn.Size = new System.Drawing.Size(143, 36);
            this.AddPreferenceBtn.TabIndex = 35;
            this.AddPreferenceBtn.Text = "Add Preference";
            this.AddPreferenceBtn.Click += new System.EventHandler(this.btnAddPreference_Click);
            // 
            // FoodList
            // 
            this.FoodList.BackColor = System.Drawing.Color.Transparent;
            this.FoodList.BorderRadius = 15;
            this.FoodList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FoodList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FoodList.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FoodList.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FoodList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FoodList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.FoodList.ItemHeight = 25;
            this.FoodList.Location = new System.Drawing.Point(192, 51);
            this.FoodList.Margin = new System.Windows.Forms.Padding(8);
            this.FoodList.Name = "FoodList";
            this.FoodList.Size = new System.Drawing.Size(153, 31);
            this.FoodList.Sorted = true;
            this.FoodList.TabIndex = 34;
            // 
            // CategoryList
            // 
            this.CategoryList.BackColor = System.Drawing.Color.Transparent;
            this.CategoryList.BorderRadius = 15;
            this.CategoryList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CategoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryList.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryList.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CategoryList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CategoryList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CategoryList.ItemHeight = 25;
            this.CategoryList.Location = new System.Drawing.Point(17, 51);
            this.CategoryList.Margin = new System.Windows.Forms.Padding(8);
            this.CategoryList.Name = "CategoryList";
            this.CategoryList.Size = new System.Drawing.Size(153, 31);
            this.CategoryList.Sorted = true;
            this.CategoryList.TabIndex = 33;
            this.CategoryList.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);
            // 
            // AddPreference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 217);
            this.Controls.Add(this.AddPreferenceBtn);
            this.Controls.Add(this.FoodList);
            this.Controls.Add(this.CategoryList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPreference";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPreference";
            this.Load += new System.EventHandler(this.AddPreference_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button AddPreferenceBtn;
        private Guna.UI2.WinForms.Guna2ComboBox FoodList;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryList;
    }
}