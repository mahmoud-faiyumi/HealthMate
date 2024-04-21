namespace HealthMate_UI
{
    partial class AgeCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgeCalc));
            this.Subtitle = new System.Windows.Forms.Label();
            this.AnotherDateBtn = new System.Windows.Forms.Button();
            this.ageLabel = new System.Windows.Forms.Label();
            this.nextBirthdayLabel = new System.Windows.Forms.Label();
            this.additionalFactsLabel = new System.Windows.Forms.Label();
            this.BirthDateDaylabel = new System.Windows.Forms.Label();
            this.LivedForlabel = new System.Windows.Forms.Label();
            this.CustomdatePicker = new System.Windows.Forms.DateTimePicker();
            this.line = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Back = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FACTStxt1 = new System.Windows.Forms.TextBox();
            this.BDAYtxt = new System.Windows.Forms.TextBox();
            this.NEXTBDtxt = new System.Windows.Forms.TextBox();
            this.AGEtxt = new System.Windows.Forms.TextBox();
            this.FACTStxt4 = new System.Windows.Forms.TextBox();
            this.FACTStxt3 = new System.Windows.Forms.TextBox();
            this.FACTStxt2 = new System.Windows.Forms.TextBox();
            this.LIVEDtxt1 = new System.Windows.Forms.TextBox();
            this.LIVEDtxt5 = new System.Windows.Forms.TextBox();
            this.LIVEDtxt4 = new System.Windows.Forms.TextBox();
            this.LIVEDtxt3 = new System.Windows.Forms.TextBox();
            this.LIVEDtxt2 = new System.Windows.Forms.TextBox();
            this.alert = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.Font = new System.Drawing.Font("El Messiri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitle.Location = new System.Drawing.Point(238, 25);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(138, 37);
            this.Subtitle.TabIndex = 4;
            this.Subtitle.Text = "HealthMate";
            // 
            // AnotherDateBtn
            // 
            this.AnotherDateBtn.Location = new System.Drawing.Point(443, 41);
            this.AnotherDateBtn.Name = "AnotherDateBtn";
            this.AnotherDateBtn.Size = new System.Drawing.Size(111, 37);
            this.AnotherDateBtn.TabIndex = 44;
            this.AnotherDateBtn.Text = "Custom date";
            this.AnotherDateBtn.UseVisualStyleBackColor = true;
            this.AnotherDateBtn.Click += new System.EventHandler(this.AnotherDateBtn_Click);
            // 
            // ageLabel
            // 
            this.ageLabel.Location = new System.Drawing.Point(22, 63);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(247, 25);
            this.ageLabel.TabIndex = 46;
            this.ageLabel.Text = "ageLabel";
            // 
            // nextBirthdayLabel
            // 
            this.nextBirthdayLabel.Location = new System.Drawing.Point(22, 132);
            this.nextBirthdayLabel.Name = "nextBirthdayLabel";
            this.nextBirthdayLabel.Size = new System.Drawing.Size(210, 25);
            this.nextBirthdayLabel.TabIndex = 47;
            this.nextBirthdayLabel.Text = "nextBirthdayLabel";
            // 
            // additionalFactsLabel
            // 
            this.additionalFactsLabel.Location = new System.Drawing.Point(21, 268);
            this.additionalFactsLabel.Name = "additionalFactsLabel";
            this.additionalFactsLabel.Size = new System.Drawing.Size(192, 25);
            this.additionalFactsLabel.TabIndex = 48;
            this.additionalFactsLabel.Text = "additionalFactsLabel";
            // 
            // BirthDateDaylabel
            // 
            this.BirthDateDaylabel.Location = new System.Drawing.Point(21, 200);
            this.BirthDateDaylabel.Name = "BirthDateDaylabel";
            this.BirthDateDaylabel.Size = new System.Drawing.Size(204, 25);
            this.BirthDateDaylabel.TabIndex = 49;
            this.BirthDateDaylabel.Text = "BirthDateDaylabel";
            // 
            // LivedForlabel
            // 
            this.LivedForlabel.Location = new System.Drawing.Point(419, 146);
            this.LivedForlabel.Name = "LivedForlabel";
            this.LivedForlabel.Size = new System.Drawing.Size(164, 25);
            this.LivedForlabel.TabIndex = 50;
            this.LivedForlabel.Text = "LivedForlabel";
            // 
            // CustomdatePicker
            // 
            this.CustomdatePicker.CustomFormat = "";
            this.CustomdatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CustomdatePicker.Location = new System.Drawing.Point(424, 84);
            this.CustomdatePicker.Name = "CustomdatePicker";
            this.CustomdatePicker.Size = new System.Drawing.Size(150, 33);
            this.CustomdatePicker.TabIndex = 51;
            this.CustomdatePicker.Value = new System.DateTime(2024, 3, 2, 0, 0, 0, 0);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.Gray;
            this.line.Location = new System.Drawing.Point(402, 127);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(10, 242);
            this.line.TabIndex = 52;
            this.line.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Back,
            this.toolStripSeparator2,
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(595, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 57;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Back
            // 
            this.Back.Image = global::HealthMate_UI.Properties.Resources.Back;
            this.Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(52, 22);
            this.Back.Text = "Back";
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // FACTStxt1
            // 
            this.FACTStxt1.Location = new System.Drawing.Point(25, 292);
            this.FACTStxt1.Name = "FACTStxt1";
            this.FACTStxt1.ReadOnly = true;
            this.FACTStxt1.Size = new System.Drawing.Size(198, 33);
            this.FACTStxt1.TabIndex = 68;
            // 
            // BDAYtxt
            // 
            this.BDAYtxt.Location = new System.Drawing.Point(25, 223);
            this.BDAYtxt.Name = "BDAYtxt";
            this.BDAYtxt.ReadOnly = true;
            this.BDAYtxt.Size = new System.Drawing.Size(161, 33);
            this.BDAYtxt.TabIndex = 69;
            // 
            // NEXTBDtxt
            // 
            this.NEXTBDtxt.Location = new System.Drawing.Point(25, 155);
            this.NEXTBDtxt.Name = "NEXTBDtxt";
            this.NEXTBDtxt.ReadOnly = true;
            this.NEXTBDtxt.Size = new System.Drawing.Size(198, 33);
            this.NEXTBDtxt.TabIndex = 70;
            // 
            // AGEtxt
            // 
            this.AGEtxt.Location = new System.Drawing.Point(25, 87);
            this.AGEtxt.Name = "AGEtxt";
            this.AGEtxt.ReadOnly = true;
            this.AGEtxt.Size = new System.Drawing.Size(236, 33);
            this.AGEtxt.TabIndex = 71;
            // 
            // FACTStxt4
            // 
            this.FACTStxt4.Location = new System.Drawing.Point(232, 331);
            this.FACTStxt4.Name = "FACTStxt4";
            this.FACTStxt4.ReadOnly = true;
            this.FACTStxt4.Size = new System.Drawing.Size(160, 33);
            this.FACTStxt4.TabIndex = 72;
            // 
            // FACTStxt3
            // 
            this.FACTStxt3.Location = new System.Drawing.Point(232, 292);
            this.FACTStxt3.Name = "FACTStxt3";
            this.FACTStxt3.ReadOnly = true;
            this.FACTStxt3.Size = new System.Drawing.Size(160, 33);
            this.FACTStxt3.TabIndex = 73;
            // 
            // FACTStxt2
            // 
            this.FACTStxt2.Location = new System.Drawing.Point(25, 331);
            this.FACTStxt2.Name = "FACTStxt2";
            this.FACTStxt2.ReadOnly = true;
            this.FACTStxt2.Size = new System.Drawing.Size(198, 33);
            this.FACTStxt2.TabIndex = 74;
            // 
            // LIVEDtxt1
            // 
            this.LIVEDtxt1.Location = new System.Drawing.Point(424, 171);
            this.LIVEDtxt1.Name = "LIVEDtxt1";
            this.LIVEDtxt1.ReadOnly = true;
            this.LIVEDtxt1.Size = new System.Drawing.Size(150, 33);
            this.LIVEDtxt1.TabIndex = 75;
            // 
            // LIVEDtxt5
            // 
            this.LIVEDtxt5.Location = new System.Drawing.Point(424, 331);
            this.LIVEDtxt5.Name = "LIVEDtxt5";
            this.LIVEDtxt5.ReadOnly = true;
            this.LIVEDtxt5.Size = new System.Drawing.Size(150, 33);
            this.LIVEDtxt5.TabIndex = 76;
            // 
            // LIVEDtxt4
            // 
            this.LIVEDtxt4.Location = new System.Drawing.Point(424, 291);
            this.LIVEDtxt4.Name = "LIVEDtxt4";
            this.LIVEDtxt4.ReadOnly = true;
            this.LIVEDtxt4.Size = new System.Drawing.Size(150, 33);
            this.LIVEDtxt4.TabIndex = 77;
            // 
            // LIVEDtxt3
            // 
            this.LIVEDtxt3.Location = new System.Drawing.Point(424, 251);
            this.LIVEDtxt3.Name = "LIVEDtxt3";
            this.LIVEDtxt3.ReadOnly = true;
            this.LIVEDtxt3.Size = new System.Drawing.Size(150, 33);
            this.LIVEDtxt3.TabIndex = 78;
            // 
            // LIVEDtxt2
            // 
            this.LIVEDtxt2.Location = new System.Drawing.Point(424, 211);
            this.LIVEDtxt2.Name = "LIVEDtxt2";
            this.LIVEDtxt2.ReadOnly = true;
            this.LIVEDtxt2.Size = new System.Drawing.Size(150, 33);
            this.LIVEDtxt2.TabIndex = 79;
            // 
            // alert
            // 
            this.alert.Font = new System.Drawing.Font("El Messiri SemiBold", 8F, System.Drawing.FontStyle.Bold);
            this.alert.Location = new System.Drawing.Point(24, 367);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(368, 13);
            this.alert.TabIndex = 80;
            this.alert.Text = "label1";
            // 
            // AgeCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 390);
            this.Controls.Add(this.alert);
            this.Controls.Add(this.LIVEDtxt2);
            this.Controls.Add(this.LIVEDtxt3);
            this.Controls.Add(this.LIVEDtxt4);
            this.Controls.Add(this.LIVEDtxt5);
            this.Controls.Add(this.LIVEDtxt1);
            this.Controls.Add(this.FACTStxt2);
            this.Controls.Add(this.FACTStxt3);
            this.Controls.Add(this.FACTStxt4);
            this.Controls.Add(this.AGEtxt);
            this.Controls.Add(this.NEXTBDtxt);
            this.Controls.Add(this.BDAYtxt);
            this.Controls.Add(this.FACTStxt1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.line);
            this.Controls.Add(this.CustomdatePicker);
            this.Controls.Add(this.LivedForlabel);
            this.Controls.Add(this.BirthDateDaylabel);
            this.Controls.Add(this.additionalFactsLabel);
            this.Controls.Add(this.nextBirthdayLabel);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.AnotherDateBtn);
            this.Controls.Add(this.Subtitle);
            this.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "AgeCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HealthMate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgeCalcEN_FormClosing);
            this.Load += new System.EventHandler(this.AgeCalcEN_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Subtitle;
        private System.Windows.Forms.Button AnotherDateBtn;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label nextBirthdayLabel;
        private System.Windows.Forms.Label additionalFactsLabel;
        private System.Windows.Forms.Label BirthDateDaylabel;
        private System.Windows.Forms.Label LivedForlabel;
        private System.Windows.Forms.DateTimePicker CustomdatePicker;
        private System.Windows.Forms.Button line;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton Back;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox FACTStxt1;
        private System.Windows.Forms.TextBox BDAYtxt;
        private System.Windows.Forms.TextBox NEXTBDtxt;
        private System.Windows.Forms.TextBox AGEtxt;
        private System.Windows.Forms.TextBox FACTStxt4;
        private System.Windows.Forms.TextBox FACTStxt3;
        private System.Windows.Forms.TextBox FACTStxt2;
        private System.Windows.Forms.TextBox LIVEDtxt1;
        private System.Windows.Forms.TextBox LIVEDtxt5;
        private System.Windows.Forms.TextBox LIVEDtxt4;
        private System.Windows.Forms.TextBox LIVEDtxt3;
        private System.Windows.Forms.TextBox LIVEDtxt2;
        private System.Windows.Forms.Label alert;
    }
}