using Microsoft.Extensions.DependencyInjection;

namespace RemoteShop.Plugins;

public interface IRemoteShopPlugin
{
    PluginManifest Manifest { get; }

    void ConfigureServices(IServiceCollection services);
}
