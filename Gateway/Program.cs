using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromMemory(new[]
    {
        new RouteConfig
        {
            RouteId = "catalog",
            ClusterId = "catalog-cluster",
            Match = new() {Path = "/catalog/{**catch-all}"}
        },
         new RouteConfig
        {
            RouteId = "assignment",
            ClusterId = "assignment-cluster",
            Match = new() {Path = "/assignment/{**catch-all}"}
        },
          new RouteConfig
        {
            RouteId = "evaluation",
            ClusterId = "evaluation-cluster",
            Match = new () {Path = "/evaluation/{**catch-all"}

        },
    },
    new[]
    {
        new ClusterConfig
        {
            ClusterId = "catalog-cluster",
            Destinations = new Dictionary<string, DestinationConfig>
            {
                { "d1", new DestinationConfig { Address = "http://catalog-api:8080/api" } }
            },
        },
        new ClusterConfig
        {
            ClusterId = "assignment-cluster",
            Destinations = new Dictionary<string, DestinationConfig>
            {
             { "d1", new DestinationConfig { Address = "http://assignment-api:8080/api" } }
            },
        },
        new ClusterConfig
        {
            ClusterId = "evaluation-cluster",
            Destinations = new Dictionary<string, DestinationConfig>
            {
             { "d1", new DestinationConfig { Address = "http://evaluation-api:8080/api" } }
            },
        },
    });

var app = builder.Build();
app.MapGet("/health", () => Results.Ok(new { service = "Gateway", status = "Running" }));
app.MapReverseProxy();
app.Run();
