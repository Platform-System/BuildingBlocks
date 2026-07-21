using BuildingBlocks.Responses;
using Xunit;

namespace BuildingBlocks.Tests.Responses;

public sealed class ResultTests
{
    [Fact]
    public void Success_WhenCalled_ReturnsSuccessfulResult()
    {
        var result = Result<string>.Success("ok");

        Assert.True(result.IsSuccess);
        Assert.Equal("ok", result.Value);
        Assert.Empty(result.Errors);
        Assert.Null(result.StatusCode);
    }

    [Fact]
    public void Failure_WhenErrorsMissing_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Result<string>.Failure());
    }

    [Fact]
    public void Failure_WithStatusCode_PopulatesErrorsAndStatus()
    {
        var result = Result<string>.Failure(503, "Unavailable");

        Assert.False(result.IsSuccess);
        Assert.Equal(503, result.StatusCode);
        Assert.Contains("Unavailable", result.Errors);
    }
}
