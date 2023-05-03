using Newtonsoft.Json;

namespace Unistream.T2.Service.Converters
{
    internal class JsonConverter : IJsonConverter
    {
        public string Serialize(object? value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public T? Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}