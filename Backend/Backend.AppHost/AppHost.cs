var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Backend_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.Backend_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddProject<Projects.Frontend>("frontend");

builder.Build().Run();
