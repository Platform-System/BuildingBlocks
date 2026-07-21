using Microsoft.Extensions.DependencyInjection;
using BuildingBlocks.Abstractions;
using BuildingBlocks.DateTimes;

namespace BuildingBlocks.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddBuildingBlocks(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
        return services;
    }
}
