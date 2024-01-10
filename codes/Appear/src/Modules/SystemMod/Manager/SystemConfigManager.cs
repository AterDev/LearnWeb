using SystemMod.Models.SystemConfigDtos;

namespace SystemMod.Manager;
/// <summary>
/// 系统配置
/// </summary>
public class SystemConfigManager(
    DataAccessContext<SystemConfig> dataContext,
    ILogger<SystemConfigManager> logger,
    IConfiguration configuration,
    CacheService cache) : ManagerBase<SystemConfig, SystemConfigUpdateDto, SystemConfigFilterDto, SystemConfigItemDto>(dataContext, logger)
{
    private readonly IConfiguration _configuration = configuration;
    private readonly CacheService _cache = cache;

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SystemConfig> CreateNewEntityAsync(SystemConfigAddDto dto)
    {
        SystemConfig entity = dto.MapTo<SystemConfigAddDto, SystemConfig>();
        // other required props
        return await Task.FromResult(entity);
    }

    public override async Task<SystemConfig> UpdateAsync(SystemConfig entity, SystemConfigUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<SystemConfigItemDto>> FilterAsync(SystemConfigFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Key, q => q.Key == filter.Key)
            .WhereNotNull(filter.GroupName, q => q.GroupName == filter.GroupName);

        return await Query.FilterAsync<SystemConfigItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 获取枚举信息
    /// </summary>
    /// <returns></returns>
    public async Task<Dictionary<string, List<EnumDictionary>>> GetEnumConfigsAsync()
    {
        // TODO:程序启动时更新缓存
        Dictionary<string, List<EnumDictionary>>? res = _cache.GetValue<Dictionary<string, List<EnumDictionary>>>(AppConst.EnumCacheName);
        if (res == null || res.Count == 0)
        {
            Dictionary<string, List<EnumDictionary>> data = EnumHelper.GetAllEnumInfo();
            await _cache.SetValueAsync(AppConst.EnumCacheName, data);
            return data;
        }
        return res;
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<SystemConfig?> GetOwnedAsync(Guid id)
    {
        IQueryable<SystemConfig> query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

    /// <summary>
    /// 更新版本信息
    /// </summary>
    /// <returns></returns>
    public async Task UpdateVersionAsync()
    {
        SystemConfig? version = await CommandContext.SystemConfigs.Where(c => c.Key == AppConst.Version).FirstOrDefaultAsync();
        if (version == null)
        {
            SystemConfig config = new()
            {
                IsSystem = true,
                Valid = true,
                Key = AppConst.Version,
                GroupName = SystemConfig.System,
                // 版本格式:yyMMdd.编号
                Value = DateTime.UtcNow.ToString("yyMMdd") + ".01"
            };
            CommandContext.Add(config);
            await CommandContext.SaveChangesAsync();
            version = config;
        }
        // 比对新版本
        var newVersion = _configuration.GetValue<string>(AppConst.Version);
        if (double.TryParse(newVersion, out var newVersionValue)
            && double.TryParse(version.Value, out var versionValue))
        {
            if (newVersionValue > versionValue)
            {
                // 执行更新方法
                version.Value = newVersionValue.ToString();
                await CommandContext.SaveChangesAsync();
            }
        }
        else
        {
            _logger.LogError("版本格式错误");
        }
    }
}
