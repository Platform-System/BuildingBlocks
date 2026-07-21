using BuildingBlocks.Abstractions;

namespace BuildingBlocks.DateTimes
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
