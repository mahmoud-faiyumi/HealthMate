using HealthMate_UI.Constants;
using HealthMate_UI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Controls.Primitives;
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
            exerciseTimer = new Timer { Interval = 1000 };
            exerciseTimer.Tick += ExerciseTimer_Tick;

            restTimer = new Timer { Interval = 1000 };
            restTimer.Tick += RestTimer_Tick;
        }

        private void StartExerciseTimer(int durationInSeconds)
        {
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                lblTimer.Text = durationInSeconds.ToString(); Unit.Text = "ثانية";
            }
            else
            {
                lblTimer.Text = durationInSeconds.ToString(); Unit.Text = "seconds";
            }
            exerciseTimer.Start();
        }

        private void InitializeMuscleGroupTabs()
        {
            MuscleGroupTab.TabPages.Clear();

            // Array of muscle groups in English and Arabic
            string[] muscleGroups = { "Warm-up", "Chest", "Legs", "Full Body", "Arms", "Core", "Shoulders", "Back" };
            foreach (var muscleGroup in muscleGroups)
            {
                AddMuscleGroupTab(muscleGroup);
            }
        }

        private void AddMuscleGroupTab(string muscleGroup)
        {
            // Choose the tab page title based on the user's language preference
            string tabPageTitle =  muscleGroup;

            // Create the tab page
            var tabPage = new TabPage(tabPageTitle);

            // Create the panel
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = CommonValues.CurrentUserInfo.IsDark ? Color.FromArgb(70, 70, 70) : Color.White
            };

            // Add the panel to the tab page
            tabPage.Controls.Add(panel);

            // Add the tab page to the tab control
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
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                tableLayout.Controls.Add(new Label { Text = "التمرين", Font = new Font("Arial", 10, FontStyle.Bold), Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
                tableLayout.Controls.Add(new Label { Text = "المدة", Font = new Font("Arial", 10, FontStyle.Bold), Anchor = AnchorStyles.Left, AutoSize = true }, 1, 0);
                tableLayout.Controls.Add(new Label { Text = "استعراض", Font = new Font("Arial", 10, FontStyle.Bold), Anchor = AnchorStyles.Left, AutoSize = true }, 2, 0);
            }
            else
            {
                tableLayout.Controls.Add(new Label { Text = "Exercise", Font = new Font("Arial", 10, FontStyle.Bold), Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
                tableLayout.Controls.Add(new Label { Text = "Duration", Font = new Font("Arial", 10, FontStyle.Bold), Anchor = AnchorStyles.Left, AutoSize = true }, 1, 0);
                tableLayout.Controls.Add(new Label { Text = "Preview", Font = new Font("Arial", 10, FontStyle.Bold), Anchor = AnchorStyles.Left, AutoSize = true }, 2, 0);
            }

            // Increment row count for each exercise
            var exercises = GetExercisesForCurrentLevel();
            int rowIndex = 1; // Start with 1 to skip header row
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                muscleGroup = TranslateMuscleGroupToArabic(muscleGroup);
            }
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

        private string TranslateMuscleGroupToArabic(string muscleGroup)
        {
            switch (muscleGroup)
            {
                case "الإحماء":
                    return "Warm-up";
                case "صدر":
                    return "Chest";
                case "أرجل":
                    return "Legs";
                case "كامل الجسم":
                    return "Full Body";
                case "ذراعين":
                    return "Arms";
                case "الجذع":
                    return "Core";
                case "أكتاف":
                    return "Shoulders";
                case "ظهر":
                    return "Back";
                default:
                    return muscleGroup; // Return original if no match
            }
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
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                lblTimer.Text = exercise.Duration.ToString(); Unit.Text = "ثانية";
            }
            else
            {
                lblTimer.Text = exercise.Duration.ToString(); Unit.Text = "seconds";
            }
            if (CommonValues.CurrentUserInfo.IsArabic == true)
            {
                label3.Text = "ابدأ التمرين";
                Descriptionlbl.RightToLeft = RightToLeft.Yes;
                Descriptionlbl.Text = exercise.DescriptionAr;
            }
            else
            {
                label3.Text = "Start";
                Descriptionlbl.Text = exercise.DescriptionEn;
            }
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
            string selectedLevel = LevelTab.SelectedTab.Text;

            // Dictionary to map level names to their corresponding exercise lists
            var levelMapping = new Dictionary<string, Func<List<Exercise>>>
            {
                { "Advanced", () => advancedExercises },
                { "متقدم", () => advancedExercises },
                { "Intermediate", () => intermediateExercises },
                { "متوسط", () => intermediateExercises },
                { "Beginner", () => beginnerExercises },
                { "مبتدئ", () => beginnerExercises }
            };

            // Return the corresponding exercise list based on the selected level
            return levelMapping.TryGetValue(selectedLevel, out var getExercises) ? getExercises() : beginnerExercises;
        }


        private void ExerciseTimer_Tick(object sender, EventArgs e)
        {
            if (int.TryParse(lblTimer.Text, out int timeLeft))
            {
                if (timeLeft > 0)
                {
                    if (CommonValues.CurrentUserInfo.IsArabic)
                    {
                        lblTimer.Text = (timeLeft - 1).ToString(); Unit.Text = "ثانية";
                    }
                    else
                    {
                        lblTimer.Text = (timeLeft - 1).ToString(); Unit.Text = "seconds";
                    }
                }
                else
                {
                    exerciseTimer.Stop();
                    if (!isResting)
                    {
                        // Start rest period
                        isResting = true;
                        if (CommonValues.CurrentUserInfo.IsArabic == true)
                        {
                            lblExerciseName.Text = "استراحة";
                        }
                        else
                        {
                            lblExerciseName.Text = "Rest";
                        }
                        // Initial rest timer value
                        if (CommonValues.CurrentUserInfo.IsArabic)
                        {
                            lblTimer.Text = restTimeLeft.ToString(); Unit.Text = "ثانية";
                        }
                        else
                        {
                            lblTimer.Text = restTimeLeft.ToString(); Unit.Text = "seconds";
                        }
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

                var nextExercise = muscleGroupExercises[selectedExerciseIndex];
                ShowExercise(nextExercise);

                // Start the timer for the next exercise
                btnPauseTimer.Image = Properties.Resources.pause;
                if (CommonValues.CurrentUserInfo.IsArabic == true)
                {
                    label3.Text = "إيقاف مؤقت";
                }
                else
                {
                    label3.Text = "Pause";
                }
                StartExerciseTimer(nextExercise.Duration);
            }
            else
            {
                MessageBox.Show("Workout complete!");
                if (CommonValues.CurrentUserInfo.IsArabic == true)
                {
                    label3.Text = "ابدأ التمرين";
                }
                else
                {
                    label3.Text = "Start";
                }
                btnPauseTimer.Image = Properties.Resources.play;

                // Reset currentExerciseIndex after completing the workout
                currentExerciseIndex = -1;
            }
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
                if (CommonValues.CurrentUserInfo.IsArabic == true)
                {
                    label3.Text = "إستمرار";
                }
                else
                {
                    label3.Text = "Resume";
                }
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
                if (CommonValues.CurrentUserInfo.IsArabic == true)
                {
                    label3.Text = "إيقاف مؤقت";
                }
                else
                {
                    label3.Text = "Pause";
                }
                btnPauseTimer.Image = Properties.Resources.pause;
            }
        }

        private Exercise GetSelectedExercise()
        {
            var selectedTab = MuscleGroupTab.SelectedTab;
            if (selectedTab != null)
            {
                var muscleGroup = selectedTab.Text;
                var exercises = GetExercisesForCurrentLevel().Where(ex => ex.MuscleGroups.Contains(muscleGroup)).ToList();
                if (selectedExerciseIndex >= 0 && selectedExerciseIndex < exercises.Count)
                {
                    return exercises[selectedExerciseIndex];
                }
            }
            return null;
        }

        private void btnOpenYouTube_Click(object sender, EventArgs e)
        {
            if (currentExercises != null && currentExercises.Count > 0 && currentExerciseIndex != -1)
            {
                var selectedExercise = GetSelectedExercise();
                if (selectedExercise != null)
                {
                    System.Diagnostics.Process.Start(selectedExercise.YouTubeLink);
                }
                else
                {
                    MessageBox.Show("No YouTube link available for the selected exercise.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                label4.Text = restTimeLeft.ToString(); Unit.Text = "ثانية";
            }
            else
            {
                label4.Text = restTimeLeft.ToString(); Unit.Text = "seconds";
            }
            // Initialize lblTimer based on the first exercise
            if (currentExercises != null && currentExercises.Count > 0)
            {
                ShowExercise(currentExercises[currentExerciseIndex]);
            }
            else
            {
                lblTimer.Text = "Start"; // Or any default value you prefer
            }
            if (CommonValues.CurrentUserInfo.IsDark == true)
            {
                ApplyDarkTheme();
            }
            if (CommonValues.CurrentUserInfo.IsArabic == true)
            {
                ArabicLanguage();
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

        private void RestTB_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            restTimeLeft = RestTB.Value;

            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                label4.Text = restTimeLeft.ToString();
                Unit.Text = "ثانية";
            }
            else
            {
                label4.Text = restTimeLeft.ToString();
                Unit.Text = "seconds";
            }
        }

        private void ArabicLanguage()
        {
            Backlbl.Text = "رجوع";
            label1.Text = "التالي";
            label2.Text = "يوتيوب";
            SkipRestlbl.Text = "تخطي الراحة";

            // Translate tab page headers
            foreach (TabPage tabPage in MuscleGroupTab.TabPages)
            {
                if (tabPage.Text == "Warm-up") tabPage.Text = "الإحماء";
                else if (tabPage.Text == "Chest") tabPage.Text = "صدر";
                else if (tabPage.Text == "Legs") tabPage.Text = "أرجل";
                else if (tabPage.Text == "Full Body") tabPage.Text = "كامل الجسم";
                else if (tabPage.Text == "Arms") tabPage.Text = "ذراعين";
                else if (tabPage.Text == "Core") tabPage.Text = "الجذع";
                else if (tabPage.Text == "Shoulders") tabPage.Text = "أكتاف";
                else if (tabPage.Text == "Back") tabPage.Text = "ظهر";
            }
            // Translate level tab headers
            foreach (TabPage tabPage in LevelTab.TabPages)
            {
                if (tabPage.Text == "Beginner") tabPage.Text = "مبتدئ";
                else if (tabPage.Text == "Intermediate") tabPage.Text = "متوسط";
                else if (tabPage.Text == "Advanced") tabPage.Text = "متقدم";
            }
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            Panel.BackColor = Color.DimGray;
        }
    }
}