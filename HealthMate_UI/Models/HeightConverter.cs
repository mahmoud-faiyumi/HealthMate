public static class HeightConverter
{
    public static double ConvertHeight(double heightInput, bool toCentimeters)
    {
        if (toCentimeters)
        {
            // Convert inches to cm (1 inch = 2.54 cm)
            return heightInput * 2.54;
        }
        else
        {
            return heightInput;
        }
    }
}