IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Http_API>("http.api");

// add other services
// builder.AddProject("service", "../../src/Microservice/StandaloneService/StandaloneService.csproj");

builder.Build().Run();
