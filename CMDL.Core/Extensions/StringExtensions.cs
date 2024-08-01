namespace CMDL.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str);
        public static bool IsNotEmpty(this string str) => !str.IsEmpty();
    }
}
