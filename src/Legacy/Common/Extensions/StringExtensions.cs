// <copyright file="StringExtensions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Extensions
{
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Check if string is valid Json
        /// </summary>
        /// <param name="strInput">string to check</param>
        /// <returns>Bool</returns>
        public static bool IsValidJson(this string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
                (strInput.StartsWith("[") && strInput.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException)
                {
                    // Exception in parsing json
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Convert snake case string to camel case
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="firstLower">If true, first letter will be lower case</param>
        /// <returns>Camel case string</returns>
        public static string SnakeToCamel(this string input, bool firstLower = false)
        {
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

        /// <summary>
        /// Wrapper method that returns camel case stirng with lowercase first letter
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>camelcase string</returns>
        public static string SnakeToLowerCamel(this string input)
        {
            return input.SnakeToCamel(true);
        }

        /// <summary>
        /// Convert camelcase string to snake case
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>snake case string</returns>
        public static string CamelToSnake(this string input)
        {
            return string.Concat(input.Select((x, i) =>
            {
                return (i >= 0 && char.IsUpper(x)) ? "_" + x.ToString() : x.ToString();
            })).ToLower();
        }

        /// <summary>
        /// Match a wildcard string with some string
        /// </summary>
        /// <param name="input">The wildcard string</param>
        /// <param name="matchWith">The string to match</param>
        /// <returns>True if matches</returns>
        public static bool MatchWithWildcard(this string input, string matchWith)
        {
            // nothing to match with
            if (string.IsNullOrEmpty(matchWith))
            {
                return false;
            }

            // match is true if no wildcard or wildcard is matching on anything
            if (string.IsNullOrEmpty(input) || input == "*")
            {
                return true;
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