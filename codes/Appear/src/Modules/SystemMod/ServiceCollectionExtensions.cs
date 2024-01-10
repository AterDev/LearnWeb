// 本文件由 ater.dry工具自动生成.
namespace SystemMod;
/// <summary>
/// 服务注入扩展
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 添加OrderMod 注入服务
    /// </summary>
    /// <param name="services"></param>
    public static void AddSystemModManagers(this IServiceCollection services)
    {
        services.AddScoped(typeof(SystemConfigManager));
        services.AddScoped(typeof(SystemLogsManager));
        services.AddScoped(typeof(SystemMenuManager));
        services.AddScoped(typeof(SystemPermissionGroupManager));
        services.AddScoped(typeof(SystemPermissionManager));
        services.AddScoped(typeof(SystemRoleManager));
        services.AddScoped(typeof(SystemUserManager));
    }
}

