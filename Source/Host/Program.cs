using Host.Code;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Warning);


builder.Services.AddAuthentication(MyAuthenticationOptions.DefaultScheme)
    .AddScheme<MyAuthenticationOptions, MyAuthenticationHandler>(
        MyAuthenticationOptions.DefaultScheme, null);


builder.Services.AddSignalR();

builder.Services.AddSingleton<MyHub>();

builder.WebHost.UseUrls("http://*:32638/");

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<MyHub>("/myhub");

app.MapGet("/", () => "Nothing to see");

var runAsync = app.RunAsync();

Console.WriteLine("any key to end/restart app");
Console.ReadKey();
Console.WriteLine("***** end *****");
await app.StopAsync();
