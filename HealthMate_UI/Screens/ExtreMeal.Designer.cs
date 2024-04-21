namespace HealthMate_UI.Screens
{
    partial class ExtraMeal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraMeal));
            this.label1 = new System.Windows.Forms.Label();
            this.ExtraMealCal = new System.Windows.Forms.TextBox();
            this.Enter = new System.Windows.Forms.Button();
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
            this.label1.TabIndex = 11;
            this.label1.Text = "How much caloris in your meal?";
            // 
            // ExtraMealCal
            // 
            this.ExtraMealCal.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.ExtraMealCal.Location = new System.Drawing.Point(91, 46);
            this.ExtraMealCal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ExtraMealCal.Name = "ExtraMealCal";
            this.ExtraMealCal.Size = new System.Drawing.Size(96, 33);
            this.ExtraMealCal.TabIndex = 10;
            // 
            // Enter
            // 
            this.Enter.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Enter.Location = new System.Drawing.Point(108, 91);
            this.Enter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(62, 33);
            this.Enter.TabIndex = 9;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // ExtraMeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 138);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExtraMealCal);
            this.Controls.Add(this.Enter);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtraMeal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Extre Meal";
            this.Load += new System.EventHandler(this.ExtreMeal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ExtraMealCal;
        private System.Windows.Forms.Button Enter;
    }
}