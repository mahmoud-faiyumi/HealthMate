using HealthMate_UI.Constants;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HealthMate_UI.Screens
{
    public partial class Lunch : Form
    {
        public Lunch()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(LunchCal.Text, out double lunchCal))
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    MessageBox.Show("الرجاء إدخال قيمة عددية.", "خطأ في التحقق", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.", "Validation Error", MessageBoxButtons.OK);
                }
                LunchCal.Clear();
            }
            else
            {
                try
                {
                    using (DatabaseManageruc databaseManageruc = new DatabaseManageruc())
                    {
                        databaseManageruc.OpenConnection();
                        string updateQuery = $"UPDATE [{CommonValues.CurrentUserInfo.UserName}] SET LunchCal = @LunchCal WHERE Date = @today";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, databaseManageruc.GetConnection()))
                        {
                            updateCommand.Parameters.AddWithValue("@LunchCal", (double)lunchCal);
                            updateCommand.Parameters.AddWithValue("@today", DateTime.Today);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
                this.Close();
                MessageBox.Show(lunchCal.ToString());
            }
        }

        private void Lunch_Load(object sender, EventArgs e)
        {

        }

        private void LunchCal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enter_Click(sender, e);
            }
        }
    }
}
