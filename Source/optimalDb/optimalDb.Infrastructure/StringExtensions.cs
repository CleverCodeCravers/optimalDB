namespace optimalDb.Infrastructure;

public static class StringExtensions
{
    public static int ToInt(this object? input, int defaultValue = 0)
    {
        if (input == null)
            return defaultValue;

        if (int.TryParse(input.ToString(), out var value))
            return value;

        return defaultValue;
    }
}