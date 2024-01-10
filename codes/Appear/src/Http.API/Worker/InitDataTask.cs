using EntityFramework.DBProvider;

namespace Http.API.Worker;
public class InitDataTask
{
    public static async Task InitDataAsync(IServiceProvider provider)
    {
        CommandDbContext context = provider.GetRequiredService<CommandDbContext>();
        ILoggerFactory loggerFactory = provider.GetRequiredService<ILoggerFactory>();
        ILogger<InitDataTask> logger = loggerFactory.CreateLogger<InitDataTask>();
        IConfiguration configuration = provider.GetRequiredService<IConfiguration>();

        var connectionString = context.Database.GetConnectionString();
        try
        {
            // 执行迁移,如果手动执行,请删除该代码
            context.Database.Migrate();
            if (!await context.Database.CanConnectAsync())
            {
                logger.LogError("数据库无法连接:{message}", connectionString);
                return;
            }
            else
            {
                // 判断是否初始化
                var user = await context.Users.FirstOrDefaultAsync();
                if (user == null)
                {
                    logger.LogInformation("初始化用户数据");
                    await InitUserAsync(context, configuration, logger);
                }
                // 初始化管理员信息
                //var systemUserManager = provider.GetRequiredService<SystemMod.Manager.SystemUserManager>();
                //await systemUserManager.InitSystemUserAndRoleAsync();
                //var systemConfigManager = provider.GetRequiredService<SystemMod.Manager.SystemConfigManager>();
                //await systemConfigManager.UpdateVersionAsync();
            }
        }
        catch (Exception)
        {
            logger.LogError("初始化异常,请检查数据库配置：{message}", connectionString);
        }
    }

    /// <summary>
    /// 初始化角色和管理用户
    /// </summary>
    public static async Task InitUserAsync(CommandDbContext context, IConfiguration configuration, ILogger<InitDataTask> logger)
    {
        var defaultPassword = configuration.GetValue<string>("Key:DefaultPassword");
        if (string.IsNullOrWhiteSpace(defaultPassword))
        {
            defaultPassword = "Hello.Net";
        }
        var salt = HashCrypto.BuildSalt();

        User user = new()
        {
            UserName = "TestUser",
            Email = "TestEmail@domain",
            PasswordSalt = salt,
            PasswordHash = HashCrypto.GeneratePwd(defaultPassword, salt),
        };

        try
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError("初始化角色用户时出错,请确认您的数据库没有数据！{message}", ex.Message);
        }
    }
}
