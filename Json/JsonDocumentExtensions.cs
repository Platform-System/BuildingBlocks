using System.Text.Json;

namespace Platform.BuildingBlocks.Json;

public static class JsonDocumentExtensions
{
    public static Dictionary<string, object?> ToDictionary(this JsonDocument? doc)
    {
        if (doc == null) return new Dictionary<string, object?>();

        var json = doc.RootElement.GetRawText();
        return JsonSerializer.Deserialize<Dictionary<string, object?>>(json) ?? new Dictionary<string, object?>();
    }

    public static JsonDocument ToJsonDocument<T>(this T obj)
    {
        if (obj == null) return JsonDocument.Parse("{}");
        var json = JsonSerializer.Serialize(obj);
        return JsonDocument.Parse(json);
    }

    public static T? GetProperty<T>(this JsonDocument? doc, string propertyName)
    {
        if (doc == null) return default;

        try
        {
            if (doc.RootElement.TryGetProperty(propertyName, out var element))
            {
                return JsonSerializer.Deserialize<T>(element.GetRawText());
            }
        }
        catch { }

        return default;
    }
}
