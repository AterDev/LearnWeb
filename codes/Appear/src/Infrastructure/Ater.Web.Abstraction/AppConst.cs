namespace Ater.Web.Abstraction;
/// <summary>
/// 应用程序常量
/// </summary>
public static class AppConst
{
    public const string DefaultStateName = "statestore";
    public const string DefaultPubSubName = "pubsub";

    public const string TenantId = "TenantId";

    /// <summary>
    /// 超级管理员
    /// </summary>
    public const string SuperAdmin = "SuperAdmin";
    /// <summary>
    /// 管理员 policy
    /// </summary>
    public const string AdminUser = "AdminUser";
    /// <summary>
    /// 普通用户 policy
    /// </summary>
    public const string User = "User";
    /// <summary>
    /// 版本
    /// </summary>
    public const string Version = "Version";

    /// <summary>
    /// 用户登录缓存前缀
    /// </summary>
    public const string LoginCachePrefix = "Login_";
    /// <summary>
    /// 验证码缓存前缀
    /// </summary>
    public const string VerifyCodeCachePrefix = "VerifyCode_";
    /// <summary>
    /// 枚举缓存
    /// </summary>
    public const string EnumCacheName = "EnumConfigs";
    /// <summary>
    /// 权限缓存前缀
    /// </summary>
    public const string PermissionCacheName = "Permissions";

}
