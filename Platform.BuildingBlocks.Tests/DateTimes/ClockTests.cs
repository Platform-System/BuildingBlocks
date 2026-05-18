using Platform.BuildingBlocks.Abstractions;
using Platform.BuildingBlocks.DateTimes;
using Xunit;

namespace Platform.BuildingBlocks.Tests.DateTimes;

public sealed class ClockTests
{
    [Fact]
    public void SetProvider_WhenCalled_UsesCustomProvider()
    {
        var expected = new DateTime(2026, 5, 18, 8, 30, 0, DateTimeKind.Utc);
        Clock.SetProvider(new FakeDateTimeProvider(expected));

        Assert.Equal(expected, Clock.Now);

        Clock.SetProvider(new SystemDateTimeProvider());
    }

    private sealed class FakeDateTimeProvider(DateTime utcNow) : IDateTimeProvider
    {
        public DateTime UtcNow { get; } = utcNow;
    }
}
