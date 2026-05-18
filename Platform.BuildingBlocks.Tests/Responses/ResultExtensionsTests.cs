using Microsoft.AspNetCore.Mvc;
using Platform.BuildingBlocks.Responses;
using Xunit;

namespace Platform.BuildingBlocks.Tests.Responses;

public sealed class ResultExtensionsTests
{
    [Fact]
    public void ToActionResult_WhenSuccess_ReturnsOkObjectResult()
    {
        var actionResult = Result<string>.Success("value").ToActionResult();

        var okResult = Assert.IsType<OkObjectResult>(actionResult);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public void ToActionResult_WhenStatusCodeExists_ReturnsObjectResultWithThatStatus()
    {
        var actionResult = Result<string>.Failure(409, "Conflict").ToActionResult();

        var objectResult = Assert.IsType<ObjectResult>(actionResult);
        Assert.Equal(409, objectResult.StatusCode);
    }

    [Fact]
    public void ToActionResult_WhenUnauthorizedErrorPresent_ReturnsUnauthorizedObjectResult()
    {
        var actionResult = Result<string>.Failure("Unauthorized access").ToActionResult();

        Assert.IsType<UnauthorizedObjectResult>(actionResult);
    }

    [Fact]
    public void ToActionResult_WhenGenericFailure_ReturnsBadRequestObjectResult()
    {
        var actionResult = Result<string>.Failure("Validation failed").ToActionResult();

        Assert.IsType<BadRequestObjectResult>(actionResult);
    }
}
