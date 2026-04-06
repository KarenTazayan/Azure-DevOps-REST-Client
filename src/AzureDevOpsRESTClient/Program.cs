using Syncfusion.Licensing;

namespace AzureDevOpsRESTClient;

internal static class Program
{
  /// <summary>
  ///  The main entry point for the application.
  /// </summary>
  [STAThread]
  private static void Main()
  {
    var license = Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY");

    SyncfusionLicenseProvider.RegisterLicense(license);
    
    // To customize application configuration such as set high DPI settings or default font,
    // see https://aka.ms/applicationconfiguration.
    ApplicationConfiguration.Initialize();
    Application.Run(new Main());
  }
}