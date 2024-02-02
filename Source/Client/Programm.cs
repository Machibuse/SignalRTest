using Client;
using Serilog;

try
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .MinimumLevel.Verbose()
        .CreateLogger();

    while (true)
    {
        var connection = new HostConnection(new Uri("http://127.0.0.1:32638/myhub"),args.FirstOrDefault()??Guid.NewGuid().ToString("N").Substring(0,8));
        connection.Run();
    }
}
catch (Exception ex)
{
    Log.Error(ex, "Exception occured");
}
finally
{
    Log.CloseAndFlush();
}