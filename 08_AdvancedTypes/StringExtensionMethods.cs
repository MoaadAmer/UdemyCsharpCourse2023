namespace _08_AdvancedTypes
{
    public static class StringExtensionMethods
    {

        public static int? ToIntOrNull(this string str)
        {
            if (int.TryParse(str, out int parsedValue))
            {
                return parsedValue;
            }
            return null;
        }

        public static long? ToLongOrNull(this string str)
        {
            if (long.TryParse(str, out long parsedValue))
            {
                return parsedValue;
            }
            return null;
        }
    }
}
