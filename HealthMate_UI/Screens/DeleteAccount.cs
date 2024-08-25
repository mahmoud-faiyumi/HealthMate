using HealthMate_UI.Constants;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace HealthMate_UI.Screens
{
    public partial class DeleteAccount : Form
    {
        private bool passwordVisible = true;

        public DeleteAccount()
        {
            InitializeComponent();
            Deletebtn.Enabled = false;
            // Set the initial image
            PasswordVisibility.Image = Properties.Resources.show_eye; // Use your initial image here
            PasswordVisibility.BackgroundImageLayout = ImageLayout.Stretch; // Set the layout to stretch
        }

        private void DeleteAccount_Load(object sender, EventArgs e)
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

        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Password.Text))
            {
                Deletebtn.Enabled = true;
            }
            else
            {
                Deletebtn.Enabled = false;
            }
        }

        private void ApplyLightTheme()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            Password.ForeColor = Color.Black;
            Password.FillColor = Color.White;
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            Password.ForeColor = Color.Black;
            Password.FillColor = Color.FromArgb(224, 224, 224);
        }

        private void EnglishLanguage()
        {
            label1.Text = "We are sad to see you here😔";
            label2.Text = "something bothers you, please contact us and provide us with feedback at health.mate.feadback@gmail.com";
            label3.Text = "If you still want to delete your account\r\nEnter your password";
            Deletebtn.Text = "Delete";
        }

        private void ArabicLanguage()
        {
            label1.Text = "😔نحن حزينون لرؤيتك هنا";
            label2.Text = "إذا كان هناك شيء يزعجك، يرجى الاتصال بنا وتزويدنا بالتعليقات  health.mate.feadback@gmail.com على";
            label3.Text = "إذا كنت لا تزال ترغب في حذف حسابك\r\nادخل كلمة المرور";
            Deletebtn.Text = "حذف";
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            var encryptionService = new EncryptionService("hTbHfq5rC5dAby6DJt8P3w==", "6mRwZNlJb/WLbCyk4n+bBg==");
            string decryptedPass = encryptionService.Decrypt(CommonValues.CurrentUserInfo.PasswordFromDB);
            if (Password.Text == decryptedPass)
            {
                try
                {
                    using (DatabaseManagerui databaseManager = new DatabaseManagerui())
                    {
                        databaseManager.OpenConnection();
                        string insertQuery = "INSERT INTO BlackList (UserName) VALUES (@UserName)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, databaseManager.GetConnection()))
                        {
                            insertCommand.Parameters.AddWithValue("@UserName", CommonValues.CurrentUserInfo.UserName);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                    if (CommonValues.CurrentUserInfo.IsArabic)
                    {
                        MessageBox.Show("تم حذف الحساب بنجاح", "نجاح", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Account deleted successfully", "Success", MessageBoxButtons.OK);
                    }

                    CommonValues.CurrentUserInfo = null;
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    MessageBox.Show("كلمة المرور خاطئة.");
                }
                else
                {
                    MessageBox.Show("Wrong password.");
                }
                Password.Clear();
            }
        }

        private void PasswordVisibility_Click(object sender, EventArgs e)
        {
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
    }
}
