using Newtonsoft.Json;

namespace AzureDevOpsRESTClient.Common;

public class Result<T> : Result
{
  public T Value { get; }

  [JsonConstructor]
  protected internal Result(T value, bool isSuccess, string failMessage) :
    base(isSuccess, failMessage)
  {
    Value = value;
  }
}