// See https://aka.ms/new-console-template for more information
using ConsoleTables;
using Fsp.Grpc.Api;
using Grpc.Net.Client;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7217");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message + "\n");

// Request list of parks from grpc service
var parkClient = new Visitor.VisitorClient(channel);
var parkResponse = await parkClient.GetParksAsync(
                  new ParksRequest { });
Console.WriteLine("Enjoy Florida State Parks that start with \"A\" ...");
parkResponse.Parks.ToList().ForEach(i => Console.WriteLine(i + ", "));

// Format grpc service response list data using ConsoleTables 
Console.WriteLine("\n");
ConsoleTable.From(parkResponse.Parks.Select(x => new { x.Name, x.County, x.Size }).ToList()).Write();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();