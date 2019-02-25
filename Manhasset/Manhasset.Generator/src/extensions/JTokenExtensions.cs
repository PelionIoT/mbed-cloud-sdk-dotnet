using System;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src.extensions
{
    public static class JTokenExtensions
    {
        public static string GetStringValue(this JToken me)
        {
            if (me == null)
            {
                return null;
            }

            return me.Value<string>();
        }

        public static bool GetBoolValue(this JToken me)
        {
            if (me == null)
            {
                return false;
            }

            // TODO remove when required bug is fixed
            if (me is JArray)
            {
                return false;
            }

            return me.Value<bool>();
        }
    }
}