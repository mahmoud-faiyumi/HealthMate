using HealthMate_UI.Constants;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HealthMate_UI
{
    public partial class AgeCalc : Form
    {
        private bool anotherDate = false;
        public AgeCalc()
        {
            InitializeComponent();
            line.Enabled = false;
        }

        private void AgeCalcEN_Load(object sender, EventArgs e)
        {
            if (CommonValues.CurrentUserInfo.IsDark == true)
            {
                ApplyDarkTheme();
            }
            else
            {
                ApplyLightTheme();
            }
            if (CommonValues.CurrentUserInfo.IsArabic == false)
            {
                EnglishCalculation();
            }
            else if (CommonValues.CurrentUserInfo.IsArabic == true)
            {
                ArabicLanguage();
                ArabicCalculation();
            }
        }

        private void AgeCalcEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AnotherDateBtn_Click(object sender, EventArgs e)
        {
            anotherDate = true;
            if (CommonValues.CurrentUserInfo.IsArabic == false)
            {
                EnglishCalculation();
            }
            else if (CommonValues.CurrentUserInfo.IsArabic == true)
            {
                ArabicLanguage();
                ArabicCalculation();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_MenuEN main_menuEN = new Main_MenuEN();
            main_menuEN.Show();
        }

        private void ApplyDarkTheme()
        {
            // Apply the dark theme
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            Back.Image = Properties.Resources.WBack;
            Back.ForeColor = Color.White;
        }

        private void ApplyLightTheme()
        {
            // Apply the light theme
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            Back.Image = Properties.Resources.Back;
            Back.ForeColor = Color.Black;
        }

        private void ArabicLanguage()
        {
            base.RightToLeft = RightToLeft.Yes;
            AGEtxt.Location = new Point(156, 85);
            NEXTBDtxt.Location = new Point(192, 152);
            BDAYtxt.Location = new Point(228, 220);
            AnotherDateBtn.Text = "تاريخ مخصص";
            Backlbl.Text = "رجوع";
            alert.Text = "*هذه البيانات تقريبية وقد لا تكون دقيقة.";
        }

        private void ArabicCalculation()
        {
            DateTime birthDate;
            if (anotherDate)
            {
                birthDate = CustomdatePicker.Value;
            }
            else
            {
               birthDate = CommonValues.CurrentUserInfo.BirthDate;
            }
            DateTime now = DateTime.Now;
            TimeSpan ageTimeSpan = now - birthDate;
            byte years = (byte)Math.Floor(ageTimeSpan.TotalDays / 365.242199);
            short months = (short)Math.Floor((ageTimeSpan.TotalDays % 365.242199) / 30.4368499);
            int days = (int)Math.Floor(ageTimeSpan.TotalDays % 30.4368499);

            byte nextBirthdayMonths = (byte)Math.Floor(((years + 1) * 365.24199 - ageTimeSpan.TotalDays) / 30.4368499);
            byte nextBirthdayDays = (byte)Math.Ceiling(((years + 1) * 365.24199 - ageTimeSpan.TotalDays) % 30.4368499);

            int totalDays = (int)ageTimeSpan.TotalDays;
            int totalHours = (int)ageTimeSpan.TotalHours;
            long totalMinutes = (long)ageTimeSpan.TotalMinutes;

            double heartBeat = totalMinutes * 80;
            double totalFoodTonnes = Math.Round((years * 675.0 / 1000.0), 3);

            int WaterLitres = (int)Math.Floor(totalDays * 1.892079611964252);
            double totalSleepYears = Math.Round((totalDays / 365.242199) * 0.333333333333, 2);

            var arabicDayTranslations = new ArabicDayTranslations();
            string dayOfWeekArabic = arabicDayTranslations.GetArabicDayOfWeek(birthDate);
            ageLabel.Text = "عمرك هو:";
            AGEtxt.Text = $"{years} سنة و {months} شهر و {days} يوم.";
            nextBirthdayLabel.Text = "عيد ميلادك القادم في:";
            NEXTBDtxt.Text = $"{nextBirthdayMonths} أشهر و {nextBirthdayDays} يوم";
            BirthDateDaylabel.Text = $"اليوم الذي وُلدت فيه هو:";
            BDAYtxt.Text = $"{dayOfWeekArabic}";
            additionalFactsLabel.Text = "حقائق مذهلة عنك...";
            if (heartBeat > 1000000000)
            {
                heartBeat = heartBeat / 1000000000;
                double heartBeats = Math.Round(heartBeat, 2);
                FACTStxt1.Text = $"{heartBeats} مليار نبضة قلب.";
            }
            else if (heartBeat > 1000000)
            {
                heartBeat = heartBeat / 1000000;
                double heartBeats = Math.Round(heartBeat, 2);
                FACTStxt1.Text = $"{heartBeats} مليون نبضة قلب.";
            }
            else if (heartBeat > 1000)
            {
                heartBeat = heartBeat / 1000;
                double heartBeats = Math.Round(heartBeat, 2);
                FACTStxt1.Text = $"{heartBeats} الف نبضة قلب.";
            }
            else
            {
                FACTStxt1.Text = $"{heartBeat.ToString("N0"):N0} نبضة قلب.";
            }
            FACTStxt2.Text = $"{totalFoodTonnes} أطنان من الطعام.";
            FACTStxt3.Text = $"{WaterLitres:N0} لتر من الماء.";
            FACTStxt4.Text = $"نمت لمدة {totalSleepYears} سنة.";

            LivedForlabel.Text = "عشت لمدة:";
            LIVEDtxt1.Text = $"{years} سنة.";
            LIVEDtxt2.Text = $"{(int)(totalDays / 30.4368499)} شهر.";
            LIVEDtxt3.Text = $"{(int)(totalDays / 7)} أسبوع.";
            LIVEDtxt4.Text = $"{totalDays:N0} يوم.";
            LIVEDtxt5.Text = $"{totalHours:N0} ساعة.";
        }

        private void EnglishCalculation()
        {
            DateTime birthDate;
            if (anotherDate)
            {
                birthDate = CustomdatePicker.Value;
            }
            else
            {
                birthDate = CommonValues.CurrentUserInfo.BirthDate;
            }
            DateTime now = DateTime.Now;
            TimeSpan ageTimeSpan = now - birthDate;
            byte years = (byte)Math.Floor(ageTimeSpan.TotalDays / 365.242199);
            short months = (short)Math.Floor((ageTimeSpan.TotalDays % 365.242199) / 30.4368499);
            int days = (int)Math.Floor(ageTimeSpan.TotalDays % 30.4368499);

            byte nextBirthdayMonths = (byte)Math.Floor(((years + 1) * 365.24199 - ageTimeSpan.TotalDays) / 30.4368499);
            byte nextBirthdayDays = (byte)Math.Ceiling(((years + 1) * 365.24199 - ageTimeSpan.TotalDays) % 30.4368499);

            int totalDays = (int)ageTimeSpan.TotalDays;
            int totalHours = (int)ageTimeSpan.TotalHours;
            long totalMinutes = (long)ageTimeSpan.TotalMinutes;

            double heartBeat = totalMinutes * 80;
            double totalFoodTonnes = Math.Round((years * 675.0 / 1000.0), 3);

            int WaterLitres = (int)Math.Floor(totalDays * 1.892079611964252);
            double totalSleepYears = Math.Round((totalDays / 365.242199) * 0.333333333333, 2);

            ageLabel.Text = "Your Age is:";
            AGEtxt.Text = $"{years} Years, {months} Months and {days} Days.";
            nextBirthdayLabel.Text = "Next Birthday in:";
            NEXTBDtxt.Text = $"{nextBirthdayMonths} Months and {nextBirthdayDays} Days";
            BirthDateDaylabel.Text = $"The day you were born is:";
            BDAYtxt.Text = $"{birthDate.DayOfWeek}";
            additionalFactsLabel.Text = "Amazing Facts About You...";
            if (heartBeat > 1000000000)
            {
                heartBeat = heartBeat / 1000000000;
                double heartBeats = Math.Round(heartBeat, 2);
                FACTStxt1.Text = $"{heartBeats} billion heart beat.";
            }
            else if (heartBeat > 1000000)
            {
                heartBeat = heartBeat / 1000000;
                double heartBeats = Math.Round(heartBeat, 2);
                FACTStxt1.Text = $"{heartBeats} Million heart beat.";
            }
            else if (heartBeat > 1000)
            {
                heartBeat = heartBeat / 1000;
                double heartBeats = Math.Round(heartBeat, 2);
                FACTStxt1.Text = $"{heartBeats} thousand heart beat.";
            }
            else
            {
                FACTStxt1.Text = $"{heartBeat.ToString("N0"):N0} heart beat.";
            }
            FACTStxt2.Text = $"{totalFoodTonnes} tons of food.";
            FACTStxt3.Text = $"{WaterLitres:N0} liters of water.";
            FACTStxt4.Text = $"Slept for {totalSleepYears} years.";

            LivedForlabel.Text = "You Lived For:";
            LIVEDtxt1.Text = $"{years} Years.";
            LIVEDtxt2.Text = $"{(int)(totalDays / 30.4368499)} Months.";
            LIVEDtxt3.Text = $"{(int)(totalDays / 7)} Weeks.";
            LIVEDtxt4.Text = $"{totalDays:N0} Days.";
            LIVEDtxt5.Text = $"{totalHours:N0} Hours.";
        }
    }
}