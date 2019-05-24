namespace das.Extensions.Logger.Extensions
{
    public static class StringEx
    {
        public static string ValueOrDefault(this string value, string defaultValue)
        {
            return !string.IsNullOrEmpty(value) ? value : defaultValue;
        }
    }
}
