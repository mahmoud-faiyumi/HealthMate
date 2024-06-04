using HealthMate_UI.Constants;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HealthMate_UI.Screens
{
    public partial class Dinner : Form
    {
        public Dinner()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(DinnerCal.Text, out double dinnerCal))
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    MessageBox.Show("الرجاء إدخال قيمة عددية.", "خطأ في التحقق", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.", "Validation Error", MessageBoxButtons.OK);
                }
                DinnerCal.Clear();
            }
            else
            {
                try
                {
                    using (DatabaseManageruc databaseManageruc = new DatabaseManageruc())
                    {
                        databaseManageruc.OpenConnection();
                        string updateQuery = $"UPDATE [{CommonValues.CurrentUserInfo.UserName}] SET DinnerCal = @DinnerCal WHERE Date = @today";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, databaseManageruc.GetConnection()))
                        {
                            updateCommand.Parameters.AddWithValue("@DinnerCal", (double)dinnerCal);
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
                MessageBox.Show(dinnerCal.ToString());
            }
        }

        private void Dinner_Load(object sender, EventArgs e)
        {

        }

        private void DinnerCal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enter_Click(sender, e);
            }
        }
    }
}
