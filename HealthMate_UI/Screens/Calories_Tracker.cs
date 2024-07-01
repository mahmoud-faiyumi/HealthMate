using HealthMate_UI.Constants;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.Collections.Generic;
using System.Linq;

namespace HealthMate_UI.Screens
{
    public partial class Calories_Tracker : Form
    {
        public Calories_Tracker()
        {
            InitializeComponent();
            LoadChartData();
        }

        private void Calories_Tracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_MenuEN main_menuEN = new Main_MenuEN();
            main_menuEN.Show();
        }

        private void Breakfast_Click(object sender, EventArgs e)
        {
            Breakfast breakfast = new Breakfast();
            breakfast.Show();
        }

        private void Lunch_Click(object sender, EventArgs e)
        {
            Lunch lunch = new Lunch();
            lunch.Show();
        }

        private void Dinner_Click(object sender, EventArgs e)
        {
            Dinner dinner = new Dinner();
            dinner.Show();
        }

        private void ExtraMeal_Click(object sender, EventArgs e)
        {
            ExtraMeal extraMeal = new ExtraMeal();
            extraMeal.Show();
        }

        private void Calories_Tracker_Load(object sender, EventArgs e)
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
        }

        private void LoadChartData()
        {
            List<DateTime> dates = new List<DateTime>();
            List<double> TotalCal = new List<double>();

            try
            {
                using (DatabaseManageruc databaseManageruc = new DatabaseManageruc())
                {
                    databaseManageruc.OpenConnection();
                    string readQuery = $"SELECT Date, TotalCal FROM [{CommonValues.CurrentUserInfo.UserName}]";
                    using (SqlCommand command = new SqlCommand(readQuery, databaseManageruc.GetConnection()))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dates.Add((DateTime)reader["Date"]);
                                TotalCal.Add((double)reader["TotalCal"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

            BindDataToChart(dates, TotalCal);
        }

        private void BindDataToChart(List<DateTime> dates, List<double> TotalCal)
        {
            var Calories = new LineSeries
            {
                Values = new ChartValues<double>(TotalCal)
            };

            CalHistory.Series = new SeriesCollection { Calories };

            string[] dayNames; // Define dayNames variable outside the if-else block

            // Convert dates to day names
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                var arabicDayTranslations = new ArabicDayTranslations();
                dayNames = dates.Select(date => arabicDayTranslations.GetArabicDayOfWeek(date)).ToArray();
            }
            else
            {
                dayNames = dates.Select(date => date.ToString("dddd")).ToArray();
            }

            CalHistory.AxisX.Add(new Axis
            {
                Title = "Day",
                Labels = dayNames, // Use day names instead of dates
                LabelsRotation = 15
            });

            CalHistory.AxisY.Add(new Axis
            {
                Title = "Calories",
                MinValue = 0 // Set the minimum value of the Y-axis to 0
            });
        }

        private void EnglishLanguage()
        {
            Breakfast.Text = "+ Breakfast";
            Lunch.Text = "+ Lunch";
            Dinner.Text = "+ Dinner";
            ExtraMeal.Text = "+ Extra meal";
            Back.Text = "Back";
        }

        private void ArabicLanguage()
        {
            Breakfast.Text = "افطار +";
            Lunch.Text = "غداء +";
            Dinner.Text = "عشاء +";
            ExtraMeal.Text = "وجبة اضافية +";
            Back.Text = "رجوع";
        }

        private void ApplyLightTheme()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            toolStrip1.ForeColor = Color.Black;
            toolStrip1.BackColor = Color.Gainsboro;
            Back.Image = Properties.Resources.Back;
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            toolStrip1.ForeColor = Color.White;
            toolStrip1.BackColor = Color.FromArgb(55, 55, 55);
            Back.Image = Properties.Resources.WBack;
        }

    }
}
