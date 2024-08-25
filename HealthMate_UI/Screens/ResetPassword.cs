using HealthMate_UI.Constants;
using MimeKit.Encodings;
using SendGrid.Helpers.Mail;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HealthMate_UI.Screens
{
    public partial class ResetPassword : Form
    {
        private bool passwordVisible = false;
        private bool passwordVisibleRE = false;
        private DatabaseManagerui databaseManager;
        private string email;
        bool arabic = CommonValues.CurrentUserInfo.IsArabic;

        public ResetPassword(string Email)
        {
            InitializeComponent();
            email = Email;
            Password.PasswordChar = '*';
            RePassword.PasswordChar = '*';

            // Set the initial image
            PasswordVisibility.Image = Properties.Resources.hide_eye; // Use your initial image here
            PasswordVisibility.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
            PasswordVisibilityRE.Image = Properties.Resources.hide_eye; // Use your initial image here
            PasswordVisibilityRE.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
        }

        private void ResetPassword_Load(object sender, EventArgs e)
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

        private void UpdateUsrInfo_Click(object sender, EventArgs e)
        {
            string password = Password.Text;
            string confirmPassword = RePassword.Text;
            if (arabic)
            {
                if (password != confirmPassword)
                {
                    MessageBox.Show("كلمات المرور غير متطابقة. يرجى المحاولة مرة أخرى.", "التحقق من كلمة المرور", MessageBoxButtons.OK);
                    Password.Clear();
                    RePassword.Clear();
                    return;
                }
            }
            else
            {
                if (password != confirmPassword)
                {
                    MessageBox.Show("The passwords do not match. Please try again.", "Password Validation", MessageBoxButtons.OK);
                    Password.Clear();
                    RePassword.Clear();
                    return;
                }
            }
            try
            {
                using (DatabaseManagerui databaseManager = new DatabaseManagerui())
                {
                    databaseManager.OpenConnection();
                    string updateQuery = "UPDATE UserInfo SET Password = @Password WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(updateQuery, databaseManager.GetConnection()))
                    {
                        if (!string.IsNullOrWhiteSpace(Password.Text))
                        {
                            string encryptionKey = "hTbHfq5rC5dAby6DJt8P3w==";
                            string initializationVector = "6mRwZNlJb/WLbCyk4n+bBg==";

                            var encryptionService = new EncryptionService(encryptionKey, initializationVector);

                            string plainText = Password.Text;
                            string encryptedText = encryptionService.Encrypt(plainText);

                            command.Parameters.AddWithValue("@Password", encryptedText);
                            command.Parameters.AddWithValue("@Email", email);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                if (arabic)
                {
                    MessageBox.Show("تم تحديث كلمة المرور", "نجاح", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Password updated", "Success", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

            Password.Clear();
            RePassword.Clear();

        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            Password.ForeColor = Color.Black;
            Password.FillColor = Color.FromArgb(224, 224, 224);
            RePassword.ForeColor = Color.Black;
            RePassword.FillColor = Color.FromArgb(224, 224, 224);
        }

        private void ApplyLightTheme()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            Password.ForeColor = Color.Black;
            Password.FillColor = Color.White;
            RePassword .ForeColor = Color.Black;
            RePassword.FillColor = Color.White;
        }

        private void ArabicLanguage()
        {
            base.RightToLeft = RightToLeft.Yes;
            PassLabel.Text = "كلمة المرور الجديدة:";
            RePassLabel.Text = "أعد إدخال كلمة المرور:";
            PasswordStrengthLabel.RightToLeft = RightToLeft.No;
            UpdateUsrInfo.Text = "تحديث كلمة المرور";
        }

        private void EnglishLanguage()
        {
            base.RightToLeft = RightToLeft.No;
            PassLabel.Text = "Password:";
            RePassLabel.Text = "Re-Enter Password:";
            UpdateUsrInfo.Text = "Update Password";
        }

        private void ResetPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

