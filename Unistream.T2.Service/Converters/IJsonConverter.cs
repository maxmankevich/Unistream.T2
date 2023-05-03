namespace Unistream.T2.Service.Converters;

public interface IJsonConverter
{
    string Serialize(object? value);
    T? Deserialize<T>(string json);
}