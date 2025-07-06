var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Scribbly_Validation_Cookbook_ApiService>("scrb-valid");

builder.Build().Run();
