using HealthMate_UI.Constants;
using HealthMate_UI.Models;
using HealthMate_UI.Screens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthMate_UI
{
    public partial class AddPreference : Form
    {
        private readonly FoodLoader foodLoader;

        public AddPreference()
        {
            InitializeComponent();
            foodLoader = new FoodLoader(); // Initialize FoodLoader instance
        }

        private void AddPreference_Load(object sender, EventArgs e)
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
        }

        private async void btnAddPreference_Click(object sender, EventArgs e)
        {
            try
            {
                if (FoodList.SelectedValue == null)
                {
                    throw new InvalidOperationException("No food selected.");
                }

                int foodId = (int)FoodList.SelectedValue;

                // Check if the preference already exists before adding
                bool alreadyExists = await PreferenceAlreadyExistsAsync(foodId);
                if (alreadyExists)
                {
                    ShowErrorMessage("This preference already exists.", "هذه التفضيل موجود بالفعل.");
                    return;
                }

                await AddPreferenceAsync(foodId);
                MessageBox.Show("Preference added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred while adding the preference: {ex.Message}", $"حدث خطأ أثناء إضافة التفضيل: {ex.Message}");
            }
        }

        private async Task<bool> PreferenceAlreadyExistsAsync(int foodId)
        {
            bool exists = false;
            try
            {
                using (var databaseManagerfo = new DatabaseManagerfo())
                {
                    databaseManagerfo.OpenConnection(); // Ensure connection is open

                    string checkQuery = "SELECT COUNT(*) FROM Preferences WHERE user_id = @UserId AND food_id = @FoodId";

                    using (var command = new SqlCommand(checkQuery, databaseManagerfo.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@UserId", CommonValues.CurrentUserInfo.ID);
                        command.Parameters.AddWithValue("@FoodId", foodId);

                        exists = (int)await command.ExecuteScalarAsync() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred while checking for existing preference: {ex.Message}", $"حدث خطأ أثناء التحقق من التفضيل الموجود: {ex.Message}");
            }

            return exists;
        }

        private Task AddPreferenceAsync(int foodId)
        {
            if (CommonValues.CurrentUserInfo == null)
            {
                throw new InvalidOperationException("CurrentUserInfo is not initialized.");
            }

            try
            {
                using (var databaseManagerfo = new DatabaseManagerfo())
                {
                    databaseManagerfo.OpenConnection(); // Ensure connection is open

                    string insertQuery = "INSERT INTO Preferences (user_id, food_id) VALUES (@UserId, @FoodId)";

                    using (var command = new SqlCommand(insertQuery, databaseManagerfo.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@UserId", CommonValues.CurrentUserInfo.ID);
                        command.Parameters.AddWithValue("@FoodId", foodId);

                        if (command.Connection.State == ConnectionState.Closed)
                        {
                            command.Connection.Open();
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Task.CompletedTask;
        }

        private void ApplyArabicLanguage()
        {
            this.RightToLeft = RightToLeft.Yes;
            AddPreferenceBtn.Text = "أضف التفضيل";
            PopulateCategoryList(new List<string> { "فاكهة", "لحم", "سمك", "خضار", "حبوب", "مكسرات", "ألبان" });
        }

        private void ApplyEnglishLanguage()
        {
            this.RightToLeft = RightToLeft.No;
            AddPreferenceBtn.Text = "Add Preference";
            PopulateCategoryList(new List<string> { "Fruit", "Meat", "Fish", "Vegetable", "Grain", "Nut", "Dairy" });
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

        private void PopulateCategoryList(List<string> categories)
        {
            CategoryList.Items.Clear();
            foreach (var category in categories)
            {
                CategoryList.Items.Add(category);
            }
        }

        private async void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = CategoryList.Text;

            if (!TryGetFoodListForCategory(selectedCategory, out var getSelectedFoodList))
            {
                ShowErrorMessage("الفئة المحددة غير معروفة.", "Unknown category selected.");
                return;
            }

            try
            {
                var selectedFoodList = await Task.Run(getSelectedFoodList);
                UpdateFoodList(selectedFoodList);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"حدث خطأ أثناء تحميل قائمة الطعام: {ex.Message}", $"Error loading food list: {ex.Message}");
            }
        }

        private bool TryGetFoodListForCategory(string category, out Func<List<Foodcategory>> getSelectedFoodList)
        {
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

            return categoryMapping.TryGetValue(category, out getSelectedFoodList);
        }

        private void UpdateFoodList(List<Foodcategory> foodList)
        {
            if (foodList == null || foodList.Count == 0)
            {
                ShowErrorMessage("قائمة الطعام المختارة فارغة.", "Selected food list is empty.");
                return;
            }

            FoodList.DataSource = foodList;
            FoodList.DisplayMember = CommonValues.CurrentUserInfo.IsArabic ? "food_name_ar" : "food_name_en";
            FoodList.ValueMember = "food_id";
        }

        private void ShowErrorMessage(string arabicMessage, string englishMessage)
        {
            string message = CommonValues.CurrentUserInfo.IsArabic ? arabicMessage : englishMessage;
            MessageBox.Show(message, CommonValues.CurrentUserInfo.IsArabic ? "خطأ" : "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
