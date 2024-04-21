using HealthMate_UI.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                this.Close();
                MessageBox.Show(dinnerCal.ToString());
            }
        }

        private void Dinner_Load(object sender, EventArgs e)
        {

        }
    }
}
