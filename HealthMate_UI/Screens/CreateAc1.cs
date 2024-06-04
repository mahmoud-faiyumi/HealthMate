using HealthMate_UI.Constants;
using HealthMate_UI.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HealthMate_UI
{
    public partial class CreateAc1 : Form
    {
        bool[] fieldEditedFlags = new bool[7]; // Create an array of boolean flags to track whether each field has been edited

        public CreateAc1()
        {
            InitializeComponent();
            progressBar1.Maximum = 11;

            for (byte i = 0; i < fieldEditedFlags.Length; i++)
            {
                fieldEditedFlags[i] = false; // Initialize all flags to false
            }

            UpdateNextBtnState();
        }

        private void CreateAc1_Load(object sender, EventArgs e)
        {
            if (CommonValues.CurrentUserInfo.IsDark == true)
            {
                ApplyDarkTheme();
            }
            else
            {
                ApplyLightTheme();
            }
            if (CommonValues.CurrentUserInfo.IsArabic == true)
            {
                ArabicLanguage();
            }
            else
            {
                EnglishLanguage();
            }
            label1.Text = "0%";
        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            string fname = Fname.Text;
            string lname = Lname.Text;
            string email = Email.Text;
            string username = Username.Text;
            string gender = Translator.TranslateGender(Gender.Text);
            string activityLevel = Translator.TranslateActivityLevel(ActivityLevel.Text);
            DateTime birthdate = Birthdate.Value;

            this.Hide();
            CreateAc2 createAc2EN = new CreateAc2(fname, lname, email, username, gender, birthdate, activityLevel);
            createAc2EN.Show();
        }

        private void CreateAc1EN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Fname_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Fname.Text) && !fieldEditedFlags[0])
            {
                progressBar1.Value++;
                fieldEditedFlags[0] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateNextBtnState();
        }

        private void Lname_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Lname.Text) && !fieldEditedFlags[1])
            {
                progressBar1.Value++;
                fieldEditedFlags[1] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateNextBtnState();
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Email.Text) && !fieldEditedFlags[2])
            {
                progressBar1.Value++;
                fieldEditedFlags[2] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateNextBtnState();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Username.Text) && !fieldEditedFlags[3])
            {
                progressBar1.Value++;
                fieldEditedFlags[3] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateNextBtnState();
        }

        private void Gender_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Gender.Text) && !fieldEditedFlags[4])
            {
                progressBar1.Value++;
                fieldEditedFlags[4] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateNextBtnState();
        }

        private void ActivityLevel_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ActivityLevel.Text) && !fieldEditedFlags[5])
            {
                progressBar1.Value++;
                fieldEditedFlags[5] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateNextBtnState();
        }

        private void Birthdate_ValueChanged(object sender, EventArgs e)
        {
            if (Birthdate.Value != DateTime.Today && !fieldEditedFlags[6])
            {
                progressBar1.Value++;
                fieldEditedFlags[6] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateNextBtnState();
        }

        private void UpdateNextBtnState()
        {
            Nextbtn.Enabled = progressBar1.Value >= 7;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginEN = new Login();
            loginEN.Show();
        }

        private void Themes_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Handle the theme change
            string theme = e.ClickedItem.Text;

            if (theme == "Dark Theme" || theme == "النمط الغامق")
            {
                // Apply the dark theme
                CommonValues.CurrentUserInfo.IsDark = true;
                ApplyDarkTheme();
            }
            else if (theme == "Light Theme" || theme == "النمط الفاتح")
            {
                // Apply the light theme
                CommonValues.CurrentUserInfo.IsDark = false;
                ApplyLightTheme();
            }
        }

        private void SelectLanguage_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string Lang = e.ClickedItem.Text;

            if (Lang == "English")
            {
                // Apply the dark theme

                CommonValues.CurrentUserInfo.IsArabic = false;
                EnglishLanguage();
            }
            else if (Lang == "العربية")
            {
                // Apply the light theme

                CommonValues.CurrentUserInfo.IsArabic = true;
                ArabicLanguage();
            }
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            Username.ForeColor = Color.Black;
            Username.FillColor = Color.FromArgb(224, 224, 224);
            Fname.ForeColor = Color.Black;
            Fname.FillColor = Color.FromArgb(224, 224, 224);
            Lname.ForeColor = Color.Black;
            Lname.FillColor = Color.FromArgb(224, 224, 224);
            Email.ForeColor = Color.Black;
            Email.FillColor = Color.FromArgb(224, 224, 224);
            Gender.ForeColor = Color.Black;
            Gender.FillColor = Color.FromArgb(224, 224, 224);
            toolStrip1.ForeColor = Color.White;
            toolStrip1.BackColor = Color.FromArgb(55, 55, 55);
            Birthdate.ForeColor = Color.Black;
            Birthdate.FillColor = Color.FromArgb(224, 224, 224);
            ActivityLevel.ForeColor = Color.Black;
            ActivityLevel.FillColor = Color.FromArgb(224, 224, 224);
            Themes.ForeColor = Color.White;
            Back.ForeColor = Color.White;
            SelectLanguage.ForeColor = Color.White;
            Themes.Image = Properties.Resources.Dark;
            Back.Image = Properties.Resources.WBack;
            if (!CommonValues.CurrentUserInfo.IsArabic)
            {
                SelectLanguage.Image = Properties.Resources.wEN;
        }
            else
            {
                SelectLanguage.Image = Properties.Resources.wAR;
            }
        }

        private void ApplyLightTheme()
        {
            // Apply the light theme
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            Username.ForeColor = Color.Black;
            Username.FillColor = Color.White;
            Fname.ForeColor = Color.Black;
            Fname.FillColor = Color.White;
            Lname.ForeColor = Color.Black;
            Lname.FillColor = Color.White;
            Email.ForeColor = Color.Black;
            Email.FillColor = Color.White;
            Gender.ForeColor = Color.Black;
            Gender.FillColor = Color.White;
            toolStrip1.ForeColor = Color.White;
            toolStrip1.BackColor = Color.Gainsboro;
            Birthdate.ForeColor = Color.Black;
            Birthdate.FillColor = Color.White;
            ActivityLevel.ForeColor = Color.Black;
            ActivityLevel.FillColor = Color.White;
            Themes.ForeColor = Color.Black;
            Back.ForeColor = Color.Black;
            SelectLanguage.ForeColor = Color.Black;
            Themes.Image = Properties.Resources.Light;
            Back.Image = Properties.Resources.Back;
            if (!CommonValues.CurrentUserInfo.IsArabic)
            {
                SelectLanguage.Image = Properties.Resources.EN;
        }
            else
            {
                SelectLanguage.Image = Properties.Resources.AR;
            }
        }

        private void ArabicLanguage()
        {
            base.RightToLeft = RightToLeft.Yes;
            FnameLable.Location = new Point(451, 57);
            FnameLable.Text = "الأسم الأول:";
            Fname.Location = new Point(340, 85);
            LnameLable.Location = new Point(175, 57);
            LnameLable.Text = "الإسم الأخير:";
            Lname.Location = new Point(61, 85);
            EmailLabel.Location = new Point(480, 138);
            EmailLabel.Text = "الإيميل:";
            Email.Location = new Point(340, 166);
            UsernameLabel.Location = new Point(146, 138);
            UsernameLabel.Text = "إسم المستخدم:";
            Username.Location = new Point(61, 166);
            ActivityLabel.Location = new Point(429, 221);
            ActivityLabel.Text = "مستوى النشاط:";
            ActivityLevel.Location = new Point(438, 252);
            BirthdateLabel.Location = new Point(258, 221);
            BirthdateLabel.Text = "تاريخ الميلاد:";
            Birthdate.Location = new Point(230, 250);
            GenderLabel.Location = new Point(84, 221);
            GenderLabel.Text = "الجنس:";
            Gender.Location = new Point(61, 249);
            Themes.Text = "النمط";
            lightThemeToolStripMenuItem.Text = "النمط الفاتح";
            darkThemeToolStripMenuItem.Text = "النمط الغامق";
            SelectLanguage.Text = "اللغة";
            if (!CommonValues.CurrentUserInfo.IsDark)
            {
            SelectLanguage.Image = Properties.Resources.AR;
            }
            else
            {
                SelectLanguage.Image = Properties.Resources.wAR;
            }
            ActivityLevel.Items.Clear();
            Gender.Items.Clear();
            ActivityLevel.Items.Add("كسول");
            ActivityLevel.Items.Add("خفيف");
            ActivityLevel.Items.Add("متوسط");
            ActivityLevel.Items.Add("نشيط");
            Gender.Items.Add("ذكر");
            Gender.Items.Add("أنثى");
        }

        private void EnglishLanguage()
        {
            base.RightToLeft = RightToLeft.No;

            FnameLable.Location = new Point(56, 47);
            FnameLable.Text = "First Name:";
            Fname.Location = new Point(61, 75);
            LnameLable.Location = new Point(350, 47);
            LnameLable.Text = "Last Name:";
            Lname.Location = new Point(355, 75);
            EmailLabel.Location = new Point(56, 128);
            EmailLabel.Text = "Email:";
            Email.Location = new Point(61, 156);
            UsernameLabel.Location = new Point(350, 128);
            UsernameLabel.Text = "Username:";
            Username.Location = new Point(355, 156);
            ActivityLabel.Location = new Point(446, 211);
            ActivityLabel.Text = "Activity Level:";
            ActivityLevel.Location = new Point(447, 239);
            BirthdateLabel.Location = new Point(274, 211);
            BirthdateLabel.Text = "Birthdate:";
            Birthdate.Location = new Point(241, 239);
            GenderLabel.Location = new Point(80, 211);
            GenderLabel.Text = "Gender:";
            Gender.Location = new Point(61, 239);
            Themes.Text = "Themes";
            lightThemeToolStripMenuItem.Text = "Light Theme";
            darkThemeToolStripMenuItem.Text = "Dark Theme";
            SelectLanguage.Text = "Language";
            if (!CommonValues.CurrentUserInfo.IsDark)
            {
            SelectLanguage.Image = Properties.Resources.EN;
            }
            else
            {
                SelectLanguage.Image = Properties.Resources.wEN;
            }
            ActivityLevel.Items.Clear();
            Gender.Items.Clear();
            ActivityLevel.Items.Add("Lazy");
            ActivityLevel.Items.Add("Lightly");
            ActivityLevel.Items.Add("Medium");
            ActivityLevel.Items.Add("Active");
            Gender.Items.Add("Male");
            Gender.Items.Add("Female");
        }
    }
}