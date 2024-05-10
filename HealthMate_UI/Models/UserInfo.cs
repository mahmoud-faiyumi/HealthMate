using System;
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
}