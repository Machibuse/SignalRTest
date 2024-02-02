using Microsoft.AspNetCore.SignalR;

namespace Host;

public class MyHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"OnConnectedAsync {Context.ConnectionId}");
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"OnDisconnectedAsync {Context.ConnectionId} {exception?.Message}");
        return Task.CompletedTask;
    }
}