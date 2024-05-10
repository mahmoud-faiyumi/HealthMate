using HealthMate_UI.Constants;
using System;
using System.Windows.Forms;

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
                this.Close();
                MessageBox.Show(breakCal.ToString());
            }
        }
    }
}
