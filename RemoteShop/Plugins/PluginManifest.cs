namespace RemoteShop.Plugins;

public sealed record PluginManifest(
    string Id,
    string Name,
    string Version,
    string EntryAssembly,
    string EntryType,
    string RemoteShopVersion,
    IReadOnlyList<string> Dependencies);
