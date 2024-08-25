using HealthMate_UI.Constants;
using HealthMate_UI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HealthMate_UI.Screens
{
    public class FoodLoader
    {
        public List<Foodcategory> Fruit { get; private set; }
        public List<Foodcategory> Meat { get; private set; }
        public List<Foodcategory> Fish { get; private set; }
        public List<Foodcategory> Vegetable { get; private set; }
        public List<Foodcategory> Grain { get; private set; }
        public List<Foodcategory> Nut { get; private set; }
        public List<Foodcategory> Dairy { get; private set; }

        public FoodLoader()
        {
            LoadFood();
        }

        private void LoadFood()
        {
            Fruit = LoadFoodcategory("Fruit");
            Meat = LoadFoodcategory("Meat");
            Fish = LoadFoodcategory("Fish");
            Vegetable = LoadFoodcategory("Vegetable");
            Grain = LoadFoodcategory("Grain");
            Nut = LoadFoodcategory("Nut");
            Dairy = LoadFoodcategory("Dairy");
        }

        private List<Foodcategory> LoadFoodcategory(string category)
        {
            var foodcategory = new List<Foodcategory>();
            try
            {
                using (var databaseManager = new DatabaseManagerwo())
                {
                    databaseManager.OpenConnection();
                    string readQuery = $"SELECT * FROM [FoodDB].[dbo].[Foods] WHERE category_en = @Category";
                    using (var command = new SqlCommand(readQuery, databaseManager.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Category", category);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var food = new Foodcategory
                                {
                                    food_id = (int)reader["food_id"],
                                    food_name_en = (string)reader["food_name_en"],
                                    food_name_ar = (string)reader["food_name_ar"],
                                    portion_size = (int)reader["portion_size"],
                                    calories = (int)reader["calories"],
                                    category_en = ((string)reader["category_en"]).Split(',').ToList(),
                                    category_ar = ((string)reader["category_ar"]).Split(',').ToList(),
                                };
                                foodcategory.Add(food);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return foodcategory;
        }

        public Foodcategory GetFoodByName(string foodName)
        {
            var allFood = Fruit.Concat(Meat).Concat(Fish).Concat(Vegetable).Concat(Grain).Concat(Nut).Concat(Dairy);
            if (CommonValues.CurrentUserInfo.IsArabic)
            {
                return allFood.FirstOrDefault(f => f.food_name_ar.Equals(foodName, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                return allFood.FirstOrDefault(f => f.food_name_en.Equals(foodName, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}