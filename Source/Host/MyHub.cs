using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Host.Code;

[Authorize]
public class MyHub : Hub
{
    public MyHub(ILogger<MyHub> logger)
    {
        Console.WriteLine("MyHub created");
        Logger = logger;
    }

    public ILogger<MyHub> Logger { get; }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"OnConnectedAsync {Context.UserIdentifier} {Context.ConnectionId}");
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"OnDisconnectedAsync {Context.UserIdentifier} {Context.ConnectionId} {exception?.Message}");
        return Task.CompletedTask;
    }
}