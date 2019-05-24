namespace das.Extensions.Logger.Extensions
{
    internal static class StringEx
    {
        internal static string ValueOrDefault(this string value, string defaultValue)
        {
            return !string.IsNullOrEmpty(value) ? value : defaultValue;
        }
    }
}
