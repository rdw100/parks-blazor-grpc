using Fsp.Pwa.Client;
using Fsp.Grpc.Api;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton(services =>
{
    // Grpc Service URI (normally, appsettings.json)
    var backendUrl = "https://localhost:7217";

    // Create a gRPC-Web channel pointing to the backend server
    var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
    var baseUri = services.GetRequiredService<NavigationManager>().ToAbsoluteUri(backendUrl);
    var channel = GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions { HttpClient = httpClient });

    // Now we can instantiate gRPC clients for this channel
    return new Greeter.GreeterClient(channel);
});

//Add gRPC service
builder.Services.AddSingleton(services =>
{
    // Grpc Service URI (normally, appsettings.json)
    var backendUrl = "https://localhost:7217";

    // Create a gRPC-Web channel pointing to the backend server
    var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
    var channel = GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions { HttpClient = httpClient });

    // Now we can instantiate gRPC clients for this channel
    return new Visitor.VisitorClient(channel);
});

await builder.Build().RunAsync();
