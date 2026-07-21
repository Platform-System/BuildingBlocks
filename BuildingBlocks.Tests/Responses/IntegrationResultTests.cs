using BuildingBlocks.Responses;
using Xunit;

namespace BuildingBlocks.Tests.Responses;

public sealed class IntegrationResultTests
{
    [Fact]
    public void Success_WhenCalled_ReturnsValueAndNoneError()
    {
        var result = IntegrationResult<int>.Success(42);

        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
        Assert.Equal(IntegrationErrorType.None, result.ErrorType);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Failure_WhenCalled_ReturnsErrorMetadata()
    {
        var result = IntegrationResult<int>.Failure(IntegrationErrorType.Unavailable, "service down");

        Assert.False(result.IsSuccess);
        Assert.Equal(IntegrationErrorType.Unavailable, result.ErrorType);
        Assert.Equal("service down", result.Error);
        Assert.Equal(0, result.Value);
    }
}
