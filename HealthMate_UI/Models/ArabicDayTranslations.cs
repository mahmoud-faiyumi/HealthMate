using System;
using System.Collections.Generic;

public class ArabicDayTranslations
{
    // Mapping of English day names to Arabic day names
    private Dictionary<string, string> dayTranslations = new Dictionary<string, string>
    {
        { "Sunday", "الأحد" },
        { "Monday", "الاثنين" },
        { "Tuesday", "الثلاثاء" },
        { "Wednesday", "الأربعاء" },
        { "Thursday", "الخميس" },
        { "Friday", "الجمعة" },
        { "Saturday", "السبت" }
    };

    public string GetArabicDayOfWeek(DateTime date)
    {
        string dayOfWeekEnglish = date.DayOfWeek.ToString();

        if (dayTranslations.ContainsKey(dayOfWeekEnglish))
        {
            return dayTranslations[dayOfWeekEnglish];
        }
        else
        {
            return dayOfWeekEnglish;
        }
    }
}