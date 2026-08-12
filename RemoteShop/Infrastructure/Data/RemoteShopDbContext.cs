using Microsoft.EntityFrameworkCore;
using RemoteShop.Infrastructure.Data.Entities;

namespace RemoteShop.Infrastructure.Data;

public sealed class RemoteShopDbContext(DbContextOptions<RemoteShopDbContext> options) : DbContext(options)
{
    public DbSet<InstalledPlugin> InstalledPlugins => Set<InstalledPlugin>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InstalledPlugin>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasIndex(x => x.PluginId).IsUnique();
            entity.Property(x => x.PluginId).HasMaxLength(128).IsRequired();
            entity.Property(x => x.Name).HasMaxLength(256).IsRequired();
            entity.Property(x => x.Version).HasMaxLength(64).IsRequired();
            entity.Property(x => x.PackagePath).HasMaxLength(1024).IsRequired();
            entity.Property(x => x.InstalledAtUtc).IsRequired();
        });
    }
}
