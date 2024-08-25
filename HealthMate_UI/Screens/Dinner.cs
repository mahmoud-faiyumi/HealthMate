using HealthMate_UI.Constants;
using HealthMate_UI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthMate_UI.Screens
{
    public partial class Dinner : Form
    {
        private FoodLoader foodLoader;

        public Dinner()
        {
            InitializeComponent();
            foodLoader = new FoodLoader(); // Assuming FoodLoader has a parameterless constructor
        }

        private void Dinner_Load(object sender, EventArgs e)
        {
            if (CommonValues.CurrentUserInfo.IsDark)
            {
                ApplyDarkTheme();
            }
            else
            {
                ApplyLightTheme();
            }
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                ApplyArabicLanguage();
            }
            else
            {
                ApplyEnglishLanguage();
            }
            CheckBox1.Checked = true;
            CategoryList.Enabled = false;
            FoodList.Enabled = false;
            portion.Enabled = false;
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(DinnerCal.Text, out double dinnerCal) && CheckBox1.Checked)
            {
                ShowValidationMessage("الرجاء إدخال قيمة عددية.", "Please enter a valid number.");
                DinnerCal.Clear();
                return;
            }

            if (!double.TryParse(portion.Text, out double portionValue) && CheckBox2.Checked)
            {
                ShowValidationMessage("الرجاء إدخال قيمة عددية.", "Please enter a valid number.");
                portion.Clear();
                return;
            }

            if (CheckBox1.Checked)
            {
                UpdateDinnerCalories(dinnerCal);
            }
            else if (CheckBox2.Checked)
            {
                if (float.TryParse(portion.Text, out float portionVal) && FoodList.SelectedItem != null)
                {
                    CalculateAndStoreCalories(portionVal);
                }
                else
                {
                    ShowValidationMessage("يرجى اختيار عنصر غذائي وإدخال حجم الحصة المناسب.", "Please select a food item and enter a valid portion size.");
                }
            }
        }

        private void ShowValidationMessage(string arabicMessage, string englishMessage)
        {
            string message = CommonValues.CurrentUserInfo.IsArabic ? arabicMessage : englishMessage;
            MessageBox.Show(message, CommonValues.CurrentUserInfo.IsArabic ? "خطأ في التحقق" : "Validation Error", MessageBoxButtons.OK);
        }

        private void UpdateDinnerCalories(double dinnerCal)
        {
            try
            {
                using (DatabaseManageruc databaseManageruc = new DatabaseManageruc())
                {
                    databaseManageruc.OpenConnection();
                    string updateQuery = $"UPDATE [{CommonValues.CurrentUserInfo.UserName}] SET DinnerCal = @DinnerCal WHERE Date = @today";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, databaseManageruc.GetConnection()))
                    {
                        updateCommand.Parameters.AddWithValue("@DinnerCal", dinnerCal);
                        updateCommand.Parameters.AddWithValue("@today", DateTime.Today);
                        updateCommand.ExecuteNonQuery();
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"حدث خطأ: {ex.Message}", $"An error occurred: {ex.Message}");
            }
        }

        private void ShowErrorMessage(string arabicMessage, string englishMessage)
        {
            string message = CommonValues.CurrentUserInfo.IsArabic ? arabicMessage : englishMessage;
            MessageBox.Show(message, CommonValues.CurrentUserInfo.IsArabic ? "خطأ" : "Error", MessageBoxButtons.OK);
        }

        private void CalculateAndStoreCalories(float portionVal)
        {
            try
            {
                string selectedFoodName = FoodList.SelectedItem.ToString();
                Foodcategory selectedFood = foodLoader.GetFoodByName(selectedFoodName);

                if (selectedFood != null)
                {
                    portionVal = portionVal / 100;
                    float portionCal = selectedFood.calories * portionVal;

                    UpdateDinnerCalories(portionCal);
                }
                else
                {
                    ShowErrorMessage("لم يتم العثور على عنصر الطعام المحدد.", "Selected food item not found.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"حدث خطأ: {ex.Message}", $"An error occurred: {ex.Message}");
            }
        }

        private void DinnerCal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enter_Click(sender, e);
            }
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
        }

        private void ApplyLightTheme()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
        }

        private void ApplyArabicLanguage()
        {
            base.RightToLeft = RightToLeft.Yes;
            Enterbtn.Text = "إدخال";
            CategoryList.Items.Clear();
            CategoryList.Items.Add("فاكهة");
            CategoryList.Items.Add("لحم");
            CategoryList.Items.Add("سمك");
            CategoryList.Items.Add("خضار");
            CategoryList.Items.Add("حبوب");
            CategoryList.Items.Add("مكسرات");
            CategoryList.Items.Add("ألبان");
            label1.Text = "كم سعرة في وجبتك؟";
            label2.Text = "او أدخل طعامك";
            label3.Text = "ادخل عدد السعرات";
            label4.Text = "صنف الطعام";
            label5.Text = "الطعام";
            label6.Text = "الكمية";
            label7.Text = "عدد السعرات";
        }

        private void ApplyEnglishLanguage()
        {
            base.RightToLeft = RightToLeft.No;
            Enterbtn.Text = "Enter";
            CategoryList.Items.Clear();
            CategoryList.Items.Add("Fruit");
            CategoryList.Items.Add("Meat");
            CategoryList.Items.Add("Fish");
            CategoryList.Items.Add("Vegetable");
            CategoryList.Items.Add("Grain");
            CategoryList.Items.Add("Nut");
            CategoryList.Items.Add("Dairy");
            label1.Text = "How much calories in your meal?";
            label2.Text = "Or enter your food";
            label3.Text = "Enter the number of calories";
            label4.Text = "Food category";
            label5.Text = "Food";
            label6.Text = "Portion";
            label7.Text = "Number of calories";
        }

        private async void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = CategoryList.Text;

            // Dictionary to map category names to their corresponding food lists
            var categoryMapping = new Dictionary<string, Func<List<Foodcategory>>>
            {
                { "Fruit", () => foodLoader.Fruit },
                { "فاكهة", () => foodLoader.Fruit },
                { "Meat", () => foodLoader.Meat },
                { "لحم", () => foodLoader.Meat },
                { "Fish", () => foodLoader.Fish },
                { "سمك", () => foodLoader.Fish },
                { "Vegetable", () => foodLoader.Vegetable },
                { "خضار", () => foodLoader.Vegetable },
                { "Grain", () => foodLoader.Grain },
                { "حبوب", () => foodLoader.Grain },
                { "Nut", () => foodLoader.Nut },
                { "مكسرات", () => foodLoader.Nut },
                { "Dairy", () => foodLoader.Dairy },
                { "ألبان", () => foodLoader.Dairy }
            };

            if (!categoryMapping.TryGetValue(selectedCategory, out var getSelectedFoodList))
            {
                ShowErrorMessage("الفئة المحددة غير معروفة.", "Unknown category selected.");
                return;
            }

            List<Foodcategory> selectedFoodList = null;
            try
            {
                selectedFoodList = await Task.Run(getSelectedFoodList);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"حدث خطأ أثناء تحميل قائمة الطعام: {ex.Message}", $"Error loading food list: {ex.Message}");
                return;
            }

            if (selectedFoodList == null || selectedFoodList.Count == 0)
            {
                ShowErrorMessage("قائمة الطعام المختارة فارغة.", "Selected food list is empty.");
                return;
            }

            // Clear previous items in FoodList
            FoodList.Items.Clear();

            // Add food names to FoodList
            foreach (var food in selectedFoodList)
            {
                if (CommonValues.CurrentUserInfo.IsArabic)
                {
                    FoodList.Items.Add(food.food_name_ar);
                }
                else
                {
                    FoodList.Items.Add(food.food_name_en);
                }
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                DinnerCal.Enabled = true;
                CheckBox2.CheckedChanged -= CheckBox2_CheckedChanged;
                CheckBox2.Checked = false;
                CheckBox2.CheckedChanged += CheckBox2_CheckedChanged;
                CategoryList.Enabled = false;
                FoodList.Enabled = false;
                portion.Enabled = false;
            }
            else
            {
                DinnerCal.Enabled = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked)
            {
                DinnerCal.Enabled = false;
                CheckBox1.CheckedChanged -= CheckBox1_CheckedChanged;
                CheckBox1.Checked = false;
                CheckBox1.CheckedChanged += CheckBox1_CheckedChanged;
                CategoryList.Enabled = true;
                FoodList.Enabled = true;
                portion.Enabled = true;
            }
            else
            {
                CategoryList.Enabled = false;
                FoodList.Enabled = false;
                portion.Enabled = false;
            }
        }
    }
}