namespace AzureDevOpsRESTClient;

internal static class Extensions
{
  private const string Message = "Something went wrong. Please try again later.";

  public static async Task HandleEventAsync(Func<Task> eventHandler)
  {
    try
    {
      await eventHandler();
    }
    catch (Exception ex)
    {
      // TODO: Log the exception details (ex) for debugging purposes.
      MessageBox.Show(Message, @"Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}