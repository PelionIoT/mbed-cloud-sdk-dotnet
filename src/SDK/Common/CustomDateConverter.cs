using Newtonsoft.Json.Converters;

namespace Mbed.Cloud.Common
{
    public class CustomDateConverter : IsoDateTimeConverter
    {
        public CustomDateConverter(string dateFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ")
        {
            DateTimeFormat = dateFormat;
        }
    }
}