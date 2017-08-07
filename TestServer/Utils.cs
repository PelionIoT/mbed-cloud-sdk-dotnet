using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    public static class Utils
    {
        public static string SnakeToCamel(string input)
        {
            var newString = new Char[input.Length];
            var firstCap = char.ToUpper(input[0]);
            newString[0] = firstCap;
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

        public static Dictionary<string, object> SnakeToCamelDict(NameValueCollection nameValueCollection)
        {
            var dict = new Dictionary<string, object>();

            foreach(var k in nameValueCollection.AllKeys)
            {
                dict.Add(SnakeToCamel(k), nameValueCollection[k]);
            }

            //var keysToUpdate = dict.Keys;

            //foreach(var keyToUpdate in keysToUpdate)
            //{
            //    var newKey = SnakeToCamel(keyToUpdate);
            //    var val = dict[keyToUpdate];

            //    dict.Remove(keyToUpdate);
            //    dict.Add(newKey, val);
            //}

            return dict;
        }
    }
}
