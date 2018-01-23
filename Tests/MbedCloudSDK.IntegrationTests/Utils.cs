using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestServer
{
    public static class Utils
    {
        public static string SnakeToCamel(string input, bool firstLower = false)
        {
            var newString = new Char[input.Length];

            if (firstLower)
            {
                newString[0] = input[0];
            }
            else
            {
                var firstCap = char.ToUpper(input[0]);
                newString[0] = firstCap;
            }

            for (int i = 1; i < input.Count(); i++)
            {
                if (input[i] == '_')
                {
                    newString[i] = char.ToUpper(input[i + 1]);
                    newString[i + 1] = ' ';
                    i++;
                }
                else
                {
                    newString[i] = input[i];
                }
            }
            return new string(newString.Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        public static string SnakeToLowerCamel(string input)
        {
            return SnakeToCamel(input, true);
        }

        public static string CamelToSnake(string input)
        {
            return string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        public static Dictionary<string, object> SnakeToCamelDict(Dictionary<string, Microsoft.Extensions.Primitives.StringValues> nameValueCollection)
        {
            var dict = new Dictionary<string, object>();

            foreach(var k in nameValueCollection.Keys)
            {
                var key = SnakeToCamel(k).ToUpper();
                dict.Add(key, nameValueCollection[k].FirstOrDefault());
            }

            return dict;
        }
    }
}
