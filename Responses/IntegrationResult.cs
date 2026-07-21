namespace BuildingBlocks.Responses;

public enum IntegrationErrorType
{
    None = 0,
    NotFound = 1,
    InvalidConfiguration = 2,
    Unavailable = 3,
    Unauthorized = 4,
    Unknown = 5
}

public sealed class IntegrationResult<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public IntegrationErrorType ErrorType { get; }
    public string? Error { get; }

    private IntegrationResult(bool isSuccess, T? value, IntegrationErrorType errorType, string? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorType = errorType;
        Error = error;
    }

    public static IntegrationResult<T> Success(T value)
        => new(true, value, IntegrationErrorType.None, null);

    public static IntegrationResult<T> Failure(IntegrationErrorType errorType, string error)
        => new(false, default, errorType, error);
}
