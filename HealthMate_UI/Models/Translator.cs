using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMate_UI.Models
{
    public class Translator
    {
        public static string TranslateActivityLevel(string input)
        {
            switch (input)
            {
                case "كسول":
                    return "Lazy";
                case "خفيف":
                    return "Lightly";
                case "متوسط":
                    return "Medium";
                case "نشيط":
                    return "Active";
                default:
                    // If the input doesn't match any known activity level, return the input as is.
                    return input;
            }
        }

        public static string TranslateGender(string input)
        {
            switch (input)
            {
                case "ذكر":
                    return "Male";
                case "أنثى":
                    return "Female";
                default:
                    // If the input doesn't match any known gender, return the input as is.
                    return input;
            }
        }
    }

}