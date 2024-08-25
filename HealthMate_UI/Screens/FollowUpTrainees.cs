using HealthMate_UI.Constants;
using HealthMate_UI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Selectors;
using System.Windows.Forms;

namespace HealthMate_UI.Screens
{
    public partial class FollowUpTrainees : Form
    {
        public FollowUpTrainees()
        {
            InitializeComponent();
        }

        private void FollowUpTrainees_Load(object sender, EventArgs e)
        {
            LoadTrainees();
            DataGridViewTrainees.SelectionChanged += DataGridViewTrainees_SelectionChanged;
        }

        private void LoadTrainees()
        {
            try
            {
                using (DatabaseManagerui databaseManagerui = new DatabaseManagerui())
                {
                    databaseManagerui.OpenConnection();
                    string readQuery = "SELECT UserName, FName, LName, Height, Weight, Age, BMI, LastLogin FROM UserInfo WHERE CoachID = @ID";

                    using (SqlCommand readCommand = new SqlCommand(readQuery, databaseManagerui.GetConnection()))
                    {
                        readCommand.Parameters.AddWithValue("@ID", CommonValues.CurrentUserInfo.ID); // Assume coachId is passed or available

                        using (SqlDataReader reader = readCommand.ExecuteReader())
                        {
                            List<Trainee> trainees = new List<Trainee>();

                            while (reader.Read())
                            {
                                Trainee trainee = new Trainee
                                {
                                    UserName = reader["UserName"].ToString(),
                                    FullName = reader["FName"].ToString() + " " + reader["LName"].ToString(),
                                    Height = Convert.ToInt32(reader["Height"]),
                                    Weight = Convert.ToInt32(reader["Weight"]),
                                    Age = Convert.ToInt32(reader["Age"]),
                                    BMI = Convert.ToDouble(reader["BMI"]),
                                    LastLogin = Convert.ToDateTime(reader["LastLogin"])
                                };

                                trainees.Add(trainee);
                            }

                            DataGridViewTrainees.DataSource = trainees;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Event handler to detect when a trainee is selected
        private void DataGridViewTrainees_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewTrainees.SelectedRows.Count > 0)
            {
                Trainee selectedTrainee = (Trainee)DataGridViewTrainees.SelectedRows[0].DataBoundItem;
                LoadTraineeDetails(selectedTrainee);
            }
        }

        // Method to load more details about the selected trainee
        private void LoadTraineeDetails(Trainee trainee)
        {
            try
            {
                using (DatabaseManageruc databaseManageruc = new DatabaseManageruc())
                {
                    databaseManageruc.OpenConnection();

                    // Use a parameterized query to prevent SQL injection for the table contents
                    string detailsQuery = $"SELECT Date, BreakfastCal, LunchCal, DinnerCal, ExtraCal, TotalCal FROM [{trainee.UserName}]";

                    using (SqlCommand detailsCommand = new SqlCommand(detailsQuery, databaseManageruc.GetConnection()))
                    {
                        using (SqlDataReader reader = detailsCommand.ExecuteReader())
                        {
                            List<CaloriesLog> CaloriesLog = new List<CaloriesLog>();

                            while (reader.Read())
                            {
                                CaloriesLog log = new CaloriesLog
                                {
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    BreakfastCal = Convert.ToDouble(reader["BreakfastCal"]),
                                    LunchCal = Convert.ToDouble(reader["LunchCal"]),
                                    DinnerCal = Convert.ToDouble(reader["DinnerCal"]),
                                    ExtraCal = Convert.ToDouble(reader["ExtraCal"]),
                                    TotalCal = Convert.ToDouble(reader["TotalCal"])
                                };

                                CaloriesLog.Add(log);
                            }

                            DataGridViewCalorie.DataSource = CaloriesLog;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Model class for ExerciseLog
        public class CaloriesLog
        {
            public DateTime Date { get; set; }
            public double BreakfastCal { get; set; }
            public double LunchCal { get; set; }
            public double DinnerCal { get; set; }
            public double ExtraCal { get; set; }
            public double TotalCal { get; set; }
        }

        public class Trainee
        {
            public string UserName { get; set; }
            public string FullName { get; set; }   // Combined FirstName and LastName
            public int Height { get; set; }
            public int Weight { get; set; }
            public int Age { get; set; }
            public double BMI { get; set; }
            public DateTime LastLogin { get; set; }
        }
    }
}
