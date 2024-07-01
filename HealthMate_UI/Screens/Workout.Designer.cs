namespace HealthMate_UI.Screens
{
    partial class Workout
    {
        private System.Windows.Forms.TabPage tabPageBeginner;
        private System.Windows.Forms.TabPage tabPageIntermediate;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.Label lblExerciseName;
        private System.Windows.Forms.PictureBox picExerciseGif;
        private System.Windows.Forms.Label lblTimer;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabPage tabBeginner;
        private System.Windows.Forms.TabPage tabIntermediate;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.ColumnHeader columnExerciseName;
        private System.Windows.Forms.ColumnHeader columnDuration;
        private System.Windows.Forms.Button btnStartWorkout;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Workout));
            this.tabPageBeginner = new System.Windows.Forms.TabPage();
            this.tabPageIntermediate = new System.Windows.Forms.TabPage();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.lblExerciseName = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.LevelTab = new Guna.UI2.WinForms.Guna2TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SkipRestlbl = new System.Windows.Forms.Label();
            this.BtnSkipRest = new Guna.UI2.WinForms.Guna2Button();
            this.BackBtn = new Guna.UI2.WinForms.Guna2Button();
            this.btnOpenYouTube = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextExercise = new Guna.UI2.WinForms.Guna2Button();
            this.btnPauseTimer = new Guna.UI2.WinForms.Guna2Button();
            this.picExerciseGif = new System.Windows.Forms.PictureBox();
            this.Setting = new Guna.UI2.WinForms.Guna2Button();
            this.RestTB = new Guna.UI2.WinForms.Guna2TrackBar();
            this.Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MuscleGroupTab = new Guna.UI2.WinForms.Guna2TabControl();
            this.LevelTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExerciseGif)).BeginInit();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageBeginner
            // 
            this.tabPageBeginner.Location = new System.Drawing.Point(4, 44);
            this.tabPageBeginner.Name = "tabPageBeginner";
            this.tabPageBeginner.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBeginner.Size = new System.Drawing.Size(593, 0);
            this.tabPageBeginner.TabIndex = 0;
            this.tabPageBeginner.Text = "Beginner";
            this.tabPageBeginner.UseVisualStyleBackColor = true;
            // 
            // tabPageIntermediate
            // 
            this.tabPageIntermediate.Location = new System.Drawing.Point(4, 44);
            this.tabPageIntermediate.Name = "tabPageIntermediate";
            this.tabPageIntermediate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIntermediate.Size = new System.Drawing.Size(593, 0);
            this.tabPageIntermediate.TabIndex = 1;
            this.tabPageIntermediate.Text = "Intermediate";
            this.tabPageIntermediate.UseVisualStyleBackColor = true;
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 44);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Size = new System.Drawing.Size(593, 0);
            this.tabPageAdvanced.TabIndex = 2;
            this.tabPageAdvanced.Text = "Advanced";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // lblExerciseName
            // 
            this.lblExerciseName.AutoSize = true;
            this.lblExerciseName.Font = new System.Drawing.Font("El Messiri SemiBold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.lblExerciseName.Location = new System.Drawing.Point(400, 47);
            this.lblExerciseName.Name = "lblExerciseName";
            this.lblExerciseName.Size = new System.Drawing.Size(93, 20);
            this.lblExerciseName.TabIndex = 2;
            this.lblExerciseName.Text = "Exercise Name";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(408, 269);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(33, 13);
            this.lblTimer.TabIndex = 4;
            this.lblTimer.Text = "Timer";
            // 
            // LevelTab
            // 
            this.LevelTab.Controls.Add(this.tabPageBeginner);
            this.LevelTab.Controls.Add(this.tabPageIntermediate);
            this.LevelTab.Controls.Add(this.tabPageAdvanced);
            this.LevelTab.ItemSize = new System.Drawing.Size(110, 40);
            this.LevelTab.Location = new System.Drawing.Point(42, 0);
            this.LevelTab.Name = "LevelTab";
            this.LevelTab.SelectedIndex = 0;
            this.LevelTab.Size = new System.Drawing.Size(601, 40);
            this.LevelTab.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.LevelTab.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.LevelTab.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.LevelTab.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.LevelTab.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.LevelTab.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.LevelTab.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.LevelTab.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.LevelTab.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.LevelTab.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.LevelTab.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.LevelTab.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.LevelTab.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.LevelTab.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.LevelTab.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.LevelTab.TabButtonSize = new System.Drawing.Size(110, 40);
            this.LevelTab.TabIndex = 8;
            this.LevelTab.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.LevelTab.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("El Messiri SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(408, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "Next";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("El Messiri SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(578, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 101;
            this.label2.Text = "Youtube";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("El Messiri SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(491, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 102;
            this.label3.Text = "Start";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SkipRestlbl
            // 
            this.SkipRestlbl.BackColor = System.Drawing.Color.Transparent;
            this.SkipRestlbl.Font = new System.Drawing.Font("El Messiri SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkipRestlbl.Location = new System.Drawing.Point(534, 269);
            this.SkipRestlbl.Name = "SkipRestlbl";
            this.SkipRestlbl.Size = new System.Drawing.Size(66, 20);
            this.SkipRestlbl.TabIndex = 106;
            this.SkipRestlbl.Text = "Skip rest";
            this.SkipRestlbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnSkipRest
            // 
            this.BtnSkipRest.Animated = true;
            this.BtnSkipRest.BackColor = System.Drawing.Color.Transparent;
            this.BtnSkipRest.BorderRadius = 10;
            this.BtnSkipRest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSkipRest.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnSkipRest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnSkipRest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnSkipRest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnSkipRest.FillColor = System.Drawing.Color.Transparent;
            this.BtnSkipRest.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSkipRest.ForeColor = System.Drawing.Color.White;
            this.BtnSkipRest.Image = global::HealthMate_UI.Properties.Resources.Skip;
            this.BtnSkipRest.ImageSize = new System.Drawing.Size(30, 30);
            this.BtnSkipRest.Location = new System.Drawing.Point(504, 260);
            this.BtnSkipRest.Name = "BtnSkipRest";
            this.BtnSkipRest.Size = new System.Drawing.Size(30, 33);
            this.BtnSkipRest.TabIndex = 105;
            this.BtnSkipRest.Click += new System.EventHandler(this.BtnSkipRest_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BackBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BackBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BackBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BackBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.BackBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackBtn.ForeColor = System.Drawing.Color.White;
            this.BackBtn.Image = global::HealthMate_UI.Properties.Resources.WBack;
            this.BackBtn.ImageSize = new System.Drawing.Size(27, 27);
            this.BackBtn.Location = new System.Drawing.Point(0, 0);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(42, 40);
            this.BackBtn.TabIndex = 103;
            this.BackBtn.Click += new System.EventHandler(this.Back_Click);
            // 
            // btnOpenYouTube
            // 
            this.btnOpenYouTube.Animated = true;
            this.btnOpenYouTube.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenYouTube.BorderRadius = 10;
            this.btnOpenYouTube.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenYouTube.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenYouTube.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOpenYouTube.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOpenYouTube.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOpenYouTube.FillColor = System.Drawing.Color.Transparent;
            this.btnOpenYouTube.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenYouTube.ForeColor = System.Drawing.Color.White;
            this.btnOpenYouTube.Image = global::HealthMate_UI.Properties.Resources.youtube;
            this.btnOpenYouTube.ImageSize = new System.Drawing.Size(40, 40);
            this.btnOpenYouTube.Location = new System.Drawing.Point(584, 309);
            this.btnOpenYouTube.Name = "btnOpenYouTube";
            this.btnOpenYouTube.Size = new System.Drawing.Size(46, 33);
            this.btnOpenYouTube.TabIndex = 99;
            this.btnOpenYouTube.Click += new System.EventHandler(this.btnOpenYouTube_Click);
            // 
            // btnNextExercise
            // 
            this.btnNextExercise.Animated = true;
            this.btnNextExercise.BackColor = System.Drawing.Color.Transparent;
            this.btnNextExercise.BorderRadius = 10;
            this.btnNextExercise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextExercise.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextExercise.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextExercise.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextExercise.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextExercise.FillColor = System.Drawing.Color.Transparent;
            this.btnNextExercise.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNextExercise.ForeColor = System.Drawing.Color.White;
            this.btnNextExercise.Image = global::HealthMate_UI.Properties.Resources.next;
            this.btnNextExercise.ImageSize = new System.Drawing.Size(30, 30);
            this.btnNextExercise.Location = new System.Drawing.Point(411, 309);
            this.btnNextExercise.Name = "btnNextExercise";
            this.btnNextExercise.Size = new System.Drawing.Size(33, 33);
            this.btnNextExercise.TabIndex = 98;
            this.btnNextExercise.Click += new System.EventHandler(this.btnNextExercise_Click);
            // 
            // btnPauseTimer
            // 
            this.btnPauseTimer.Animated = true;
            this.btnPauseTimer.BackColor = System.Drawing.Color.Transparent;
            this.btnPauseTimer.BorderRadius = 10;
            this.btnPauseTimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPauseTimer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPauseTimer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPauseTimer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPauseTimer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPauseTimer.FillColor = System.Drawing.Color.Transparent;
            this.btnPauseTimer.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.btnPauseTimer.ForeColor = System.Drawing.Color.White;
            this.btnPauseTimer.Image = global::HealthMate_UI.Properties.Resources.play;
            this.btnPauseTimer.ImageSize = new System.Drawing.Size(30, 30);
            this.btnPauseTimer.Location = new System.Drawing.Point(504, 309);
            this.btnPauseTimer.Name = "btnPauseTimer";
            this.btnPauseTimer.Size = new System.Drawing.Size(30, 33);
            this.btnPauseTimer.TabIndex = 97;
            this.btnPauseTimer.Click += new System.EventHandler(this.btnPauseTimer_Click);
            // 
            // picExerciseGif
            // 
            this.picExerciseGif.Location = new System.Drawing.Point(423, 70);
            this.picExerciseGif.Name = "picExerciseGif";
            this.picExerciseGif.Size = new System.Drawing.Size(231, 178);
            this.picExerciseGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExerciseGif.TabIndex = 3;
            this.picExerciseGif.TabStop = false;
            // 
            // Setting
            // 
            this.Setting.Animated = true;
            this.Setting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.Setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Setting.BorderColor = System.Drawing.Color.Transparent;
            this.Setting.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.Setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Setting.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Setting.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Setting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Setting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Setting.FillColor = System.Drawing.Color.Transparent;
            this.Setting.Font = new System.Drawing.Font("El Messiri SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.Setting.ForeColor = System.Drawing.Color.Transparent;
            this.Setting.Image = global::HealthMate_UI.Properties.Resources.settings;
            this.Setting.ImageSize = new System.Drawing.Size(30, 30);
            this.Setting.Location = new System.Drawing.Point(607, 3);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(30, 33);
            this.Setting.TabIndex = 107;
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            // 
            // RestTB
            // 
            this.RestTB.Location = new System.Drawing.Point(11, 30);
            this.RestTB.Maximum = 60;
            this.RestTB.MouseWheelBarPartitions = 5;
            this.RestTB.Name = "RestTB";
            this.RestTB.Size = new System.Drawing.Size(207, 23);
            this.RestTB.TabIndex = 108;
            this.RestTB.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.RestTB.Value = 20;
            this.RestTB.Visible = false;
            this.RestTB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.RestTB_Scroll);
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.LightGray;
            this.Panel.Controls.Add(this.label4);
            this.Panel.Controls.Add(this.label5);
            this.Panel.Controls.Add(this.RestTB);
            this.Panel.Location = new System.Drawing.Point(411, 40);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(232, 88);
            this.Panel.TabIndex = 109;
            this.Panel.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("El Messiri SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 110;
            this.label4.Text = "Skip rest";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("El Messiri SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 111;
            this.label5.Text = "Custom Rest Time:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // MuscleGroupTab
            // 
            this.MuscleGroupTab.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.MuscleGroupTab.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MuscleGroupTab.ItemSize = new System.Drawing.Size(80, 40);
            this.MuscleGroupTab.Location = new System.Drawing.Point(0, 40);
            this.MuscleGroupTab.Name = "MuscleGroupTab";
            this.MuscleGroupTab.SelectedIndex = 0;
            this.MuscleGroupTab.Size = new System.Drawing.Size(383, 329);
            this.MuscleGroupTab.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.MuscleGroupTab.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.MuscleGroupTab.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.MuscleGroupTab.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.MuscleGroupTab.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.MuscleGroupTab.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.MuscleGroupTab.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.MuscleGroupTab.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.MuscleGroupTab.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.MuscleGroupTab.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.MuscleGroupTab.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.MuscleGroupTab.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.MuscleGroupTab.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.MuscleGroupTab.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.MuscleGroupTab.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.MuscleGroupTab.TabButtonSize = new System.Drawing.Size(80, 40);
            this.MuscleGroupTab.TabButtonTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.MuscleGroupTab.TabIndex = 104;
            this.MuscleGroupTab.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // Workout
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(641, 369);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.SkipRestlbl);
            this.Controls.Add(this.BtnSkipRest);
            this.Controls.Add(this.MuscleGroupTab);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenYouTube);
            this.Controls.Add(this.btnNextExercise);
            this.Controls.Add(this.btnPauseTimer);
            this.Controls.Add(this.LevelTab);
            this.Controls.Add(this.lblExerciseName);
            this.Controls.Add(this.picExerciseGif);
            this.Controls.Add(this.lblTimer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Workout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workout";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Workout_FormClosing);
            this.Load += new System.EventHandler(this.Workout_Load);
            this.LevelTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExerciseGif)).EndInit();
            this.Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Guna.UI2.WinForms.Guna2TabControl LevelTab;
        private Guna.UI2.WinForms.Guna2Button btnPauseTimer;
        private Guna.UI2.WinForms.Guna2Button btnNextExercise;
        private Guna.UI2.WinForms.Guna2Button btnOpenYouTube;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button BackBtn;
        private Guna.UI2.WinForms.Guna2Button BtnSkipRest;
        private System.Windows.Forms.Label SkipRestlbl;
        private Guna.UI2.WinForms.Guna2Button Setting;
        private Guna.UI2.WinForms.Guna2TrackBar RestTB;
        private Guna.UI2.WinForms.Guna2Panel Panel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TabControl MuscleGroupTab;
    }

    #endregion

    }
