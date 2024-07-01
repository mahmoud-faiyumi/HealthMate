using HealthMate_UI.Models;
using HealthMate_UI.Constants;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HealthMate_UI.Screens
{
    public partial class Workout : Form
    {
        private int selectedExerciseIndex = -1;
        private Timer exerciseTimer;
        private Timer restTimer;
        private int currentExerciseIndex;
        private List<Exercise> beginnerExercises;
        private List<Exercise> intermediateExercises;
        private List<Exercise> advancedExercises;
        private List<Exercise> currentExercises;
        private bool isResting;
        private int restTimeLeft = 20;
        private bool HidePanel = true;

        public Workout()
        {
            InitializeComponent();
            BtnSkipRest.Visible = false;
            SkipRestlbl.Visible = false;
            LoadWorkout();
        }

        private void LoadWorkout()
        {
            beginnerExercises = LoadExercisesByLevel("Beginner");
            intermediateExercises = LoadExercisesByLevel("Intermediate");
            advancedExercises = LoadExercisesByLevel("Advanced");

            currentExerciseIndex = 0;
            isResting = false;

            InitializeMuscleGroupTabs();
            InitializeTimers();

            LevelTab.SelectedIndexChanged += LevelTab_SelectedIndexChanged;
            LevelTab_SelectedIndexChanged(this, EventArgs.Empty);
        }
        private List<Exercise> LoadExercisesByLevel(string level)
        {
            var exercises = new List<Exercise>();
            try
            {
                using (var databaseManager = new DatabaseManagerwo())
                {
                    databaseManager.OpenConnection();
                    string readQuery = $"SELECT * FROM Exercises WHERE ExerciseLevel = '{level}'";
                    using (var command = new SqlCommand(readQuery, databaseManager.GetConnection()))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var exercise = new Exercise
                                {
                                    Id = (int)reader["Id"],
                                    ExName = (string)reader["Name"],
                                    MuscleGroups = ((string)reader["MuscleGroups"]).Split(',').ToList(),
                                    GifResourceName = (string)reader["GifResourceName"],
                                    YouTubeLink = (string)reader["YouTubeLink"],
                                    Duration = (int)reader["Duration"],
                                    DescriptionEn = reader["DescriptionEn"] != DBNull.Value ? (string)reader["DescriptionEn"] : null,
                                    DescriptionAr = reader["DescriptionAr"] != DBNull.Value ? (string)reader["DescriptionAr"] : null,
                                    MetValue = reader["MetValue"] != DBNull.Value ? (float)(double)reader["MetValue"] : 0f
                                };
                                exercises.Add(exercise);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return exercises;
        }

        private void InitializeTimers()
        {
            exerciseTimer = new Timer();
            exerciseTimer.Interval = 1000; // 1 second
            exerciseTimer.Tick += ExerciseTimer_Tick;

            restTimer = new Timer();
            restTimer.Interval = 1000; // 1 second
            restTimer.Tick += RestTimer_Tick;
        }

        private void StartExerciseTimer(int durationInSeconds)
        {
            lblTimer.Text = durationInSeconds.ToString();
            exerciseTimer.Start();
        }

        private void InitializeMuscleGroupTabs()
        {
            MuscleGroupTab.TabPages.Clear();

            string[] muscleGroups = { "Warm-up", "Chest", "Legs", "Full Body", "Arms", "Core", "Shoulders", "Back" };
            foreach (var muscleGroup in muscleGroups)
            {
                AddMuscleGroupTab(muscleGroup);
            }
        }

        private void AddMuscleGroupTab(string muscleGroup)
        {
            var tabPage = new TabPage(muscleGroup);
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };
            tabPage.Controls.Add(panel);
            MuscleGroupTab.TabPages.Add(tabPage);
        }

        private void UpdateExercisesInTab(string muscleGroup)
        {
            var currentTab = MuscleGroupTab.TabPages.Cast<TabPage>().FirstOrDefault(tp => tp.Text == muscleGroup);
            if (currentTab == null) return;

            var panel = currentTab.Controls[0] as Panel;
            if (panel == null) return;

            panel.Controls.Clear();

            // Create TableLayoutPanel for a professional table layout
            var tableLayout = new TableLayoutPanel
            {
                ColumnCount = 3,
                AutoSize = true,
                Dock = DockStyle.Top,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Add column headers
            tableLayout.Controls.Add(new Label { Text = "Exercise", Font = new Font("Arial", 10, FontStyle.Bold), Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            tableLayout.Controls.Add(new Label { Text = "Duration", Font = new Font("Arial", 10, FontStyle.Bold), Anchor = AnchorStyles.Left, AutoSize = true }, 1, 0);
            tableLayout.Controls.Add(new Label { Text = "Preview", Font = new Font("Arial", 10, FontStyle.Bold), Anchor = AnchorStyles.Left, AutoSize = true }, 2, 0);

            // Increment row count for each exercise
            var exercises = GetExercisesForCurrentLevel();
            int rowIndex = 1; // Start with 1 to skip header row
            foreach (var exercise in exercises.Where(ex => ex.MuscleGroups.Contains(muscleGroup)))
            {
                tableLayout.RowCount++;

                // Create and add exercise name label
                var exerciseLabel = new Label
                {
                    Text = exercise.ExName,
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Font = new Font("Arial", 8),
                    Cursor = Cursors.Hand, // Set cursor to indicate clickable
                    TextAlign = ContentAlignment.MiddleCenter
                };
                exerciseLabel.Click += (sender, e) => ExerciseLabel_Click(exercise); // Handle exercise label click
                tableLayout.Controls.Add(exerciseLabel, 0, rowIndex);

                // Create and add duration label
                var durationLabel = new Label
                {
                    Text = exercise.Duration.ToString(),
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Font = new Font("Arial", 8),
                    Cursor = Cursors.Hand, // Set cursor to indicate clickable
                    TextAlign = ContentAlignment.MiddleCenter
                };
                durationLabel.Click += (sender, e) => ExerciseLabel_Click(exercise); // Handle duration label click
                tableLayout.Controls.Add(durationLabel, 1, rowIndex);

                // Create and add PictureBox for the GIF
                var exercisePictureBox = new PictureBox
                {
                    Image = LoadImageFromResource(exercise.GifResourceName),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(50, 50),
                    Anchor = AnchorStyles.Left,
                    Cursor = Cursors.Hand // Set cursor to indicate clickable
                };
                exercisePictureBox.Click += (sender, e) => ExercisePictureBox_Click(exercise); // Handle picture box click
                tableLayout.Controls.Add(exercisePictureBox, 2, rowIndex);

                rowIndex++;
            }

            panel.Controls.Add(tableLayout);
        }

        private void ExerciseLabel_Click(Exercise exercise)
        {
            selectedExerciseIndex = GetExerciseIndex(exercise);
            ShowExercise(exercise);
        }

        private void ExercisePictureBox_Click(Exercise exercise)
        {
            selectedExerciseIndex = GetExerciseIndex(exercise);
            ShowExercise(exercise);
        }

        private int GetExerciseIndex(Exercise exercise)
        {
            var exercises = GetExercisesForCurrentLevel();
            string currentMuscleGroup = MuscleGroupTab.SelectedTab.Text;
            var muscleGroupExercises = exercises.Where(ex => ex.MuscleGroups.Contains(currentMuscleGroup)).ToList();
            return muscleGroupExercises.FindIndex(ex => ex.ExName == exercise.ExName);
        }

        private void ShowExercise(Exercise exercise)
        {
            lblExerciseName.Text = exercise.ExName;
            picExerciseGif.Image = LoadImageFromResource(exercise.GifResourceName);
            lblTimer.Text = exercise.Duration.ToString(); // Set initial timer value
            label3.Text = "Start";
            btnPauseTimer.Image = Properties.Resources.play;
            exerciseTimer.Stop();
        }

        private Image LoadImageFromResource(string resourceName)
        {
            try
            {
                var resourceManager = Properties.Resources.ResourceManager;
                var image = (Image)resourceManager.GetObject(resourceName);
                return image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image resource: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private List<Exercise> GetExercisesForCurrentLevel()
        {
            switch (LevelTab.SelectedTab.Text)
            {
                case "Advanced":
                    return advancedExercises;
                case "Intermediate":
                    return intermediateExercises;
                default:
                    return beginnerExercises;
            }
        }

        private void ExerciseTimer_Tick(object sender, EventArgs e)
        {
            if (int.TryParse(lblTimer.Text, out int timeLeft))
            {
                if (timeLeft > 0)
                {
                    lblTimer.Text = (timeLeft - 1).ToString();
                }
                else
                {
                    exerciseTimer.Stop();
                    if (!isResting)
                    {
                        // Start rest period
                        isResting = true;
                        lblExerciseName.Text = "Rest";
                        lblTimer.Text = restTimeLeft.ToString(); // Initial rest timer value
                        BtnSkipRest.Visible = true;
                        SkipRestlbl.Visible = true;
                        restTimer.Start();
                    }
                    else
                    {
                        // Rest period complete, move to next exercise
                        isResting = false;
                        BtnSkipRest.Visible = false;
                        SkipRestlbl.Visible = false;
                        btnNextExercise.PerformClick();
                    }
                }
            }
            else
            {
                exerciseTimer.Stop();
                MessageBox.Show("Invalid timer value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RestTimer_Tick(object sender, EventArgs e)
        {
            if (int.TryParse(lblTimer.Text, out int timeLeft))
            {
                timeLeft--;
                lblTimer.Text = timeLeft.ToString();

                if (timeLeft <= 0)
                {
                    restTimer.Stop();
                    BtnSkipRest.Visible = false;
                    SkipRestlbl.Visible = false;
                    isResting = false;

                    // Automatically move to the next exercise after the rest period
                    btnNextExercise_Click(this, EventArgs.Empty);
                }
            }
        }

        private void btnNextExercise_Click(object sender, EventArgs e)
        {
            // Get the list of exercises for the current level and muscle group
            var exercises = GetExercisesForCurrentLevel();
            string currentMuscleGroup = MuscleGroupTab.SelectedTab.Text;
            var muscleGroupExercises = exercises.Where(ex => ex.MuscleGroups.Contains(currentMuscleGroup)).ToList();

            // Move to the next exercise in the current muscle group
            if (selectedExerciseIndex + 1 < muscleGroupExercises.Count)
            {
                selectedExerciseIndex++;
            }
            else
            {
                MessageBox.Show("Workout complete!");
                lblTimer.Text = "Start";
                btnPauseTimer.Image = Properties.Resources.play;

                // Reset currentExerciseIndex after completing the workout
                currentExerciseIndex = -1;
            }

            var nextExercise = muscleGroupExercises[selectedExerciseIndex];
            ShowExercise(nextExercise);

            // Start the timer for the next exercise
            btnPauseTimer.Image = Properties.Resources.pause;
            label3.Text = "Pause";
            StartExerciseTimer(nextExercise.Duration);
        }

        private void btnPauseTimer_Click(object sender, EventArgs e)
        {
            if (currentExercises == null || currentExercises.Count == 0 || currentExerciseIndex == -1)
            {
                MessageBox.Show("Please select an exercise to start.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (exerciseTimer.Enabled || restTimer.Enabled)
            {
                // If either exercise timer or rest timer is running, pause both
                exerciseTimer.Stop();
                restTimer.Stop();
                label3.Text = "Resume";
                btnPauseTimer.Image = Properties.Resources.Resume;
            }
            else
            {
                // If no timer is running and there are exercises selected
                if (isResting)
                {
                    restTimer.Start();
                }
                else
                {
                    StartExerciseTimer(int.Parse(lblTimer.Text)); // Resume with the remaining time
                }
                label3.Text = "Pause";
                btnPauseTimer.Image = Properties.Resources.pause;
            }
        }


        private void btnOpenYouTube_Click(object sender, EventArgs e)
        {
            if (currentExercises != null && currentExercises.Count > 0 && currentExerciseIndex != -1)
            {
                string youtubeLink = currentExercises[currentExerciseIndex].YouTubeLink;
                System.Diagnostics.Process.Start(youtubeLink);
            }
            else
            {
                MessageBox.Show("No exercise selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LevelTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentExercises = GetExercisesForCurrentLevel(); // Update currentExercises based on the selected level

            foreach (TabPage tabPage in MuscleGroupTab.TabPages)
            {
                UpdateExercisesInTab(tabPage.Text);
            }
        }

        private void Workout_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_MenuEN main_menuEN = new Main_MenuEN();
            main_menuEN.Show();
        }

        private void Workout_Load(object sender, EventArgs e)
        {
            label4.Text = restTimeLeft.ToString();
            // Initialize lblTimer based on the first exercise
            if (currentExercises != null && currentExercises.Count > 0)
            {
                ShowExercise(currentExercises[currentExerciseIndex]);
            }
            else
            {
                lblTimer.Text = "Start"; // Or any default value you prefer
            }
        }

        private void BtnSkipRest_Click(object sender, EventArgs e)
        {
            isResting = false;
            BtnSkipRest.Visible = false;
            SkipRestlbl.Visible = false;
            restTimer.Stop();
            lblTimer.Text = "";
            btnNextExercise.PerformClick();
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            HidePanel = !HidePanel;
            if (HidePanel == false)
            {
                label4.Visible = true;
                label5.Visible = true;
                Panel.Visible = true;
                RestTB.Visible = true;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                Panel.Visible = false;
                RestTB.Visible = false;
            }
        }

        private void RestTB_Scroll(object sender, ScrollEventArgs e)
        {
            restTimeLeft = RestTB.Value;
            label4.Text = RestTB.Value.ToString();
        }
    }
}