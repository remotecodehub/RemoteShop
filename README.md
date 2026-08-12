# RemoteShop

RemoteShop is a .NET 10 single-project Blazor Server application with ASP.NET Core controllers, EF Core/SQL Server, MudBlazor and a restart-based plugin architecture inspired by WordPress + WooCommerce.

## Architecture

- `RemoteShop/` — single executable ASP.NET Core + Blazor Server project.
- `Application/` — application services and contracts.
- `Domain/` — persistence/domain models.
- `Infrastructure/` — EF Core and plugin loading infrastructure.
- `Plugins/` — installed plugin packages and plugin contracts.
- `Components/` — Blazor UI.
- `Controllers/` — HTTP API/controller surface.
- `docs/` — architecture and plugin authoring rules.
- `.github/` — repository instructions and development rules.

Plugins are installed into the configured plugin directory. Installation is persisted first; after a successful installation the application exits intentionally so the hosting process/container restarts and the plugin is loaded into the DI container during startup. Runtime hot-swapping is deliberately not supported.

The WooCommerce integration is represented by an explicit application boundary. The repository currently has no WooCommerce submodule/content, so no external implementation was assumed or copied.

## Local development

```bash
dotnet restore
dotnet build
 dotnet run --project RemoteShop/RemoteShop.csproj
```

Set `ConnectionStrings:DefaultConnection` to a SQL Server instance before applying migrations.
