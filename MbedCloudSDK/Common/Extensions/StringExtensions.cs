namespace MbedCloudSDK.Common.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Match a wildcard string with some string
        /// </summary>
        /// <param name="input">The wildcard string</param>
        /// <param name="matchWith">The string to match</param>
        /// <returns></returns>
        public static bool MatchWithWildcard(this string input, string matchWith)
        {
            // match is true if no wildcard or wildcard is matching on anything
            if (string.IsNullOrEmpty(input) || input == "*")
            {
                return true;
            }

            if (string.IsNullOrEmpty(matchWith))
            {
                return false;
            }

            // check string has wildcard condition
            if (input.EndsWith("*"))
            {
                return matchWith.StartsWith(input.TrimEnd('*'));
            }

            // compare strings directly
            return input.Equals(matchWith);
        }
    }
}