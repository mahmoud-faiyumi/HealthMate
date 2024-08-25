using HealthMate_UI.Constants;
using HealthMate_UI.Models;
using HealthMate_UI.Screens;
using ImageRetrievalApp;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace HealthMate_UI
{
    public partial class UpdateInfo : Form
    {
        private bool passwordVisible = false;
        private bool passwordVisibleRE = false;
        private bool inches = true; // Initially set to inches
        private bool LB = true;  // Initially set to pounds
        private DatabaseManagerui databaseManager;
        string username = CommonValues.CurrentUserInfo.UserName;

        string filePath;
        public UpdateInfo()
        {
            InitializeComponent();
            InitializeCircularPictureBox();
            databaseManager = new DatabaseManagerui();

            Password.PasswordChar = '*';
            RePassword.PasswordChar = '*';

            // Set the initial image
            PasswordVisibility.Image = Properties.Resources.hide_eye; // Use your initial image here
            PasswordVisibility.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
            PasswordVisibilityRE.Image = Properties.Resources.hide_eye; // Use your initial image here
            PasswordVisibilityRE.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
            InchesToCm.Image = Properties.Resources.inches_01; // Use the CM image
            InchesToCm.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
            KGToLB.Image = Properties.Resources.LB_01; // Use the LB image
            KGToLB.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
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

        private void UpdateInfo_Load(object sender, EventArgs e)
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

        private void UpdateInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void PasswordVisibilityBtn_Click(object sender, EventArgs e)
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

        private void PasswordVisibilityREBtn_Click(object sender, EventArgs e)
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

        private void Password_TextChanged(object sender, EventArgs e)
        {
            string password = Password.Text;

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

            var result = Zxcvbn.Core.EvaluatePassword(password);

            byte strength = (byte)result.Score; // Zxcvbn's password strength score (0-4)

            // Combine Zxcvbn's suggestions into a single string
            string suggestions = string.Join(". ", result.Feedback.Suggestions);

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
            string password = Password.Text;
            string confirmPassword = RePassword.Text;

            if (!CommonValues.CurrentUserInfo.IsArabic)
            {
                if (password != confirmPassword)
                {
                    // Passwords do not match
                    PasswordMatchLabel.Text = "Passwords do not match!";
                }
                else
                {
                    PasswordMatchLabel.Text = "";
                }
            }
            else
            {
                if (password != confirmPassword)
                {
                    // Passwords do not match
                    PasswordMatchLabel.Text = "كلمة المرور غير متطابقة";
                }
                else
                {
                    PasswordMatchLabel.Text = "";
                }
            }
        }

        private void UpdateUser()
        {
            string OldUser = CommonValues.CurrentUserInfo.UserName;
            string NewUser = "";
            try
            {
                databaseManager.OpenConnection();
                string updateQuery = "UPDATE UserInfo SET ";
                string comma = "";
                // Initialize a counter for updated fields
                byte updatedFieldsCount = 0;

                using (SqlCommand command1 = new SqlCommand("", databaseManager.GetConnection()))
                {
                    if (!string.IsNullOrWhiteSpace(Fname.Text))
                    {
                        updateQuery += comma + "FName = @NewValue1";
                        command1.Parameters.AddWithValue("@NewValue1", Fname.Text);
                        comma = ", ";
                        updatedFieldsCount++;
                    }

                    if (!string.IsNullOrWhiteSpace(Lname.Text))
                    {
                        updateQuery += comma + "LName = @NewValue2";
                        command1.Parameters.AddWithValue("@NewValue2", Lname.Text);
                        comma = ", ";
                        updatedFieldsCount++;
                    }

                    if (!string.IsNullOrWhiteSpace(Username.Text))
                    {
                        updateQuery += comma + "UserName = @NewValue3";
                        command1.Parameters.AddWithValue("@NewValue3", Username.Text);
                        comma = ", ";
                        updatedFieldsCount++;
                        NewUser = Username.Text;
                    }

                    if (!string.IsNullOrWhiteSpace(ActivityLevel.Text))
                    {
                        updateQuery += comma + "ActivityLevel = @NewValue4";
                        command1.Parameters.AddWithValue("@NewValue4", Translator.TranslateActivityLevel(ActivityLevel.Text));
                        comma = ", ";
                        updatedFieldsCount++;
                    }

                    if (!string.IsNullOrWhiteSpace(Email.Text))
                    {
                        updateQuery += comma + "Email = @NewValue5";
                        command1.Parameters.AddWithValue("@NewValue5", Email.Text);
                        comma = ", ";
                        updatedFieldsCount++;
                    }

                    if (double.TryParse(Weight.Text, out double weightValue))
                    {
                        weightValue = WeightConverter.ConvertWeight(weightValue, LB);
                        updateQuery += comma + "Weight = @NewValue6";
                        command1.Parameters.AddWithValue("@NewValue6", weightValue.ToString());
                        comma = ", ";
                        updatedFieldsCount++;
                    }

                    if (double.TryParse(Height_cm.Text, out double heightValue))
                    {
                        heightValue = HeightConverter.ConvertHeight(heightValue, inches);
                        updateQuery += comma + "Height = @NewValue7";
                        command1.Parameters.AddWithValue("@NewValue7", heightValue.ToString());
                        comma = ", ";
                        updatedFieldsCount++;
                    }

                    if (!string.IsNullOrWhiteSpace(Password.Text))
                    {
                        string encryptionKey1 = "hTbHfq5rC5dAby6DJt8P3w==";
                        string initializationVector1 = "6mRwZNlJb/WLbCyk4n+bBg==";

                        var encryptionService1 = new EncryptionService(encryptionKey1, initializationVector1);

                        string plainText = Password.Text;
                        string encryptedText = encryptionService1.Encrypt(plainText); updateQuery += comma + "Password = @NewValue8";
                        command1.Parameters.AddWithValue("@NewValue8", encryptedText);
                        updatedFieldsCount++;
                    }

                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        string fileName = Path.GetFileName(filePath);

                        byte[] fileData = File.ReadAllBytes(filePath);
                        updateQuery += comma + "ProfilePicture = @NewValue9";
                        command1.Parameters.AddWithValue("@NewValue9", fileData);
                        comma = ", ";
                        updatedFieldsCount++;
                    }

                    // Add the common part of the SQL query
                    updateQuery += " WHERE UserName = @Username";
                    command1.Parameters.AddWithValue("@Username", username);
                    command1.CommandText = updateQuery;

                    command1.ExecuteNonQuery();

                    // Check how many rows were updated
                    if (updatedFieldsCount > 0)
                    {
                        MessageBox.Show(updatedFieldsCount + " rows updated.", "Update Success", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("No rows updated.", "Update Result", MessageBoxButtons.OK);
                    }
                }

                string readQuery = "SELECT * FROM UserInfo WHERE UserName = @Username";

                using (SqlCommand command = new SqlCommand(readQuery, databaseManager.GetConnection()))
                {
                    if (NewUser == "")
                    {
                        command.Parameters.AddWithValue("@Username", CommonValues.CurrentUserInfo.UserName);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Username", NewUser);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CommonValues.CurrentUserInfo.FName = reader["FName"].ToString();
                            CommonValues.CurrentUserInfo.LName = reader["LName"].ToString();
                            if (!(NewUser == ""))
                            {
                                CommonValues.CurrentUserInfo.UserName = reader["UserName"].ToString();
                            }
                            CommonValues.CurrentUserInfo.BirthDate = (DateTime)reader["BirthDate"];
                            CommonValues.CurrentUserInfo.ActivityLevel = reader["ActivityLevel"].ToString();
                            CommonValues.CurrentUserInfo.Age = (int)reader["Age"];
                            CommonValues.CurrentUserInfo.Height = (double)reader["Height"];
                            CommonValues.CurrentUserInfo.Weight = (double)reader["Weight"];
                            CommonValues.CurrentUserInfo.PasswordFromDB = reader["Password"].ToString();
                            object profilePictureValue = reader["ProfilePicture"];

                            byte[] imageData = (byte[])reader["ProfilePicture"];
                            Image image = ImageUtils.ByteArrayToImage(imageData);
                            CommonValues.CurrentUserInfo.PP = image;
                            CommonValues.CurrentUserInfo.IsPPNull = true;
                        }
                    }
                }
                // Calculate BMI
                double BMI = Math.Round(CommonValues.CurrentUserInfo.Weight / Math.Pow(CommonValues.CurrentUserInfo.Height / 100.0, 2), 1);
                string updateQuery1 = "UPDATE UserInfo SET BMI = @BMI";
                using (SqlCommand command2 = new SqlCommand("", databaseManager.GetConnection()))
                {
                    command2.Parameters.AddWithValue("@BMI", BMI);
                    command2.CommandText = updateQuery1;
                    command2.ExecuteNonQuery();
                }
                string readQuery1 = "SELECT BMI FROM UserInfo WHERE UserName = @Username";
                using (SqlCommand command = new SqlCommand(readQuery1, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Username", CommonValues.CurrentUserInfo.UserName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CommonValues.CurrentUserInfo.BMI = (double)reader["BMI"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                databaseManager.CloseConnection();
            }
            if (CommonValues.CurrentUserInfo.UserName != OldUser)
            {
                try
                {
                    using (DatabaseManageruc databaseManager = new DatabaseManageruc())
                    {
                        databaseManager.OpenConnection();

                        // Username variable
                        string oldTableName = OldUser;
                        string newTableName = CommonValues.CurrentUserInfo.UserName;

                        // SQL query to rename the table
                        string renameTableQuery = $"EXEC sp_rename '{oldTableName}', '{newTableName}'";

                        using (SqlCommand renameCommand = new SqlCommand(renameTableQuery, databaseManager.GetConnection()))
                        {
                            renameCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateUsrInfo_Click(object sender, EventArgs e)
        {
            if (!CommonValues.CurrentUserInfo.IsArabic)
            {
                if (string.IsNullOrWhiteSpace(Fname.Text) &&
    string.IsNullOrWhiteSpace(Lname.Text) &&
    string.IsNullOrWhiteSpace(Username.Text) &&
    string.IsNullOrWhiteSpace(ActivityLevel.Text) &&
    string.IsNullOrWhiteSpace(Email.Text) &&
    string.IsNullOrWhiteSpace(Weight.Text) &&
    string.IsNullOrWhiteSpace(Height_cm.Text) &&
    string.IsNullOrWhiteSpace(Password.Text) &&
    string.IsNullOrWhiteSpace(RePassword.Text) &&
    string.IsNullOrWhiteSpace(filePath))
                {
                    MessageBox.Show("Please fill in at least one field.", "Validation Error", MessageBoxButtons.OK);
                    return;
                }

                string password = Password.Text;
                string confirmPassword = RePassword.Text;

                if (password != confirmPassword)
                {
                    MessageBox.Show("The passwords do not match. Please try again.", "Password Validation", MessageBoxButtons.OK);
                    Password.Clear();
                    RePassword.Clear();
                    return;
                }

                double height, weight;

                if (!string.IsNullOrWhiteSpace(Weight.Text) && !double.TryParse(Weight.Text, out weight))
                {
                    MessageBox.Show("Please enter a valid numeric weight.", "Validation Error", MessageBoxButtons.OK);
                    Weight.Clear();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(Height_cm.Text) && !double.TryParse(Height_cm.Text, out height))
                {
                    MessageBox.Show("Please enter a valid numeric height.", "Validation Error", MessageBoxButtons.OK);
                    Height_cm.Clear();
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Fname.Text) &&
    string.IsNullOrWhiteSpace(Lname.Text) &&
    string.IsNullOrWhiteSpace(Username.Text) &&
    string.IsNullOrWhiteSpace(ActivityLevel.Text) &&
    string.IsNullOrWhiteSpace(Email.Text) &&
    string.IsNullOrWhiteSpace(Weight.Text) &&
    string.IsNullOrWhiteSpace(Height_cm.Text) &&
    string.IsNullOrWhiteSpace(Password.Text) &&
    string.IsNullOrWhiteSpace(RePassword.Text) &&
    string.IsNullOrWhiteSpace(filePath))
                {
                    MessageBox.Show("يرجى ملء حقل واحد على الأقل.", "خطأ في التحقق", MessageBoxButtons.OK);
                    return;
                }

                string password = Password.Text;
                string confirmPassword = RePassword.Text;

                if (password != confirmPassword)
                {
                    MessageBox.Show("كلمات المرور غير متطابقة. يرجى المحاولة مرة أخرى.", "التحقق من كلمة المرور", MessageBoxButtons.OK);
                    Password.Clear();
                    RePassword.Clear();
                    return;
                }

                double height, weight;

                if (!string.IsNullOrWhiteSpace(Weight.Text) && !double.TryParse(Weight.Text, out weight))
                {
                    MessageBox.Show("الرجاء إدخال قيمة وزن رقمية.", "تحقق من قيمة الوزن", MessageBoxButtons.OK);
                    Weight.Clear();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(Height_cm.Text) && !double.TryParse(Height_cm.Text, out height))
                {
                    MessageBox.Show("الرجاء إدخال قيمة طول رقمية.", "تحقق من قيمة الطول", MessageBoxButtons.OK);
                    Height_cm.Clear();
                    return;
                }

            }

            // If at least one field has data, proceed with the rest of the logic
            UpdateUser();
            Fname.Clear();
            Lname.Clear();
            Username.Clear();
            ActivityLevel.Text = "";
            Email.Clear();
            Weight.Clear();
            Height_cm.Clear();
            Password.Clear();
            RePassword.Clear();
            filePath = "";
            PasswordMatchLabel.Text = "";
            PasswordStrengthLabel.Text = "";
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_MenuEN main_menuEN = new Main_MenuEN();
            main_menuEN.Show();
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            Username.ForeColor = Color.Black;
            Username.FillColor = Color.FromArgb(224, 224, 224);
            Password.ForeColor = Color.Black;
            Password.FillColor = Color.FromArgb(224, 224, 224);
            RePassword.ForeColor = Color.Black;
            RePassword.FillColor = Color.FromArgb(224, 224, 224);
            Email.ForeColor = Color.Black;
            Email.FillColor = Color.FromArgb(224, 224, 224);
            Weight.ForeColor = Color.Black;
            Weight.FillColor = Color.FromArgb(224, 224, 224);
            Height_cm.ForeColor = Color.Black;
            Height_cm.FillColor = Color.FromArgb(224, 224, 224);
            Fname.ForeColor = Color.Black;
            Fname.FillColor = Color.FromArgb(224, 224, 224);
            Lname.ForeColor = Color.Black;
            Lname.FillColor = Color.FromArgb(224, 224, 224);
            ActivityLevel.ForeColor = Color.Black;
            ActivityLevel.FillColor = Color.FromArgb(224, 224, 224);
            Back.Image = Properties.Resources.WBack;
            BrowseButton.ForeColor = Color.Black;
            BrowseButton.FillColor = Color.FromArgb(224, 224, 224);
        }

        private void ApplyLightTheme()    
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            Username.ForeColor = Color.Black;
            Username.FillColor = Color.White;
            Password.ForeColor = Color.Black;
            Password.FillColor = Color.White;
            RePassword.ForeColor = Color.Black;
            RePassword.FillColor = Color.White;
            Email.ForeColor = Color.Black;
            Email.FillColor = Color.White;
            Weight.ForeColor = Color.Black;
            Weight.FillColor = Color.White;
            Height_cm.ForeColor = Color.Black;
            Height_cm.FillColor = Color.White;
            Fname.ForeColor = Color.Black;
            Fname.FillColor = Color.White;
            Lname.ForeColor = Color.Black;
            Lname.FillColor = Color.White;
            ActivityLevel.ForeColor = Color.Black;
            ActivityLevel.FillColor = Color.White;
            Back.Image = Properties.Resources.Back;
            BrowseButton.ForeColor = Color.Black;
            BrowseButton.FillColor = Color.White;
        }

        private void ArabicLanguage()
        {
            base.RightToLeft = RightToLeft.Yes;
            ActivityLevel.Items.Add("كسول");
            ActivityLevel.Items.Add("خفيف");
            ActivityLevel.Items.Add("متوسط");
            ActivityLevel.Items.Add("نشيط");
            FnameLable.Text = "الإسم الأول:";
            FnameLable.Location = new Point(487, 61);
            Fname.Location = new Point(454, 89);
            LnameLable.Text = "الإسم الأخير:";
            LnameLable.Location = new Point(184, 61);
            Lname.Location = new Point(153, 89);
            UsernameLabel.Text = "إسم المستخدم:";
            UsernameLabel.Location = new Point(316, 61);
            Username.Location = new Point(298, 89);
            ActivityLabel.Text = "مستوى النشاط:";
            ActivityLabel.Location = new Point(20, 61);
            ActivityLevel.Location = new Point(28, 89);
            EmailLabel.Text = "الإيميل:";
            EmailLabel.Location = new Point(519, 138);
            Email.Location = new Point(353, 166);
            WeightLable.Text = "الوزن:";
            WeightLable.Location = new Point(113, 138);
            Weight.Location = new Point(28, 166);
            KGToLB.Location = new Point(28, 166);
            HeightLable.Text = "الطول:";
            HeightLable.Location = new Point(268, 138);
            Height_cm.Location = new Point(201, 166);
            InchesToCm.Location = new Point(201, 166);
            PassLabel.Text = "كلمة المرور:";
            PassLabel.Location = new Point(494, 230);
            Password.Location = new Point(379, 258);
            PasswordVisibility.Location = new Point(379, 258);
            RePassLabel.Text = "أعد إدخال كلمة المرور:";
            RePassLabel.Location = new Point(79, 231);
            RePassword.Location = new Point(28, 259);
            PasswordVisibilityRE.Location = new Point(28, 259);
            PasswordStrengthLabel.RightToLeft = RightToLeft.No;
            UpdateUsrInfo.Text = "تعديل";
            UpdateUsrInfo.Location = new Point(267, 260);
            PasswordStrengthLabel.Location = new Point(378, 296);
            PasswordMatchLabel.Location = new Point(115, 296);
            Backlbl.Text = "رجوع";
            BrowseButton.Text = "تصفّح";
            PPlbl.Text = " تغيير الصورة الشخصية ";
            DeleteUserlbl.Text = "حذف حسابك";
        }

        private void EnglishLanguage()
        {
            base.RightToLeft = RightToLeft.No;
            ActivityLevel.Items.Add("Lazy");
            ActivityLevel.Items.Add("Lightly");
            ActivityLevel.Items.Add("Medium");
            ActivityLevel.Items.Add("Active");
            FnameLable.Text = "First Name:";
            LnameLable.Text = "Last Name:";
            UsernameLabel.Text = "Username:";
            ActivityLabel.Text = "Activity Level:";
            EmailLabel.Text = "Email:";
            WeightLable.Text = "Weight:";
            HeightLable.Text = "Height:";
            PassLabel.Text = "Password:";
            RePassLabel.Text = "Re-Enter Password:";
            UpdateUsrInfo.Text = "Update";
            Backlbl.Text = "Back";
            BrowseButton.Text = "Browse";
            PPlbl.Text = "Change profile picture";
            DeleteUserlbl.Text = "Delete your account";
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

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            DeleteAccount deleteAccount = new DeleteAccount();
            deleteAccount.Show();
        }
    }
}