namespace Doily.API.Common;

public abstract record ServiceResult
{
    public bool IsSuccess { get; init; }
    public bool IsFailure => !IsSuccess;
    public string ErrorMessage { get; init; } = string.Empty;

    public static ServiceResult Fail(string message) => new Failure(message);

    private record Success : ServiceResult { public Success() { IsSuccess = true; } }
    private record Failure : ServiceResult
    {
        public Failure(string message)
        {
            IsSuccess = false;
            ErrorMessage = message;
        }
    }
}

public sealed record ServiceResult<T> : ServiceResult
{
    public T? Value { get; init; }

    private ServiceResult() { }

    public static ServiceResult<T> Success(T value) => new()
    {
        IsSuccess = true,
        Value = value
    };

    public static new ServiceResult<T> Fail(string message) => new()
    {
        IsSuccess = false,
        ErrorMessage = message
    };
}