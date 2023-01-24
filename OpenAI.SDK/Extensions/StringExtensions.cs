namespace OpenAI.GPT3.Extensions
{
    /// <summary>
    ///     Extension methods for string manipulation
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Remove the search string from the beginning of string if exist
        /// </summary>
        /// <param name="text"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static string RemoveIfStartWith(this string text, string search)
        {
            var pos = text.IndexOf(search, StringComparison.Ordinal);
            var length = search.Length;
            return pos == 0 ? text.Substring(length) : text;
        }
    }
}