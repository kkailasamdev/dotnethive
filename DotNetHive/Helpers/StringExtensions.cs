using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHive.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Splits a string into substrings that are based on the characters in an array, in a deferred manner.
        /// </summary>
        /// <param name="input">Original string.</param>
        /// <param name="separator">Separator(s).</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitOnDemand(this string input, char[] separator, int count = int.MaxValue)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) yield break;

            var stringBuilder = new StringBuilder();
            count--;
            for (int i = 0; i < input.Length; i++)
            {
                if (count == 0)
                {
                    yield return input.Substring(i);
                    yield break;
                }

                var character = input[i];
                if (!separator.Contains(character))
                {
                    stringBuilder.Append(character);
                    continue;
                }
                yield return stringBuilder.ToString();
                stringBuilder.Clear();
                count--;
            }

            if (stringBuilder.Length > 0) yield return stringBuilder.ToString();
        }
    }
}
