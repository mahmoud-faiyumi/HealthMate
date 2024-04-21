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
            this.LunchCal = new System.Windows.Forms.TextBox();
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
            this.label1.TabIndex = 5;
            this.label1.Text = "How much caloris in your meal?";
            // 
            // LunchCal
            // 
            this.LunchCal.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.LunchCal.Location = new System.Drawing.Point(91, 46);
            this.LunchCal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LunchCal.Name = "LunchCal";
            this.LunchCal.Size = new System.Drawing.Size(96, 33);
            this.LunchCal.TabIndex = 4;
            // 
            // Enter
            // 
            this.Enter.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Enter.Location = new System.Drawing.Point(108, 91);
            this.Enter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(62, 33);
            this.Enter.TabIndex = 3;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // Lunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 138);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LunchCal);
            this.Controls.Add(this.Enter);
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
        private System.Windows.Forms.TextBox LunchCal;
        private System.Windows.Forms.Button Enter;
    }
}