using backend.Web;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Add controllers so Web API endpoints can be exposed (e.g. /api/artworks)
builder.Services.AddControllers();

// Configure a typed HttpClient for calling the API from this service/application.
// The base address can be overridden by setting configuration key "ApiBaseUrl".
builder.Services.AddHttpClient<ApiClient>(client =>
{
    var baseUrl = builder.Configuration["ApiBaseUrl"];
    client.BaseAddress = string.IsNullOrEmpty(baseUrl)
        ? new Uri("https://localhost:7200/")
        : new Uri(baseUrl);
});

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

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

// Allow cross-origin requests from configured frontend origins
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.MapControllers();

app.MapDefaultEndpoints();

app.Run();
