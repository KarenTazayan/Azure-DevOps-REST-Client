using Newtonsoft.Json;

namespace AzureDevOpsRESTClient;

public class Result
{
    public bool IsSuccess { get; }

    public string FailMessage { get; }

    [JsonConstructor]
    protected Result(bool isSuccess, string failMessage)
    {
        if (isSuccess && failMessage != null || !isSuccess && failMessage == null)
        {
            throw new InvalidOperationException($"Can't initialize an instance of {nameof(Result)} type.");
        }

        IsSuccess = isSuccess;
        FailMessage = failMessage;
    }

    public static Result CreateFail(string failMessage)
    {
        return new Result(false, failMessage);
    }

    public static Result<T> CreateFail<T>(string failMessage)
    {
        return new Result<T>(default(T), false, failMessage);
    }

    public static Result CreateSuccess()
    {
        return new Result(true, null);
    }

    public static Result<T> CreateSuccess<T>(T value)
    {
        return new Result<T>(value, true, null);
    }
}