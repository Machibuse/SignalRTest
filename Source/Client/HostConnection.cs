using Microsoft.AspNetCore.SignalR.Client;
using Serilog;

namespace Client;

public class HostConnection 
{
    public HostConnection(Uri url, string username)
    {
        Log.Information("Creating Connection as {UserName}", username);
        
        HubConnection = new HubConnectionBuilder().WithUrl(url, options => options.Headers.Add("X-AuthToken", username)).Build();
        
        HubConnection.Closed += _ =>
        {
            Log.Information("Connection Closed");
            this.ConnectionClosed = true;
            return Task.CompletedTask;
        };
    }

    public bool ConnectionClosed { get; set; }

    private HubConnection HubConnection { get; }


    public void Run()
    {
        try
        {
            try
            {
                Log.Information("Start");
                HubConnection.StartAsync().Wait();
                Log.Information("Connected");
            }
            catch (Exception)
            {
                Log.Error("Start SignalR Connection failed");
                return;
            }
            while (!ConnectionClosed)
            {
                Thread.Sleep(1);
            }
            Log.Information("Disconnected");
        }
        finally
        {
            HubConnection.DisposeAsync().GetAwaiter().GetResult();
        }
    }
}