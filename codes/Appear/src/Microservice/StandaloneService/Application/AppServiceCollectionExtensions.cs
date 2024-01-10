namespace StandaloneService.Application;

/// <summary>
/// 应用配置常量
/// </summary>
public static class AppSetting
{
    public const string Components = "Components";
    public const string None = "None";
    public const string Redis = "Redis";
    public const string Memory = "Memory";
    public const string Otlp = "otlp";

    public const string CommandDB = "CommandDb";
    public const string QueryDB = "QueryDb";
    public const string Cache = "Cache";
    public const string CacheInstanceName = "CacheInstanceName";
    public const string Logging = "Logging";
}

/// <summary>
/// 服务注册扩展
/// </summary>
public static partial class AppServiceCollectionExtensions
{
    /// <summary>
    /// 添加应用组件
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddAppComponents(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPgsqlDbContext(configuration);
        services.AddRedisCache(configuration);
        return services;
    }

    /// <summary>
    /// 添加数据工厂
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDbFactory(this IServiceCollection services)
    {
        services.AddSingleton<IDbContextFactory<QueryDbContext>, QueryDbContextFactory>();
        services.AddSingleton<IDbContextFactory<CommandDbContext>, CommandDbContextFactory>();
        return services;
    }

    /// <summary>
    /// add postgresql config
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddPgsqlDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var commandString = configuration.GetConnectionString(AppSetting.CommandDB);
        var queryString = configuration.GetConnectionString(AppSetting.QueryDB);
        services.AddDbContextPool<QueryDbContext>(option =>
        {
            option.UseNpgsql(queryString, sql =>
            {
                sql.MigrationsAssembly("Http.API");
                sql.CommandTimeout(10);
            });
        });
        services.AddDbContextPool<CommandDbContext>(option =>
        {
            option.UseNpgsql(commandString, sql =>
            {
                sql.MigrationsAssembly("Http.API");
                sql.CommandTimeout(10);
            });
        });
        return services;
    }

    /// <summary>
    /// add redis cache config
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
    {
        var cache = configuration.GetSection(AppSetting.Components).GetValue<string>(AppSetting.Cache);
        return cache == AppSetting.Redis
            ? services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString(AppSetting.Cache);
                options.InstanceName = configuration.GetConnectionString(AppSetting.CacheInstanceName);
            })
            : services.AddDistributedMemoryCache();

    }
}
