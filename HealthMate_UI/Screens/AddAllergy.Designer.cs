namespace HealthMate_UI
{
    partial class AddAllergy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAllergy));
            this.FoodList = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CategoryList = new Guna.UI2.WinForms.Guna2ComboBox();
            this.AddAllergyBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
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
            this.FoodList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.FoodList.Name = "FoodList";
            this.FoodList.Size = new System.Drawing.Size(153, 31);
            this.FoodList.Sorted = true;
            this.FoodList.TabIndex = 30;
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
            this.CategoryList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CategoryList.Name = "CategoryList";
            this.CategoryList.Size = new System.Drawing.Size(153, 31);
            this.CategoryList.Sorted = true;
            this.CategoryList.TabIndex = 29;
            this.CategoryList.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);
            // 
            // AddAllergyBtn
            // 
            this.AddAllergyBtn.BorderRadius = 15;
            this.AddAllergyBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AddAllergyBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AddAllergyBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AddAllergyBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AddAllergyBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(73)))), ((int)(((byte)(255)))));
            this.AddAllergyBtn.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.AddAllergyBtn.ForeColor = System.Drawing.Color.White;
            this.AddAllergyBtn.Location = new System.Drawing.Point(123, 135);
            this.AddAllergyBtn.Name = "AddAllergyBtn";
            this.AddAllergyBtn.Size = new System.Drawing.Size(118, 36);
            this.AddAllergyBtn.TabIndex = 32;
            this.AddAllergyBtn.Text = "Add Allergy";
            // 
            // AddAllergy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 217);
            this.Controls.Add(this.AddAllergyBtn);
            this.Controls.Add(this.FoodList);
            this.Controls.Add(this.CategoryList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAllergy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Allergy";
            this.Load += new System.EventHandler(this.AddAllergy_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox FoodList;
        private Guna.UI2.WinForms.Guna2ComboBox CategoryList;
        private Guna.UI2.WinForms.Guna2Button AddAllergyBtn;
    }
}