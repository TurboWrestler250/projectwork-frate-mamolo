using frontend.Components;
using frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiBase = builder.Configuration["ApiBaseUrl"] ?? builder.Configuration["Logging:Endpoints"] ?? "https://localhost:7200/";
builder.Services.AddHttpClient<IArtworksService, ArtworksService>(client => { client.BaseAddress = new Uri(apiBase); });

builder.Services.AddScoped<IExhibitionsService, ExhibitionsService>();
builder.Services.AddScoped<IArtworksService, ArtworksService>();
builder.Services.AddHttpClient<IGuidedToursService, GuidedToursService>(client => { client.BaseAddress = new Uri(apiBase); });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
