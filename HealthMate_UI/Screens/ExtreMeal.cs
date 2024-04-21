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
    public partial class ExtraMeal : Form
    {
        public ExtraMeal()
        {
            InitializeComponent();
        }

        private void ExtreMeal_Load(object sender, EventArgs e)
        {
            
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(ExtraMealCal.Text, out double extraMealCal))
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    MessageBox.Show("الرجاء إدخال قيمة عددية.", "خطأ في التحقق", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.", "Validation Error", MessageBoxButtons.OK);
                }
                ExtraMealCal.Clear();
            }
            else
            {
                this.Close();
                MessageBox.Show(extraMealCal.ToString());

            }
        }
    }
}
