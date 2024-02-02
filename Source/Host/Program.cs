using Client;
using Host;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Warning);

builder.Services.AddSignalR();
builder.Services.AddSingleton<MyHub>(); //if i remove this line everything works fine 
builder.WebHost.UseUrls("http://*:32638/");

var app = builder.Build();

app.MapHub<MyHub>("/myhub");

var task = app.RunAsync();


Console.WriteLine("waiting 3 seconds to connect the clients");

Thread.Sleep(3000);

for (int i = 0; i < 20; i++)
{
    var t = new Thread(() =>
    {
        while (true)
        {
            var connection = new HostConnection(new Uri("http://127.0.0.1:32638/myhub"),args.FirstOrDefault()??Guid.NewGuid().ToString("N").Substring(0,8));
            connection.Run();
        }
    });
    t.Start();
    Thread.Sleep(1000);
}

Console.ReadKey();



