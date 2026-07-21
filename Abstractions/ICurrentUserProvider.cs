namespace BuildingBlocks.Abstractions;

public interface ICurrentUserProvider
{
    string? CurrentUserId { get; }
}
