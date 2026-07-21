using BuildingBlocks.Json;
using System.Text.Json;
using Xunit;

namespace BuildingBlocks.Tests.Extensions;

public sealed class JsonExtensionsTests
{
    [Fact]
    public void ToDictionary_WhenDocumentIsNull_ReturnsEmptyDictionary()
    {
        JsonDocument? document = null;

        var result = document.ToDictionary();

        Assert.Empty(result);
    }

    [Fact]
    public void ToJsonDocument_WhenObjectExists_CreatesJsonDocument()
    {
        var doc = new { Name = "Hung", Age = 20 }.ToJsonDocument();

        Assert.Equal("Hung", doc.RootElement.GetProperty("Name").GetString());
        Assert.Equal(20, doc.RootElement.GetProperty("Age").GetInt32());
    }

    [Fact]
    public void GetProperty_WhenPropertyExists_ReturnsTypedValue()
    {
        using var doc = JsonDocument.Parse("""{"count":5,"name":"demo"}""");

        var count = doc.GetProperty<int>("count");
        var name = doc.GetProperty<string>("name");

        Assert.Equal(5, count);
        Assert.Equal("demo", name);
    }

    [Fact]
    public void GetProperty_WhenPropertyMissing_ReturnsDefault()
    {
        using var doc = JsonDocument.Parse("""{"count":5}""");

        var value = doc.GetProperty<string>("missing");

        Assert.Null(value);
    }
}
