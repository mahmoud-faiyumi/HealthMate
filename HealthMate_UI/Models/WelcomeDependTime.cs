using System;

public class WelcomeMessageGenerator
{
    public static string GenerateWelcomeMessage(string firstName)
    {
        // Get the current time
        DateTime currentTime = DateTime.Now;

        // Extract the hour from the current time
        int hour = currentTime.Hour;

        // Generate the welcome message
        string welcomeMessage = GetWelcomeMessage(hour, firstName);

        return welcomeMessage;
    }

    private static string GetWelcomeMessage(int hour, string firstName)
    {
        if (hour >= 6 && hour < 12)
        {
            return $"Good morning, {firstName}";
        }
        else if (hour >= 12 && hour < 18)
        {
            return $"Good afternoon, {firstName}";
        }
        else
        {
            return $"Good evening, {firstName}";
        }
    }
}
