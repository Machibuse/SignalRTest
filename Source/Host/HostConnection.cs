using Microsoft.AspNetCore.SignalR.Client;


namespace Client;

public class HostConnection 
{
    public HostConnection(Uri url, string username)
    {
        HubConnection = new HubConnectionBuilder().WithUrl(url).Build();
        
        HubConnection.Closed += _ =>
        {
            Console.WriteLine("Connection Closed");
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
                Console.WriteLine("Start");
                HubConnection.StartAsync().Wait();
                Console.WriteLine("Connected");
            }
            catch (Exception)
            {
                Console.WriteLine("Start SignalR Connection failed");
                return;
            }
            while (!ConnectionClosed)
            {
                Thread.Sleep(1);
            }

            Console.WriteLine("Disconnected");
        }
        finally
        {
            HubConnection.DisposeAsync().GetAwaiter().GetResult();
        }
    }
}