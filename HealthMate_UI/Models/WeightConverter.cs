public static class WeightConverter
{
    public static double ConvertWeight(double weightInput, bool toKG)
    {
        if (toKG)
        {
            // Convert LB to KG (1 pound = 0.45359237 kg)
            return weightInput * 0.45359237;
        }
        else
        {
            return weightInput;
        }
    }
}