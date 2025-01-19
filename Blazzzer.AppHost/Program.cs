var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Blazzzer_ApiService>("apiservice");

builder.AddProject<Projects.Blazzzer_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
