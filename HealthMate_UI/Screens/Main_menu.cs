using HealthMate_UI.Constants;
using HealthMate_UI.Screens;
using ImageRetrievalApp;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace HealthMate_UI
{
    public partial class Main_MenuEN : Form
    {
        private DatabaseManager databaseManager;

        public Main_MenuEN()
        {
            InitializeComponent();
            InitializeCircularPictureBox();
            databaseManager = new DatabaseManager();
            line.Enabled = false;
            button1.Enabled = false;
        }

        private void InitializeCircularPictureBox()
        {
            circularPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Load Image
            if (CommonValues.CurrentUserInfo.IsPPNull)
            {
                circularPictureBox.Image = CommonValues.CurrentUserInfo.PP;
            }
            else
            {
                if (CommonValues.CurrentUserInfo.Gender == "Male")
                {
                    circularPictureBox.Image = Properties.Resources.malePP;
                }
                else
                {
                    circularPictureBox.Image = Properties.Resources.femalePP;
                }
            }
        }

        private void Main_menuEN_Load(object sender, EventArgs e)
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

            DateTime lastLogin = CommonValues.CurrentUserInfo.LastLogin;
            DateTime today = DateTime.Today;
            TimeSpan difference = today - lastLogin;
            int daysSinceLastLogin = difference.Days;
            if (daysSinceLastLogin >= 3)
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    MessageBoxOptions options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
                    MessageBox.Show("يبدو أنك غبت لبضعة أيام. هل تتذكر التزامك؟ دعنا نستأنف من حيث توقفنا.", "مرحبًا بعودتك!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, options);
                }
                else
                {
                    MessageBox.Show("It looks like you've been away for a few days. Remember your commitment? Let's pick up where we left off.", "Welcome back!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            try
            {
                databaseManager.OpenConnection();
                string readQuery = "SELECT * FROM UserInfo WHERE UserName = @Username";
                using (SqlCommand command = new SqlCommand(readQuery, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Username", CommonValues.CurrentUserInfo.UserName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CommonValues.CurrentUserInfo.LastLogin = (DateTime)reader["LastLogin"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                databaseManager.CloseConnection();
            }
        }

        private void Main_menuEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AgeCalcBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgeCalc ageCalcEN = new AgeCalc();
            ageCalcEN.Show();
        }

        private void HealthMonitorBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            HealthMonitor healthMonitorEN = new HealthMonitor();
            healthMonitorEN.Show();
        }

        private void UpdateInfoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateInfo updateInfoEN = new UpdateInfo();
            updateInfoEN.Show();
        }

        private void CaloriesTrackerBtn_Click(object sender, EventArgs e)
        {
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                MessageBox.Show(".الميزة ما زالت تحت التطوير\nكن صبوراً", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {
                MessageBox.Show("The feature is still under development.\nPlease be patient.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            this.Hide();
            Calories_Tracker calories_Tracker = new Calories_Tracker();
            calories_Tracker.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            CommonValues.CurrentUserInfo = null;

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
                Themes.Image = Properties.Resources.Dark;
                CommonValues.CurrentUserInfo.IsDark = true;
                ApplyDarkTheme();
                try
                {
                    databaseManager.OpenConnection();
                    string updateQuery = "UPDATE UserPreferences SET IsDark = @IsDark WHERE UserName_FK = @Username";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, databaseManager.GetConnection()))
                    {
                        updateCommand.Parameters.AddWithValue("@Username", CommonValues.CurrentUserInfo.UserName);
                        updateCommand.Parameters.AddWithValue("@IsDark", CommonValues.CurrentUserInfo.IsDark ? 1 : 0);

                        updateCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
            else if (theme == "Light Theme" || theme == "النمط الفاتح")
            {
                // Apply the light theme
                CommonValues.CurrentUserInfo.IsDark = false;
                ApplyLightTheme();
                try
                {
                    databaseManager.OpenConnection();
                    string updateQuery = "UPDATE UserPreferences SET IsDark = @IsDark WHERE UserName_FK = @Username";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, databaseManager.GetConnection()))
                    {
                        updateCommand.Parameters.AddWithValue("@Username", CommonValues.CurrentUserInfo.UserName);
                        updateCommand.Parameters.AddWithValue("@IsDark", CommonValues.CurrentUserInfo.IsDark ? 1 : 0);

                        updateCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
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
                try
                {
                    databaseManager.OpenConnection();
                    string updateQuery = "UPDATE UserPreferences SET IsArabic = @IsArabic WHERE UserName_FK = @Username";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, databaseManager.GetConnection()))
                    {
                        updateCommand.Parameters.AddWithValue("@Username", CommonValues.CurrentUserInfo.UserName);
                        updateCommand.Parameters.AddWithValue("@IsArabic", CommonValues.CurrentUserInfo.IsArabic ? 1 : 0);

                        updateCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
            else if (Lang == "العربية")
            {
                // Apply the light theme

                CommonValues.CurrentUserInfo.IsArabic = true;
                ArabicLanguage();
                try
                {
                    databaseManager.OpenConnection();
                    string updateQuery = "UPDATE UserPreferences SET IsArabic = @IsArabic WHERE UserName_FK = @Username";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, databaseManager.GetConnection()))
                    {
                        updateCommand.Parameters.AddWithValue("@Username", CommonValues.CurrentUserInfo.UserName);
                        updateCommand.Parameters.AddWithValue("@IsArabic", CommonValues.CurrentUserInfo.IsArabic ? 1 : 0);

                        updateCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
        }

        private void ApplyDarkTheme()
        {
            // Apply the dark theme
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            AgeCalcBtn.ForeColor = Color.Black;
            AgeCalcBtn.FillColor = Color.FromArgb(224, 224, 224);
            HealthMonitorBtn.ForeColor = Color.Black;
            HealthMonitorBtn.FillColor = Color.FromArgb(224, 224, 224);
            UpdateInfoBtn.ForeColor = Color.Black;
            UpdateInfoBtn.FillColor = Color.FromArgb(224, 224, 224);
            Workout.ForeColor = Color.Black;
            Workout.FillColor = Color.FromArgb(224, 224, 224);
            CaloriesTrackerBtn.ForeColor = Color.Black;
            CaloriesTrackerBtn.FillColor = Color.FromArgb(224, 224, 224);
            toolStrip1.ForeColor = Color.White;
            toolStrip1.BackColor = Color.FromArgb(55, 55, 55);
            Themes.ForeColor = Color.White;
            Logout.ForeColor = Color.White;
            Logout.Image = Properties.Resources.WLogout;
            SelectLanguage.ForeColor = Color.White;
            Themes.Image = Properties.Resources.Dark;
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
            AgeCalcBtn.ForeColor = Color.Black;
            AgeCalcBtn.FillColor = Color.White;
            HealthMonitorBtn.ForeColor = Color.Black;
            HealthMonitorBtn.FillColor = Color.White;
            UpdateInfoBtn.ForeColor = Color.Black;
            UpdateInfoBtn.FillColor = Color.White;
            Workout.ForeColor = Color.Black;
            Workout.FillColor = Color.White;
            CaloriesTrackerBtn.ForeColor = Color.Black;
            CaloriesTrackerBtn.FillColor = Color.White;
            toolStrip1.ForeColor = Color.White;
            toolStrip1.BackColor = Color.Gainsboro;
            Themes.ForeColor = Color.Black;
            Logout.ForeColor = Color.Black;
            Logout.Image = Properties.Resources.Logout;
            SelectLanguage.ForeColor = Color.Black;
            Themes.Image = Properties.Resources.Light;
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
            AgeCalcBtn.Text = "حساب العمر";
            HealthMonitorBtn.Text = "مراقب الصحة";
            UpdateInfoBtn.Text = "تحديث بياناتك";
            CaloriesTrackerBtn.Text = "تتبع السعرات الحرارية";
            WelcomeMsg.Location = new Point(280, 45);
            HappyBirthday.Location = new Point(280, 76);
            circularPictureBox.Location = new Point(42, 29);
            Themes.Text = "النمط";
            lightThemeToolStripMenuItem.Text = "النمط الفاتح";
            darkThemeToolStripMenuItem.Text = "النمط الغامق";
            SelectLanguage.Text = "اللغة";
            Logout.Text = "تسجيل الخروج";
            if (!CommonValues.CurrentUserInfo.IsDark)
            {
                SelectLanguage.Image = Properties.Resources.AR;
            }
            else
            {
                SelectLanguage.Image = Properties.Resources.wAR;
            }
            string welcomeMessage = WelcomeMessageGeneratorAR.GenerateWelcomeMessage(CommonValues.CurrentUserInfo.FName);
            WelcomeMsg.Text = welcomeMessage;
            if (CommonValues.CurrentUserInfo.BirthDate.Month == DateTime.Today.Month &&
            CommonValues.CurrentUserInfo.BirthDate.Day == DateTime.Today.Day)
            {
                HappyBirthday.Text = $"يوم ميلاد سعيد🎂❤️";
            }
        }

        private void EnglishLanguage()
        {
            base.RightToLeft = RightToLeft.No;
            AgeCalcBtn.Text = "Age Calculator";
            HealthMonitorBtn.Text = "Health Monitor";
            UpdateInfoBtn.Text = "Update Your Data";
            CaloriesTrackerBtn.Text = "Calories Tracker";
            Themes.Text = "Themes";
            lightThemeToolStripMenuItem.Text = "Light Theme";
            darkThemeToolStripMenuItem.Text = "Dark Theme";
            SelectLanguage.Text = "Language";
            Logout.Text = "Logout";
            WelcomeMsg.Location = new Point(37, 45);
            HappyBirthday.Location = new Point(37, 76);
            circularPictureBox.Location = new Point(489, 29);
            if (!CommonValues.CurrentUserInfo.IsDark)
            {
                SelectLanguage.Image = Properties.Resources.EN;
            }
            else
            {
                SelectLanguage.Image = Properties.Resources.wEN;
            }
            string welcomeMessage = WelcomeMessageGeneratorEN.GenerateWelcomeMessage(CommonValues.CurrentUserInfo.FName);
            WelcomeMsg.Text = welcomeMessage;
            if (CommonValues.CurrentUserInfo.BirthDate.Month == DateTime.Today.Month &&
            CommonValues.CurrentUserInfo.BirthDate.Day == DateTime.Today.Day)
            {
                HappyBirthday.Text = $"Happy Birthday🎂❤️";
            }
        }
    }
}