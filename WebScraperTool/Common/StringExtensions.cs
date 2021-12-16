using System;

namespace WebScraperTool
{
    public static class StringExtensions
    {
        public static int ToInt(this string value, int defaultValue = 0)
        {
            if (Int32.TryParse(value, out int result))
                return result;
            return defaultValue;
        }
    }
}
