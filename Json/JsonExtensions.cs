using System.Text.Json;

namespace Platform.BuildingBlocks.Json;

public static class JsonExtensions
{
    public static string ToJson<T>(this T obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static T DeserializeOrNew<T>(this string json) where T : new()
    {
        return JsonSerializer.Deserialize<T>(json) ?? new T();
    }
}
