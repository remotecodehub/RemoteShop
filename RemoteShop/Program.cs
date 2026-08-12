using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using RemoteShop.Application;
using RemoteShop.Infrastructure.Data;
using RemoteShop.Infrastructure.Plugins;
using RemoteShop.Plugins;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddMudServices();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection is required.");

builder.Services.AddDbContextFactory<RemoteShopDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPluginInstallationService, PluginInstallationService>();
builder.Services.AddSingleton<IPluginCatalog, PluginCatalog>();

var pluginLoader = new PluginLoader(builder.Environment.ContentRootPath);
pluginLoader.LoadInstalledPlugins(builder.Services);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapControllers();
app.MapRazorComponents<RemoteShop.Components.App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();
