using backend.ApiService;
using backend.ApiService.Endpoints;
using backend.ApiService.Services;
using Dapper;
//using System;

SqlMapper.AddTypeHandler(new GuidTypeHandler());

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Add controllers so Web API endpoints can be exposed (e.g. /api/artworks)
//builder.Services.AddControllers();

// Configure a typed HttpClient for calling the API from this service/application.
// The base address can be overridden by setting configuration key "ApiBaseUrl".
//builder.Services.AddHttpClient<ApiClient>(client =>
//{
//    var baseUrl = builder.Configuration["ApiBaseUrl"];
//    client.BaseAddress = string.IsNullOrEmpty(baseUrl)
//        ? new Uri("https://localhost:7200/")
//        : new Uri(baseUrl);
//});

// Allow frontend apps to call these endpoints. Adjust origins to match your frontend.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("https://localhost:7231", "http://localhost:5173")
              .AllowCredentials();
    });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IArtworksDataAccess, ArtworksDataAccess>();
//builder.Services.AddScoped<IArtworksDataAccess, ArtworksDataAccess>();
//builder.Services.AddScoped<IArtworksDataAccess, ArtworksDataAccess>();
//builder.Services.AddScoped<IArtworksDataAccess, ArtworksDataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

// Allow cross-origin requests from configured frontend origins
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


//app.MapControllers();

/*
 * /health: Endpoints di readiness che verifica se l'app è pronta a ricevere traffico (richiede il passaggio di tutti i health check). 
 * /alive: Endpoints di liveness che verifica se il processo è ancora attivo e non ha crashato (richiede solo il passaggio dei check taggati come "live").
 */
/// <summary>
/// Descrizione del metodo.
/// </summary>
//app.MapDefaultEndpoints();

app.MapArtworksEndpoints();

app.Run();
