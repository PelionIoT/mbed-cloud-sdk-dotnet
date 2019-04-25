using System;
using System.Linq;

namespace Manhasset.Generator.src.extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert snake case string to camel case
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="firstLower">If true, first letter will be lower case</param>
        /// <returns>Camel case string</returns>
        public static string ToPascal(this string input, bool firstLower = false)
        {
            if (input != null)
            {
                input = input.Replace("-", "_");
                var newString = new char[input.Length];
                var startIndex = 1;
                var newStringIndex = 1;

                if (firstLower)
                {
                    newString[0] = input[0];
                }
                else
                {
                    if (input[0] == '_')
                    {
                        newString[0] = char.ToUpper(input[1]);
                        startIndex += 1;
                    }
                    else
                    {
                        var firstCap = char.ToUpper(input[0]);
                        newString[0] = firstCap;
                    }
                }

                for (int i = startIndex; i < input.Count(); i++)
                {
                    if (input[i] == '_')
                    {
                        if (i + 1 >= input.Count())
                        {
                            newString[newStringIndex] = '_';
                        }
                        else
                        {
                            newString[newStringIndex] = char.ToUpper(input[i + 1]);
                            newString[newStringIndex + 1] = ' ';
                            i++;
                            newStringIndex += 1;
                        }
                    }
                    else
                    {
                        newString[newStringIndex] = input[i];
                    }

                    newStringIndex += 1;
                }

                return new string(newString.Where(c => !char.IsWhiteSpace(c) && !(c == '\0')).ToArray());
            }

            return string.Empty;
        }

        /// <summary>
        /// Wrapper method that returns camel case stirng with lowercase first letter
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>camelcase string</returns>
        public static string ToCamel(this string input)
        {
            return input.ToPascal(true);
        }

        public static string PascalToCamel(this string input)
        {
            return Char.ToLowerInvariant(input[0]) + input.Substring(1);
        }
    }
}