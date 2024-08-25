using HealthMate_UI.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace HealthMate_UI.Screens
{
    public partial class DietPlaner : Form
    {
        public DietPlaner()
        {
            InitializeComponent();
        }

        private void DietPlaner_Load(object sender, EventArgs e)
        {
            if (CommonValues.CurrentUserInfo.IsDark == true)
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
            MealPreferences.SelectedIndex = 0; // Default to 3 meals
        }

        private void btnSuggestDiet_Click(object sender, EventArgs e)
        {
            try
            {
                SuggestDietPlan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error suggesting diet plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuggestDietPlan()
        {
            // Clear the existing items in the ListBox
            listBoxDietPlan.Items.Clear();

            // Calculate BMR and TDEE
            float bmr = CalculateBMR();
            float tdee = CalculateTDEE(bmr);

            // Allow users to select the number of meals
            int numberOfMeals = GetUserMealPreference();

            // Retrieve data tables
            DataTable foods = GetFoods();
            DataTable allergies = GetUserAllergies();
            DataTable preferences = GetUserPreferences();

            // Get suggested foods based on the provided data
            var suggestedFoods = GetSuggestedFoods(foods, allergies, preferences, tdee);

            // Determine the column name for food names based on user preference
            string foodNameColumn = CommonValues.CurrentUserInfo.IsArabic ? "food_name_ar" : "food_name_en";

            // Calculate calories per meal
            var mealCalories = DistributeCaloriesAcrossMeals(tdee, numberOfMeals);

            // Generate meals
            var meals = GenerateMeals(suggestedFoods, tdee, numberOfMeals, foodNameColumn);

            // Display meals to the user
            DisplayMeals(meals);
        }


        private int GetUserMealPreference()
        {
            // Get the selected option from the UI component
            string selectedOption = MealPreferences.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedOption))
            {
                // Display a default message in the appropriate language
                MessageBox.Show(GetDefaultMessage("NoSelection"), "Default", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 3;
            }

            // Parse the selected option
            if (selectedOption.Contains("3"))
            {
                return 3;
            }
            else if (selectedOption.Contains("4"))
            {
                return 4;
            }
            else if (selectedOption.Contains("5"))
            {
                return 5;
            }
            else if (selectedOption.Contains("6"))
            {
                return 6;
            }
            else
            {
                // Display an unrecognized option message in the appropriate language
                MessageBox.Show(GetDefaultMessage("UnrecognizedOption"), "Default", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 3;
            }
        }

        private string GetDefaultMessage(string key)
        {
            // Determine the current language setting
            bool isArabic = CommonValues.CurrentUserInfo.IsArabic;

            string message;

            // Use if-else statements for language-specific messages
            if (key == "NoSelection")
            {
                message = isArabic ? "لم يتم اختيار تفضيل الوجبات. سيتم الافتراضي إلى 3 وجبات في اليوم." : "No meal preference selected. Defaulting to 3 meals per day.";
            }
            else if (key == "UnrecognizedOption")
            {
                message = isArabic ? "التفضيل غير معترف به. سيتم الافتراضي إلى 3 وجبات في اليوم." : "Unrecognized meal preference. Defaulting to 3 meals per day.";
            }
            else
            {
                message = isArabic ? "حدث خطأ غير معروف." : "An unknown error occurred.";
            }

            return message;
        }


        private Dictionary<string, float> DistributeCaloriesAcrossMeals(float tdee, int numberOfMeals)
        {
            // Ensure valid number of meals
            if (numberOfMeals < 3 || numberOfMeals > 6)
            {
                throw new ArgumentOutOfRangeException("numberOfMeals", "Number of meals must be between 3 and 6.");
            }

            // Adjust calorie distribution based on the number of meals
            Dictionary<string, float> mealCalories = new Dictionary<string, float>();
            float totalDistribution = 0;

            switch (numberOfMeals)
            {
                case 3: // Standard: Breakfast, Lunch, Dinner
                    mealCalories["Breakfast"] = tdee * 0.25f;
                    mealCalories["Lunch"] = tdee * 0.40f;
                    mealCalories["Dinner"] = tdee * 0.35f;
                    totalDistribution = 0.25f + 0.40f + 0.35f;
                    break;
                case 4: // Add a Snack
                    mealCalories["Breakfast"] = tdee * 0.20f;
                    mealCalories["Lunch"] = tdee * 0.35f;
                    mealCalories["Snack"] = tdee * 0.15f;
                    mealCalories["Dinner"] = tdee * 0.30f;
                    totalDistribution = 0.20f + 0.35f + 0.15f + 0.30f;
                    break;
                case 5: // Add Two Snacks
                    mealCalories["Breakfast"] = tdee * 0.20f;
                    mealCalories["Morning Snack"] = tdee * 0.10f;
                    mealCalories["Lunch"] = tdee * 0.30f;
                    mealCalories["Afternoon Snack"] = tdee * 0.10f;
                    mealCalories["Dinner"] = tdee * 0.30f;
                    totalDistribution = 0.20f + 0.10f + 0.30f + 0.10f + 0.30f;
                    break;
                case 6: // Add Three Snacks
                    mealCalories["Breakfast"] = tdee * 0.15f;
                    mealCalories["Morning Snack"] = tdee * 0.10f;
                    mealCalories["Lunch"] = tdee * 0.25f;
                    mealCalories["Afternoon Snack"] = tdee * 0.10f;
                    mealCalories["Dinner"] = tdee * 0.25f;
                    mealCalories["Evening Snack"] = tdee * 0.15f;
                    totalDistribution = 0.15f + 0.10f + 0.25f + 0.10f + 0.25f + 0.15f;
                    break;
            }

            // Adjust for rounding errors
            if (totalDistribution < 1.0f)
            {
                var adjustment = tdee * (1.0f - totalDistribution);
                mealCalories[mealCalories.Keys.Last()] += adjustment;
            }

            return mealCalories;
        }

        private Dictionary<string, List<string>> GenerateMeals(IEnumerable<DataRow> suggestedFoods, float dailyCalorieRequirement, int numberOfMeals, string foodNameColumn)
        {
            var meals = new Dictionary<string, List<string>>();
            Random random = new Random();

            // Calculate calories per meal
            float caloriesPerMeal = dailyCalorieRequirement / numberOfMeals;

            // Group foods by category for a balanced diet
            var foodsByCategory = suggestedFoods
                .GroupBy(food => food["category_en"].ToString())
                .ToDictionary(g => g.Key, g => g.ToList());

            // Define required categories for a balanced diet
            string[] requiredCategories = { "Protein", "Carbohydrate", "Vegetable", "Fat" };

            for (int mealIndex = 1; mealIndex <= numberOfMeals; mealIndex++)
            {
                var mealItems = new List<string>();
                float remainingCalories = caloriesPerMeal;

                // Track selected categories to ensure variety
                var selectedCategories = new HashSet<string>();

                Console.WriteLine($"Generating meal {mealIndex} with target calories: {caloriesPerMeal}");

                // Add items from each required category
                foreach (var category in requiredCategories)
                {
                    if (foodsByCategory.ContainsKey(category))
                    {
                        // Try to add multiple items from each category
                        while (remainingCalories > 50 && mealItems.Count < requiredCategories.Length)
                        {
                            var categoryItems = foodsByCategory[category];
                            if (categoryItems.Count == 0) break;

                            var foodItem = categoryItems[random.Next(categoryItems.Count)];

                            if (AddFoodToMeal(foodItem, foodNameColumn, ref remainingCalories, mealItems, ref selectedCategories, random))
                            {
                                // Remove the item from the list to avoid repetition
                                foodsByCategory[category].Remove(foodItem);
                            }
                        }
                    }
                }

                // Fill remaining calories with random items if necessary
                while (remainingCalories > 50)
                {
                    var availableCategories = foodsByCategory.Keys.Where(k => foodsByCategory[k].Count > 0).ToArray();
                    if (availableCategories.Length == 0) break;

                    var randomCategory = availableCategories[random.Next(availableCategories.Length)];
                    var foodItem = foodsByCategory[randomCategory][random.Next(foodsByCategory[randomCategory].Count)];

                    if (AddFoodToMeal(foodItem, foodNameColumn, ref remainingCalories, mealItems, ref selectedCategories, random))
                    {
                        foodsByCategory[randomCategory].Remove(foodItem);
                    }
                }

                // Add the meal to the dictionary
                meals.Add($"Meal {mealIndex}", mealItems);

                Console.WriteLine($"Completed meal {mealIndex} with {mealItems.Count} items.\n");
            }

            // Output the generated meals
            Console.WriteLine("Generated Meals:");
            foreach (var meal in meals)
            {
                Console.WriteLine(meal.Key);
                foreach (var item in meal.Value)
                {
                    Console.WriteLine($" - {item}");
                }
            }

            return meals;
        }

        private bool AddFoodToMeal(DataRow foodItem, string foodNameColumn, ref float remainingCalories, List<string> mealItems, ref HashSet<string> selectedCategories, Random random)
        {
            float calories = Convert.ToSingle(foodItem["calories"]);
            int portionSizeInGrams = Convert.ToInt32(foodItem["portion_size"]);
            string category = foodItem["category_en"].ToString();

            // Calculate a flexible portion size based on the remaining calories and some randomness
            float maxPortionFactor = remainingCalories / calories;
            float portionFactor = (float)(random.NextDouble() * (maxPortionFactor - 0.5) + 0.5);  // Randomize portion factor between 50% to max possible
            int adjustedPortionSize = (int)(portionSizeInGrams * portionFactor);

            // Calculate the actual calories for the selected portion
            float actualCalories = calories * portionFactor;

            // Ensure we only add the food if it fits within the remaining calories
            if (actualCalories <= remainingCalories)
            {
                string foodName = foodItem[foodNameColumn].ToString();
                mealItems.Add($"{foodName} - {actualCalories:0.0} kcal ({adjustedPortionSize}g)");

                remainingCalories -= actualCalories;

                // Track the category as selected
                selectedCategories.Add(category);

                return true;
            }

            return false;
        }

        private void DisplayMeals(Dictionary<string, List<string>> meals)
        {
            // Dictionary to map meal names to display
            var mealDisplayNames = new Dictionary<string, string>
    {
        { "Breakfast", CommonValues.CurrentUserInfo.IsArabic ? "الإفطار" : "Breakfast" },
        { "Morning Snack", CommonValues.CurrentUserInfo.IsArabic ? "وجبة خفيفة صباحية" : "Morning Snack" },
        { "Lunch", CommonValues.CurrentUserInfo.IsArabic ? "الغداء" : "Lunch" },
        { "Afternoon Snack", CommonValues.CurrentUserInfo.IsArabic ? "وجبة خفيفة مسائية" : "Afternoon Snack" },
        { "Dinner", CommonValues.CurrentUserInfo.IsArabic ? "العشاء" : "Dinner" },
        { "Evening Snack", CommonValues.CurrentUserInfo.IsArabic ? "وجبة خفيفة ليلية" : "Evening Snack" }
    };

            // Clear the existing items in the ListBox
            listBoxDietPlan.Items.Clear();

            // Iterate through each meal in the dictionary
            foreach (var meal in meals)
            {
                // Get the display name for the meal or use the raw key if not found
                string displayName;
                if (mealDisplayNames.TryGetValue(meal.Key, out displayName))
                {
                    listBoxDietPlan.Items.Add($"{displayName}:");
                }
                else
                {
                    listBoxDietPlan.Items.Add($"{meal.Key}:"); // Fallback
                }

                // Add each item in the meal to the ListBox
                foreach (var item in meal.Value)
                {
                    listBoxDietPlan.Items.Add($"  {item}");
                }

                // Add an empty line between meals for clarity
                listBoxDietPlan.Items.Add("");
            }
        }

        private IEnumerable<DataRow> GetSuggestedFoods(DataTable foods, DataTable allergies, DataTable preferences, float tdee)
        {
            var preferredFoodIds = preferences.AsEnumerable().Select(p => Convert.ToInt32(p["food_id"])).ToList();
            var allergyFoodIds = allergies.AsEnumerable().Select(a => Convert.ToInt32(a["food_id"])).ToList();

            var suggestedFoods = foods.AsEnumerable()
                .Where(row => !allergyFoodIds.Contains(Convert.ToInt32(row["food_id"])))
                .Where(row => preferredFoodIds.Count == 0 || preferredFoodIds.Contains(Convert.ToInt32(row["food_id"])))
                .Where(row => Convert.ToSingle(row["calories"]) <= tdee)
                .OrderBy(row => Guid.NewGuid()) // Randomize order for variety
                .ThenBy(row => row[CommonValues.CurrentUserInfo.IsArabic ? "category_ar" : "category_en"]) // Ensure variety of food groups
                .Take(100); // Increase the pool of suggestions for better variety

            return suggestedFoods;
        }

        private float CalculateBMR()
        {
            double weight = CommonValues.CurrentUserInfo.Weight;
            double height = CommonValues.CurrentUserInfo.Height;
            int age = CommonValues.CurrentUserInfo.Age;
            string gender = CommonValues.CurrentUserInfo.Gender;

            if (gender == "Male")
            {
                return (float)(66 + (13.7 * weight) + (5 * height) - (6.8 * age));
            }
            else
            {
                return (float)(655 + (9.6 * weight) + (1.8 * height) - (4.7 * age));
            }
        }

        private float CalculateTDEE(float bmr)
        {
            string activityLevel = CommonValues.CurrentUserInfo.ActivityLevel;

            switch (activityLevel)
            {
                case "Sedentary":
                    return bmr * 1.2f;
                case "Lightly Active":
                    return bmr * 1.375f;
                case "Moderately Active":
                    return bmr * 1.55f;
                case "Very Active":
                    return bmr * 1.725f;
                case "Super Active":
                    return bmr * 1.9f;
                default:
                    return bmr * 1.2f; // Default to sedentary if no valid activity level
            }
        }

        private DataTable GetFoods()
        {
            try
            {
                using (var databaseManagerfo = new DatabaseManagerfo())
                {
                    databaseManagerfo.OpenConnection();

                    string readQuery = "SELECT * FROM Foods";
                    using (var command = new SqlCommand(readQuery, databaseManagerfo.GetConnection()))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            DataTable foodsTable = new DataTable();
                            foodsTable.Load(reader);  // Load the data directly into the DataTable
                            return foodsTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving foods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable(); // Return an empty DataTable in case of error
            }
        }

        private DataTable GetUserAllergies()
        {
            try
            {
                using (var databaseManagerfo = new DatabaseManagerfo())
                {
                    databaseManagerfo.OpenConnection();

                    string readQuery = "SELECT * FROM Allergies WHERE user_id = @UserId";
                    using (var command = new SqlCommand(readQuery, databaseManagerfo.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@UserId", CommonValues.CurrentUserInfo.ID);

                        using (var reader = command.ExecuteReader())
                        {
                            DataTable allergiesTable = new DataTable();
                            allergiesTable.Load(reader);
                            return allergiesTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving user allergies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable GetUserPreferences()
        {
            try
            {
                using (var databaseManagerfo = new DatabaseManagerfo())
                {
                    databaseManagerfo.OpenConnection();

                    string readQuery = "SELECT * FROM Preferences WHERE user_id = @UserId";
                    using (var command = new SqlCommand(readQuery, databaseManagerfo.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@UserId", CommonValues.CurrentUserInfo.ID);

                        using (var reader = command.ExecuteReader())
                        {
                            DataTable preferencesTable = new DataTable();
                            preferencesTable.Load(reader);
                            return preferencesTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving user preferences: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private void btnAddAllergy_Click(object sender, EventArgs e)
        {
            AddAllergy addAllergy = new AddAllergy();
            addAllergy.Show();
        }

        private void btnAddPreference_Click(object sender, EventArgs e)
        {
            AddPreference addPreference = new AddPreference();
            addPreference.Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_MenuEN main_menuEN = new Main_MenuEN();
            main_menuEN.Show();
        }

        private void ApplyArabicLanguage()
        {
            this.RightToLeft = RightToLeft.Yes;
            MealPreferences.Items.Add("3 وجبات");
            MealPreferences.Items.Add("4 وجبات");
            MealPreferences.Items.Add("5 وجبات");
            MealPreferences.Items.Add("6 وجبات");
            NoOfMeals.Text = "عدد الوجبات";
            AddAllergy.Text = "أضف حساسية";
            AddPreference.Text = "أضف تفضيل";
            SuggestDiet.Text = "اقترح الوجبات";
        }

        private void ApplyEnglishLanguage()
        {
            this.RightToLeft = RightToLeft.No;
            MealPreferences.Items.Add("3 meals");
            MealPreferences.Items.Add("4 meals");
            MealPreferences.Items.Add("5 meals");
            MealPreferences.Items.Add("6 meals");
            NoOfMeals.Text = "No. of meals";
            AddAllergy.Text = "Add Allergy";
            AddPreference.Text = "Add Preference";
            SuggestDiet.Text = "Suggest Meals";
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.ForeColor = Color.White;
            NoOfMeals.ForeColor = Color.White;
            Back.Image = Properties.Resources.WBack;
        }

        private void ApplyLightTheme()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            NoOfMeals.ForeColor = Color.Black;
            Back.Image = Properties.Resources.Back;
        }

        private void DietPlaner_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}