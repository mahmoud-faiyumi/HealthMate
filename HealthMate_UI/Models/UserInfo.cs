using System;
using System.Collections.Generic;
using System.Drawing;

namespace HealthMate_UI.Models
{
    public class UserInfo
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string PasswordFromDB { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public string ActivityLevel { get; set; }
        public double BMI { get; set; }
        public bool IsArabic { get; set; }
        public bool IsDark { get; set; }
        public bool IsPPNull { get; set; }
        public Image PP { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsCoach { get; set; }
        public int ID { get; set; }
        public int CoachID { get; set; }
    }
    public class Exercise
    {
        public int Id { get; set; }
        public string ExName { get; set; }
        public List<string> MuscleGroups { get; set; }
        public string GifResourceName { get; set; }
        public string YouTubeLink { get; set; }
        public int Duration { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public float MetValue { get; set; }
    }

    public class Foodcategory
    {
        public int food_id { get; set; }
        public string food_name_en { get; set; }
        public string food_name_ar { get; set; }
        public int portion_size { get; set; }
        public int calories { get; set; }
        public List<string> category_en { get; set; }
        public List<string> category_ar { get; set; }
    }
}