using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeacherViewModels.UtilityJsonConvertor
{
    public class CurrencyIntegerConvertor : JsonConverter
    {
        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType) => objectType == typeof(string);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

            JToken t = JToken.FromObject(string.Format("{0:N0}", value));
            t.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            return Convert.ToInt32(token.ToString().Replace(",", ""));

        }
    }
}
