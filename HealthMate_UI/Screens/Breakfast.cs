using HealthMate_UI.Constants;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HealthMate_UI.Screens
{
    public partial class Breakfast : Form
    {
        public Breakfast()
        {
            InitializeComponent();
        }

        private void Breakfast_Load(object sender, EventArgs e)
        {

        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(BrkFstCal.Text, out double breakCal))
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    MessageBox.Show("الرجاء إدخال قيمة عددية.", "خطأ في التحقق", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.", "Validation Error", MessageBoxButtons.OK);
                }
                BrkFstCal.Clear();
            }
            else
            {
                try
                {
                    using (DatabaseManageruc databaseManageruc = new DatabaseManageruc())
                    {
                        databaseManageruc.OpenConnection();
                        string updateQuery = $"UPDATE [{CommonValues.CurrentUserInfo.UserName}] SET BreakfastCal = @BreakfastCal WHERE Date = @today";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, databaseManageruc.GetConnection()))
                        {
                            updateCommand.Parameters.AddWithValue("@BreakfastCal", (double)breakCal);
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
                MessageBox.Show(breakCal.ToString());
            }
        }

        private void BrkFstCal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enter_Click(sender, e);
            }
        }
    }
}
