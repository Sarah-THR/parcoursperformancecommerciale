using FastEndpoints.Swagger;
using FastEndpoints;
using Microsoft.AspNetCore.HttpOverrides;
using EcoleDeLaPerformance.API.Infrastructure._Helpers;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Requests;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Requests;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.TaskPlanningUC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Services.SwaggerDocument();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUsersRequest).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetWeekNoteByUserRequest).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllTaskPlanningRequest).Assembly));

// Register auto mapper (configuration in AutoMapper namespace)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Setup Environement variables 
builder.Configuration.AddEnvironmentVariables();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardLimit = 2;
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

// Setup Entity Framework
ServiceCollectionBuilder.ConfigureDBContext(builder.Services, builder.Configuration);

ServiceCollectionBuilder.ConfigureServices(builder.Services);

var app = builder.Build();

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
});

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseForwardedHeaders();
    app.UseOpenApi();
    app.UseSwaggerUi(s => s.ConfigureDefaults());
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseForwardedHeaders();
}

app.Use((context, next) =>
{
    context.Request.Scheme = "https";
    return next();
});

app.UseHttpsRedirection();

app.Run();

public partial class Program
{ }