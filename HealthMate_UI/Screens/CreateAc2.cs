using HealthMate_UI.Constants;
using LiteDB;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace HealthMate_UI
{
    public partial class CreateAc2 : Form
    {
        bool[] fieldEditedFlags = new bool[4]; // Create an array of boolean flags to track whether each field has been edited
        private bool passwordVisible = false;
        private bool passwordVisibleRE = false;
        private bool inches = true; // Initially set to inches
        private bool LB = true;  // Initially set to pounds

        private string fname;
        private string lname;
        private string email;
        private string username;
        private string gender;
        private DateTime birthdate;
        private string activityLevel;

        private DatabaseManagerui databaseManagerui;

        bool dark = CommonValues.CurrentUserInfo.IsDark;
        bool arabic = CommonValues.CurrentUserInfo.IsArabic;
        string filePath;
        public CreateAc2(string Fname, string Lname, string Email, string Username, string Gender, DateTime Birthdate, string ActivityLevel)
        {
            InitializeComponent();

            fname = Fname;
            lname = Lname;
            email = Email;
            username = Username;
            gender = Gender;
            birthdate = Birthdate;
            activityLevel = ActivityLevel;

            InitializeCircularPictureBox();
            progressBar1.Maximum = 11;

            for (byte i = 0; i < fieldEditedFlags.Length; i++)
            {
                fieldEditedFlags[i] = false; // Initialize all flags to false
            }

            UpdateCreateAccbtnState();

            databaseManagerui = new DatabaseManagerui();

            Password.PasswordChar = '*';
            RePassword.PasswordChar = '*';

            // Set the initial image
            PasswordVisibility.BackgroundImage = Properties.Resources.hide_eye; // Use your initial image here
            PasswordVisibility.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
            PasswordVisibilityRE.BackgroundImage = Properties.Resources.hide_eye; // Use your initial image here
            PasswordVisibilityRE.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
            InchesToCm.BackgroundImage = Properties.Resources.inches_01; // Use the CM image
            InchesToCm.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
            KGToLB.BackgroundImage = Properties.Resources.LB_01; // Use the LB image
            KGToLB.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch

            PINcode.Visible = false;
            PINcode.MaxLength = 6;
        }

        private void InitializeCircularPictureBox()
        {
            circularPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Load Image
            if (gender == "Male" || gender == "ذكر")
            {
                circularPictureBox.Image = Properties.Resources.malePP;
            }
            else
            {
                circularPictureBox.Image = Properties.Resources.femalePP;
            }
        }

        private void CreateAc2EN_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 7;
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
            label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
        }

        private void InchesToCm_Click(object sender, EventArgs e)
        {
            inches = !inches;

            if (inches)
            {
                InchesToCm.Image = Properties.Resources.inches_01; // Use the Inches image
            }
            else
            {
                InchesToCm.Image = Properties.Resources.CM_01; // Use the CM image
            }
            // Set the image layout to stretch within the button
            InchesToCm.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void KGToLB_Click(object sender, EventArgs e)
        {
            LB = !LB;

            if (LB)
            {
                KGToLB.Image = Properties.Resources.LB_01; // Use the LB image
            }
            else
            {
                KGToLB.Image = Properties.Resources.KG_01; // Use the KG image
            }
            // Set the image layout to stretch within the button
            KGToLB.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void CreateAccbtn_Click(object sender, EventArgs e)
        {
            string password = Password.Text;
            string confirmPassword = RePassword.Text;

            if (password != confirmPassword)
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    MessageBox.Show("كلمات المرور غير متطابقة. يرجى المحاولة مرة أخرى.", "تحقق من كلمة المرور", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("The passwords do not match. Please try again.", "Password Validation", MessageBoxButtons.OK);
                }
                Password.Clear();
                RePassword.Clear();
                return; // Don't proceed if passwords don't match
            }

            // The passwords match, so you can proceed to account creation
            string encryptionKey = "hTbHfq5rC5dAby6DJt8P3w==";
            string initializationVector = "6mRwZNlJb/WLbCyk4n+bBg==";

            var encryptionService = new EncryptionService(encryptionKey, initializationVector);

            string plainText1 = Password.Text;
            string encryptedText1 = encryptionService.Encrypt(plainText1);

            DateTime now = DateTime.Now;
            TimeSpan ageTimeSpan = now - birthdate;
            int Age = (int)Math.Floor(ageTimeSpan.TotalDays / 365.242199);

            double height, weight;

            if (!double.TryParse(Height_cm.Text, out height) || !double.TryParse(Weight.Text, out weight))
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    MessageBox.Show("الرجاء إدخال طول ووزن صحيحين.", "خطأ في التحقق", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Please enter valid height and weight.", "Validation Error", MessageBoxButtons.OK);
                }
                Height_cm.Clear();
                Weight.Clear();
                return; // Don't proceed if height or weight is not valid
            }

            height = HeightConverter.ConvertHeight(height, inches); // Convert the height based on the 'inches' flag
            weight = WeightConverter.ConvertWeight(weight, LB); // Convert the height based on the 'LB' flag

            // Calculate BMI
            double BMI = Math.Round(weight / Math.Pow(height / 100.0, 2), 1);

            bool coach = false;
            if (TrainerCheck.Checked)
            {
                if (PINcode.Text != "112255")
                {
                    if (CommonValues.CurrentUserInfo.IsArabic)
                    {
                        MessageBox.Show("رمز PIN غير صحيح.", "خطأ في التحقق", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Invalid PIN code.", "Validation Error", MessageBoxButtons.OK);
                    }
                    PINcode.Clear();
                    return; // Don't proceed if height or weight is not valid
                }
                else
                {
                    coach = true;
                }
            }
            try
            {
                string fileName = Path.GetFileName(filePath);
                byte[] fileData = null; // Initialize to null
                databaseManagerui.OpenConnection();

                // Insert user data into the database
                string insertQuery = "INSERT INTO UserInfo (FName, LName, Email, UserName, Password, BirthDate, Gender, Height, Weight, ActivityLevel, BMI, ProfilePicture, LastLogin, IsCoach) " +
                                     "VALUES (@Fname, @Lname, @Email, @UserName, @Password, @BirthDate, @gender, @Height, @Weight, @activityLevel, @BMI, @ProfilePicture, @LastLogin, @IsCoach)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, databaseManagerui.GetConnection()))
                {
                    insertCommand.Parameters.AddWithValue("@Fname", fname);
                    insertCommand.Parameters.AddWithValue("@Lname", lname);
                    insertCommand.Parameters.AddWithValue("@Email", email);
                    insertCommand.Parameters.AddWithValue("@UserName", username);
                    insertCommand.Parameters.AddWithValue("@Password", encryptedText1);
                    insertCommand.Parameters.AddWithValue("@BirthDate", birthdate);
                    insertCommand.Parameters.AddWithValue("@gender", gender);
                    insertCommand.Parameters.AddWithValue("@Height", height);
                    insertCommand.Parameters.AddWithValue("@Weight", weight);
                    insertCommand.Parameters.AddWithValue("@activityLevel", activityLevel);
                    insertCommand.Parameters.AddWithValue("@BMI", BMI);

                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        fileData = File.ReadAllBytes(filePath);
                    }
                    else
                    {
                        if (gender == "Male" || gender == "ذكر")
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                Properties.Resources.malePP.Save(ms, Properties.Resources.malePP.RawFormat);
                                fileData = ms.ToArray();
                            }
                        }
                        else
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                Properties.Resources.femalePP.Save(ms, Properties.Resources.femalePP.RawFormat);
                                fileData = ms.ToArray();
                            }
                        }
                    }
                    insertCommand.Parameters.AddWithValue("@ProfilePicture", fileData);

                    insertCommand.Parameters.AddWithValue("@LastLogin", DateTime.Today);
                    insertCommand.Parameters.AddWithValue("@IsCoach", coach ? 1 : 0);


                    insertCommand.ExecuteNonQuery();
                }
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    MessageBox.Show("تم إنشاء الحساب بنجاح", "نجاح", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Account created successfully", "Success", MessageBoxButtons.OK);
                }

                // Proceed to the next form
                this.Hide();
                Login loginEN = new Login();
                loginEN.Show();


                string updateQuery = "UPDATE UserPreferences SET IsDark = @IsDark WHERE UserName_FK = @Username";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, databaseManagerui.GetConnection()))
                {
                    updateCommand.Parameters.AddWithValue("@IsDark", dark ? 1 : 0);
                    updateCommand.Parameters.AddWithValue("@Username", username);

                    updateCommand.ExecuteNonQuery();
                }

                string updateQuery1 = "UPDATE UserPreferences SET IsArabic = @IsArabic WHERE UserName_FK = @Username";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery1, databaseManagerui.GetConnection()))
                {
                    updateCommand.Parameters.AddWithValue("@IsArabic", arabic ? 1 : 0);
                    updateCommand.Parameters.AddWithValue("@Username", username);

                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                databaseManagerui.CloseConnection();
            }

            try
            {
                // Create an instance of DatabaseManageruc
                using (DatabaseManageruc databaseManager = new DatabaseManageruc())
                {
                    // Open the database connection
                    databaseManager.OpenConnection();

                    // SQL query to create the table
                    string createTableQuery = $@"CREATE TABLE [{username}] (
                   [Date] DATE NOT NULL,
                   [BreakfastCal] FLOAT DEFAULT 0 NOT NULL,
                   [LunchCal] FLOAT DEFAULT 0 NOT NULL,
                   [DinnerCal] FLOAT DEFAULT 0 NOT NULL,
                   [ExtraCal] FLOAT DEFAULT 0 NOT NULL,
                   [TotalCal] AS (BreakfastCal + LunchCal + DinnerCal + ExtraCal))";

                    // Create a SqlCommand object with the create table query and the SqlConnection object
                    using (SqlCommand createCommand = new SqlCommand(createTableQuery, databaseManager.GetConnection()))
                    {
                        // Execute the create table query
                        createCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Password.Text) && !fieldEditedFlags[0])
            {
                progressBar1.Value++;
                fieldEditedFlags[0] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateCreateAccbtnState();

            string password = Password.Text;
            string confirmPassword = RePassword.Text;

            // Check if the password is empty or null
            if (string.IsNullOrWhiteSpace(password))
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    PasswordStrengthLabel.Text = "قوة كلمة المرور: غير معروف";
                    PasswordStrengthLabel.ForeColor = Color.Black;
                    return;
                }
                else
                {
                    PasswordStrengthLabel.Text = "Password Strength: N/A";
                    PasswordStrengthLabel.ForeColor = Color.Black;
                    return;
                }
            }
            if (password != confirmPassword)
            {
                if (!string.IsNullOrWhiteSpace(RePassword.Text))
                {
                    if (CommonValues.CurrentUserInfo.IsArabic)
                    {
                        PasswordMatchLabel.Text = "كلمة المرور غير متطابقة!";
                    }
                    else
                    {
                        PasswordMatchLabel.Text = "Passwords do not match!";
                    }
                }
            }
            else
            {
                PasswordMatchLabel.Text = "";
            }

            var result = Zxcvbn.Core.EvaluatePassword(password);

            byte strength = (byte)result.Score; // Zxcvbn's password strength score (0-4)

            // Combine Zxcvbn's suggestions into a single string
            //string suggestions = string.Join(". ", result.Feedback.Suggestions);

            // Set text color and strength level based on strength score
            string strengthMessage;
            Color strengthColor;

            if (!CommonValues.CurrentUserInfo.IsArabic)
            {
                switch (strength)
                {
                    case 0:
                        if (!CommonValues.CurrentUserInfo.IsDark)
                        {
                            strengthMessage = "Very Weak";
                            strengthColor = Color.DarkRed;
                        }
                        else
                        {
                            strengthMessage = "Very Weak";
                            strengthColor = Color.Red;
                        }
                        break;
                    case 1:
                        strengthMessage = "Weak";
                        strengthColor = Color.OrangeRed;
                        break;
                    case 2:
                        strengthMessage = "Moderate";
                        strengthColor = Color.Orange;
                        break;
                    case 3:
                        strengthMessage = "Strong";
                        strengthColor = Color.LightGreen;
                        break;
                    case 4:
                        if (!CommonValues.CurrentUserInfo.IsDark)
                        {
                            strengthMessage = "Very Strong";
                            strengthColor = Color.Blue;
                        }
                        else
                        {
                            strengthMessage = "Very Strong";
                            strengthColor = Color.Cyan;
                        }
                        break;
                    default:
                        strengthMessage = "";
                        strengthColor = Color.Black;
                        break;
                }

                PasswordStrengthLabel.Text = $"Password Strength: {strengthMessage}";
                PasswordStrengthLabel.ForeColor = strengthColor;
            }
            else
            {
                switch (strength)
                {
                    case 0:
                        if (!CommonValues.CurrentUserInfo.IsDark)
                        {
                            strengthMessage = "ضعيفة جداً";
                            strengthColor = Color.DarkRed;
                        }
                        else
                        {
                            strengthMessage = "ضعيفة جداً";
                            strengthColor = Color.Red;
                        }
                        break;
                    case 1:
                        strengthMessage = "ضعيفة";
                        strengthColor = Color.OrangeRed;
                        break;
                    case 2:
                        strengthMessage = "متوسطة";
                        strengthColor = Color.Orange;
                        break;
                    case 3:
                        strengthMessage = "قوية";
                        strengthColor = Color.LightGreen;
                        break;
                    case 4:
                        if (!CommonValues.CurrentUserInfo.IsDark)
                        {
                            strengthMessage = "قوية جداً";
                            strengthColor = Color.Blue;
                        }
                        else
                        {
                            strengthMessage = "قوية جداً";
                            strengthColor = Color.Cyan;
                        }
                        break;
                    default:
                        strengthMessage = "";
                        strengthColor = Color.Black;
                        break;
                }

                PasswordStrengthLabel.Text = $"قوة كلمة المرور: {strengthMessage}";
                PasswordStrengthLabel.ForeColor = strengthColor;
            }
        }

        private void RePassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RePassword.Text) && !fieldEditedFlags[1])
            {
                progressBar1.Value++;
                fieldEditedFlags[1] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateCreateAccbtnState();

            string password = Password.Text;
            string confirmPassword = RePassword.Text;

            if (password != confirmPassword)
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    PasswordMatchLabel.Text = "كلمة المرور غير متطابقة!";
                }
                else
                {
                    PasswordMatchLabel.Text = "Passwords do not match!";
                }
            }
            else
            {
                PasswordMatchLabel.Text = "";
            }
        }

        private void Height_cm_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Height_cm.Text) && !fieldEditedFlags[2])
            {
                progressBar1.Value++;
                fieldEditedFlags[2] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateCreateAccbtnState();
        }

        private void Weight_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Weight.Text) && !fieldEditedFlags[3])
            {
                progressBar1.Value++;
                fieldEditedFlags[3] = true;
                label1.Text = progressBar1.ProgressTotalPercent.ToString("N0") + "%";
            }

            UpdateCreateAccbtnState();
        }

        private void CreateAc2EN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateCreateAccbtnState()
        {
            CreateAccbtn.Enabled = progressBar1.Value >= 11;
        }

        private void PasswordVisibilityRE_Click(object sender, EventArgs e)
        {
            // Toggle password visibility
            passwordVisibleRE = !passwordVisibleRE;
            RePassword.PasswordChar = passwordVisibleRE ? '\0' : '*';

            // Change the eye icon
            if (passwordVisibleRE)
            {
                PasswordVisibilityRE.Image = Properties.Resources.show_eye; // Use the open eye image
            }
            else
            {
                PasswordVisibilityRE.Image = Properties.Resources.hide_eye; // Use the closed eye image
            }
            // Set the image layout to stretch within the button
            PasswordVisibilityRE.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void PasswordVisibility_Click(object sender, EventArgs e)
        {
            // Toggle password visibility
            passwordVisible = !passwordVisible;
            Password.PasswordChar = passwordVisible ? '\0' : '*';

            // Change the eye icon
            if (passwordVisible)
            {
                PasswordVisibility.Image = Properties.Resources.show_eye; // Use the open eye image
            }
            else
            {
                PasswordVisibility.Image = Properties.Resources.hide_eye; // Use the closed eye image
            }
            // Set the image layout to stretch within the button
            PasswordVisibility.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAc1 createAc1EN = new CreateAc1();
            createAc1EN.Show();
        }

        private void ApplyDarkTheme()
        {
            // Apply the dark theme
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            Height_cm.ForeColor = Color.Black;
            Height_cm.FillColor = Color.FromArgb(224, 224, 224);
            Weight.ForeColor = Color.Black;
            Weight.FillColor = Color.FromArgb(224, 224, 224);
            Password.FillColor = Color.FromArgb(224, 224, 224);
            Password.ForeColor = Color.Black;
            RePassword.FillColor = Color.FromArgb(224, 224, 224);
            RePassword.ForeColor = Color.Black;
            PasswordMatchLabel.ForeColor = Color.FromArgb(255, 128, 128);
            Back.ForeColor = Color.White;
            Back.Image = Properties.Resources.WBack;
            BrowseButton.ForeColor = Color.Black;
            BrowseButton.FillColor = Color.FromArgb(224, 224, 224);
        }

        private void ApplyLightTheme()
        {
            // Apply the light theme
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            Height_cm.ForeColor = Color.Black;
            Height_cm.FillColor = Color.White;
            Weight.ForeColor = Color.Black;
            Weight.FillColor = Color.White;
            Password.FillColor = Color.White;
            Password.ForeColor = Color.Black;
            RePassword.FillColor = Color.White;
            RePassword.ForeColor = Color.Black;
            PasswordMatchLabel.ForeColor = Color.Red;
            Back.ForeColor = Color.Black;
            Back.Image = Properties.Resources.Back;
            BrowseButton.ForeColor = Color.Black;
            BrowseButton.FillColor = Color.White;
        }

        private void ArabicLanguage()
        {
            base.RightToLeft = RightToLeft.Yes;
            HeightLable.Location = new Point(200, 48);
            HeightLable.Text = "الطول:";
            Height_cm.Location = new Point(51, 76);
            InchesToCm.Location = new Point(51, 76);
            WeightLable.Location = new Point(510, 48);
            WeightLable.Text = "الوزن:";
            Weight.Location = new Point(355, 76);
            KGToLB.Location = new Point(355, 76);
            PassLabel.Text = "إختر كلمة مرور:";
            PassLabel.Location = new Point(152, 136);
            Password.Location = new Point(51, 164);
            PasswordVisibility.Location = new Point(51, 164);
            RePassLabel.Text = "أعد إدخال كلمة المرور:";
            RePassLabel.Location = new Point(404, 136);
            RePassword.Location = new Point(355, 164);
            PasswordVisibilityRE.Location = new Point(355, 164);
            CreateAccbtn.Text = "انشاء الحساب";
            BrowseButton.Text = "تصفّح";
            ChangePPlabel.Text = "  إختر صورتك الشخصية  ";
            TrainerCheck.Text = "هل أنت مدرّب معتمد؟";
            TrainerCheck.RightToLeft = RightToLeft.No;
            Backlbl.Text = "رجوع";
        }

        private void EnglishLanguage()
        {
            base.RightToLeft = RightToLeft.No;
            HeightLable.Location = new Point(46, 48);
            HeightLable.Text = "Height:";
            Height_cm.Location = new Point(51, 76);
            InchesToCm.Location = new Point(222, 76);
            WeightLable.Location = new Point(350, 48);
            WeightLable.Text = "Weight:";
            Weight.Location = new Point(355, 76);
            KGToLB.Location = new Point(526, 76);
            PassLabel.Text = "Password:";
            PassLabel.Location = new Point(46, 136);
            Password.Location = new Point(51, 164);
            PasswordVisibility.Location = new Point(222, 164);
            RePassLabel.Text = "Re-Enter Password:";
            RePassLabel.Location = new Point(350, 136);
            RePassword.Location = new Point(355, 164);
            PasswordVisibilityRE.Location = new Point(526, 164);
            CreateAccbtn.Text = "Create an account";
            BrowseButton.Text = "Browse";
            ChangePPlabel.Text = "Choose profile picture";
            TrainerCheck.Text = "Are you a trainer?";
            Backlbl.Text = "Back";
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    filePath = selectedFilePath;

                    // Convert the image file to a byte array
                    byte[] fileData = File.ReadAllBytes(filePath);

                    // Convert the byte array to an Image object
                    using (MemoryStream ms = new MemoryStream(fileData))
                    {
                        Image image = Image.FromStream(ms);
                        circularPictureBox.Image = image;
                    }
                }
            }
        }

        private void PINcode_Enter(object sender, EventArgs e)
        {
            if (!(PINcode.Text.Length <= 6))
            {
                PINcode.Text = string.Empty;
            }
        }

        private void PINcode_Leave(object sender, EventArgs e)
        {
            if (!(PINcode.Text.Length <= 6 && PINcode.Text.Length != 0))
            {
                if (arabic)
                {
                    PINcode.Text = "أدخل رمز PIN";
                }
                else
                {
                    PINcode.Text = "Enter PIN Code";
                }
            }
        }

        private void TrainerCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (TrainerCheck.Checked)
            {
                PINcode.Visible = true;
                if (arabic)
                {
                    PINcode.Text = "أدخل رمز PIN";
                }
                else
                {
                    PINcode.Text = "Enter PIN Code";
                }
            }
            else
            {
                PINcode.Visible = false;
            }
        }

        private void PINcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not a digit or control key, suppress the key press
                e.Handled = true;
            }
        }
    }
}