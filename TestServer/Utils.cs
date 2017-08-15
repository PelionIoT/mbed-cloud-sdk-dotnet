using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
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

        public static Dictionary<string, object> SnakeToCamelDict(NameValueCollection nameValueCollection)
        {
            var dict = new Dictionary<string, object>();

            foreach(var k in nameValueCollection.AllKeys)
            {
                dict.Add(SnakeToCamel(k).ToUpper(), nameValueCollection[k]);
            }

            return dict;
        }

        public static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings us empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: " + key + "Value:" + appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public static object ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key];
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                return null;
            }
        }

        public static void UpdateAppSetting(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
