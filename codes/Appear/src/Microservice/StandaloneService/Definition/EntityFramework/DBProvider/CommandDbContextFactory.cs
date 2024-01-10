using Microsoft.Extensions.Caching.Distributed;

namespace StandaloneService.Definition.EntityFramework.DBProvider;
public class CommandDbContextFactory(ITenantProvider tenantProvider, IDistributedCache cache) : IDbContextFactory<CommandDbContext>
{
    private readonly ITenantProvider _tenantProvider = tenantProvider;
    private readonly IDistributedCache _cache = cache;

    public CommandDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<CommandDbContext>();
        Guid tenantId = _tenantProvider.TenantId;

        // 从缓存或配置中查询连接字符串
        var connectionStrings = _cache.GetString($"{tenantId}_CommandConnectionString");

        optionsBuilder.UseNpgsql(connectionStrings);
        return new CommandDbContext(optionsBuilder.Options);
    }
}
