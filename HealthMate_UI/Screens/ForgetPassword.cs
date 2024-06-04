using HealthMate_UI.Constants;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthMate_UI.Screens
{
    public partial class ForgetPassword : Form
    {
        private Timer internetCheckTimer;
        private int failedAttempts = 0;
        bool arabic = CommonValues.CurrentUserInfo.IsArabic;
        string email = "";
        private DateTime lockEndTime;
        private Timer countdownTimer;


        public ForgetPassword()
        {
            InitializeComponent();
            InitializeInternetCheckTimer();
            CheckInternetConnection();
            PINcode.MaxLength = 6;
        }

        private void InitializeInternetCheckTimer()
        {
            internetCheckTimer = new Timer();
            internetCheckTimer.Interval = 5000; // Check every 5 seconds
            internetCheckTimer.Tick += InternetCheckTimer_Tick;
            internetCheckTimer.Start();
        }

        private void InternetCheckTimer_Tick(object sender, EventArgs e)
        {
            CheckInternetConnection();
        }

        private void CheckInternetConnection()
        {
            if (!IsInternetAvailable())
            {
                NoInternet.Visible = true;
                return;
            }
            else
            {
                NoInternet.Visible = false;
            }
        }

        private async void ForgetPasword_Load(object sender, EventArgs e)
        {
            if (arabic)
            {
                Email.Text = "ادخل الإيميل الخاص بك";
                SendResetEmailBtn.Text = "إرسال الرمز عبر الايميل";
                NoInternet.Text = "لا يوجد اتصال بالانترنت";
            }
            else
            {
                Email.Text = "Enter Your Email";
                SendResetEmailBtn.Text = "Send code via email";
            }
            if (CommonValues.CurrentUserInfo.IsDark == true)
            {
                ApplyDarkTheme();
            }
            else
            {
                ApplyLightTheme();
            }

            if (await IsEmailLocked(email))
            {
                MessageBox.Show("لا يمكنك طلب رمز جديد حتى انتهاء مدة القفل.", "خطأ", MessageBoxButtons.OK);
                SendResetEmailBtn.Enabled = false;
                PINcode.Enabled = false;
            }
        }

        private void ForgetPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private bool IsInternetAvailable()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        private async void SendResetLinkButton_Click(object sender, EventArgs e)
        {
            if (await IsEmailLocked(email))
            {
                MessageBox.Show("لا يمكنك طلب رمز جديد حتى انتهاء مدة القفل.", "خطأ", MessageBoxButtons.OK);
                return;
            }

            if (await CanRequestCode(email))
            {
                if (await IsEmailRegistered(email))
                {
                    if (arabic)
                    {
                        label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        label1.Text = "يرجى التحقق من ايميلك للحصول على رسالة تحتوي على الرمز الخاص بك. يتكون الرمز الخاص بك من 6 أرقام.";
                        label2.Text = $"{email} :ارسلنا رمزك الى";
                    }
                    else
                    {
                        label1.Text = "Please check your email for a message with your code. Your code is 6 numbers long.";
                        label2.Text = $"We sent your code to: {email}";
                    }
                    string token = GenerateToken();
                    SaveTokenToDatabase(email, token);
                    await SendResetLink(email, token);
                    MessageBox.Show("A password reset link has been sent to your email.", "Password Recovery", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Email not found.", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("You can only request a code once every 10 minutes.", "Error", MessageBoxButtons.OK);
            }
        }

        private async Task<bool> IsEmailRegistered(string email)
        {
            try
            {
                using (DatabaseManagerui databaseManager = new DatabaseManagerui())
                {
                    databaseManager.OpenConnection();
                    string readQuery = "SELECT COUNT(1) FROM UserInfo WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(readQuery, databaseManager.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        int count = (int)await command.ExecuteScalarAsync();
                        return count == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
        }

        private async Task<bool> CanRequestCode(string email)
        {
            try
            {
                using (DatabaseManagerui databaseManager = new DatabaseManagerui())
                {
                    databaseManager.OpenConnection();
                    string query = "SELECT LastRequestTime FROM CodeRequests WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(query, databaseManager.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        object result = await command.ExecuteScalarAsync();
                        if (result != null)
                        {
                            DateTime lastRequestTime = (DateTime)result;
                            if (DateTime.Now - lastRequestTime < TimeSpan.FromMinutes(10))
                            {
                                return false;
                            }
                        }
                        UpdateLastRequestTime(email);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
        }

        private void UpdateLastRequestTime(string email)
        {
            using (DatabaseManagerui databaseManager = new DatabaseManagerui())
            {
                databaseManager.OpenConnection();
                string query = "IF EXISTS (SELECT 1 FROM CodeRequests WHERE Email = @Email) " +
                               "UPDATE CodeRequests SET LastRequestTime = @LastRequestTime WHERE Email = @Email " +
                               "ELSE INSERT INTO CodeRequests (Email, LastRequestTime) VALUES (@Email, @LastRequestTime)";
                using (SqlCommand command = new SqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@LastRequestTime", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }

        private string GenerateToken()
        {
            Random random = new Random();
            int token = random.Next(100000, 999999); // Generate a 6-digit number
            return token.ToString();
        }

        private async Task<bool> IsEmailLocked(string email)
        {
            try
            {
                using (DatabaseManagerui databaseManager = new DatabaseManagerui())
                {
                    databaseManager.OpenConnection();
                    string query = "SELECT LastRequestTime FROM CodeRequests WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(query, databaseManager.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        var result = await command.ExecuteScalarAsync();
                        if (result != null)
                        {
                            DateTime lastRequestTime = (DateTime)result;
                            if (lastRequestTime > DateTime.Now)
                            {
                                lockEndTime = lastRequestTime;
                                if (countdownTimer == null)
                                {
                                    countdownTimer = new Timer();
                                    countdownTimer.Interval = 1000; // 1 ثانية
                                    countdownTimer.Tick += CountdownTimer_Tick;
                                }
                                countdownTimer.Start();
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
        }

        private void SaveTokenToDatabase(string email, string token)
        {
            using (DatabaseManagerui databaseManager = new DatabaseManagerui())
            {
                databaseManager.OpenConnection();
                string query = "UPDATE UserInfo SET ResetToken = @Token, TokenExpiry = @Expiry WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Token", token);
                    command.Parameters.AddWithValue("@Expiry", DateTime.Now.AddMinutes(10));
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                }
            }
        }

        private async Task SendResetLink(string email, string token)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["Email"]))
            {
                throw new ConfigurationErrorsException("'Email' is invalid in application configuration");
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Health Mate", ConfigurationManager.AppSettings["Email"])); // Replace with your email and name
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Password Reset";

            var bodyBuilder = new BodyBuilder
            {
                TextBody = $"The validity of this code is 10 minutes\r\nYour code is: {token}\n\nIf you don't know about this message, you can ignore it.",
                HtmlBody = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f4f4f9;
                    color: #333;
                    padding: 20px;
                }}
                .container {{
                    background-color: #ffffff;
                    padding: 20px;
                    border-radius: 8px;
                    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                    max-width: 600px;
                    margin: auto;
                }}
                .header {{
                    text-align: center;
                    margin-bottom: 20px;
                }}
                .header h1 {{
                    margin: 0;
                    font-size: 24px;
                    color: rgb(51, 172, 98);
                }}
                .content {{
                    font-size: 16px;
                    line-height: 1.6;
                }}
                .code {{
                    font-size: 24px;
                    font-weight: bold;
                    text-align: center;
                    margin: 20px 0;
                    padding: 10px;
                    background-color: #f9f9f9;
                    border: 1px solid #ddd;
                    border-radius: 4px;
                }}
                .footer {{
                    text-align: center;
                    font-size: 12px;
                    color: #888;
                    margin-top: 20px;
                }}
                .img {{
                    align-items: center;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <h1>Password Reset</h1>
                </div>
                <div class='content'>
                    <p>The validity of this code is 10 minutes.</p>
                    <div class='code'>{token}</div>
                    <p>If you don't know about this message, you can ignore it.</p>
                </div>
                <div class='footer'>
                    <img src='https://i.ibb.co/CVWrJNN/Untitled-1-01.png' width='80'></img>
                    <p>&copy; 2024 Health Mate. All rights reserved.</p>
                </div>
            </div>
        </body>
        </html>"
            };

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["SendGridAPIKey"]))
                {
                    throw new ConfigurationErrorsException("'SendGridAPIKey' is invalid in application configuration");
                }
                await client.ConnectAsync("smtp.sendgrid.net", 587, SecureSocketOptions.StartTls); // Replace with your SMTP server and port
                await client.AuthenticateAsync("apikey", ConfigurationManager.AppSettings["SendGridAPIKey"]); // Replace with your SendGrid API key
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }

        private async Task<bool> ValidateToken(string email, string token)
        {
            try
            {
                using (DatabaseManagerui databaseManager = new DatabaseManagerui())
                {
                    databaseManager.OpenConnection();
                    string query = "SELECT ResetToken, TokenExpiry FROM UserInfo WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(query, databaseManager.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                string dbToken = reader.GetString(0);
                                DateTime tokenExpiry = reader.GetDateTime(1);
                                if (dbToken == token && DateTime.Now <= tokenExpiry)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
            return false;
        }

        private async void ResetPasswordBtn_Click(object sender, EventArgs e)
        {
            if (PINcode.Text.Length == 6)
            {
                bool isValid = await ValidateToken(email, PINcode.Text);
                if (isValid)
                {
                    // إعادة تعيين عدد المحاولات الفاشلة عند نجاح التحقق
                    failedAttempts = 0;

                    // التنقل إلى نموذج تغيير كلمة المرور
                    ChangePassword changePassword = new ChangePassword();
                    changePassword.Show();
                    this.Hide();
                }
                else
                {
                    // زيادة عدد المحاولات الفاشلة
                    failedAttempts++;

                    if (failedAttempts >= 3)
                    {
                        // قفل طلب الرمز وإدخال PIN لمدة ساعة
                        await LockCodeRequestAndPINEntry(email);
                        MessageBox.Show("رمز غير صالح. لا يمكنك طلب رمز جديد لمدة ساعة.", "خطأ", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("رمز غير صالح. حاول مرة أخرى.", "خطأ", MessageBoxButtons.OK);
                    }
                }
            }
            else
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


        private async Task LockCodeRequestAndPINEntry(string email)
        {
            // تعطيل زر الإرسال وإدخال PIN لمدة ساعة
            SendResetEmailBtn.Enabled = false;
            PINcode.Enabled = false;

            lockEndTime = DateTime.Now.AddHours(1);

            using (DatabaseManagerui databaseManager = new DatabaseManagerui())
            {
                databaseManager.OpenConnection();
                string query = "IF EXISTS (SELECT 1 FROM CodeRequests WHERE Email = @Email) " +
                               "UPDATE CodeRequests SET LastRequestTime = @LastRequestTime WHERE Email = @Email " +
                               "ELSE INSERT INTO CodeRequests (Email, LastRequestTime) VALUES (@Email, @LastRequestTime)";
                using (SqlCommand command = new SqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@LastRequestTime", lockEndTime);
                    await command.ExecuteNonQueryAsync();
                }
            }

            // ضبط مؤقت العداد التنازلي
            if (countdownTimer == null)
            {
                countdownTimer = new Timer();
                countdownTimer.Interval = 1000; // 1 ثانية
                countdownTimer.Tick += CountdownTimer_Tick;
            }
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = lockEndTime - DateTime.Now;
            if (remainingTime <= TimeSpan.Zero)
            {
                SendResetEmailBtn.Enabled = true;
                PINcode.Enabled = true;
                CountDown.Text = "00:00:00";
                countdownTimer.Stop();
            }
            else
            {
                CountDown.Text = remainingTime.ToString(@"hh\:mm\:ss");
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

        private void PINcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not a digit or control key, suppress the key press
                e.Handled = true;
            }
        }

        private void Email_Leave(object sender, EventArgs e)
        {
            if (!(Email.Text.Length <= 6 && Email.Text.Length != 0))
            {
                email = Email.Text;
                if (arabic)
                {
                    Email.Text = "ادخل الإيميل الخاص بك";
                }
                else
                {
                    Email.Text = "Enter Your Email";
                }
            }
        }

        private void Email_Enter(object sender, EventArgs e)
        {
            if (!(Email.Text.Length <= 6))
            {
                Email.Text = string.Empty;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            Email.ForeColor = Color.Black;
            Email.FillColor = Color.FromArgb(224, 224, 224);
            PINcode.ForeColor = Color.Black;
            PINcode.FillColor = Color.FromArgb(224, 224, 224);
            Back.Image = Properties.Resources.WBack;
        }

        private void ApplyLightTheme()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            Email.ForeColor = Color.Black;
            Email.FillColor = Color.White;
            PINcode.ForeColor = Color.Black;
            PINcode.FillColor = Color.White;
            Back.Image = Properties.Resources.Back;
        }
    }
}