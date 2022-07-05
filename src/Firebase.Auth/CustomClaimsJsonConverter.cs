using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Firebase.Auth
{
    public class CustomClaimsJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string) || objectType == typeof(Dictionary<string, object>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<string, object> dict;

            if (reader.Value is string json)
            {
                try
                {
                    dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    return dict;
                }
                catch
                {
                }
            }

            dict = new Dictionary<string, object>();
            dict.Add("customClaims", reader.Value);

            return dict;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is Dictionary<string, object> obj)
            {
                writer.WriteValue(JsonConvert.SerializeObject(obj));
            }
            else
            {
                writer.WriteValue(JsonConvert.SerializeObject(value)); 
            }
        }
    }
}
