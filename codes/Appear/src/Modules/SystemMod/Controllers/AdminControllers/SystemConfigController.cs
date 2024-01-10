using SystemMod.Models.SystemConfigDtos;
namespace SystemMod.Controllers.AdminControllers;

/// <summary>
/// 系统配置
/// </summary>
/// <see cref="SystemConfigManager"/>
public class SystemConfigController(
    IUserContext user,
    ILogger<SystemConfigController> logger,
    SystemConfigManager manager
        ) : RestControllerBase<SystemConfigManager>(manager, user, logger)
{

    /// <summary>
    /// 获取配置列表 ✅
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<SystemConfigItemDto>>> FilterAsync(SystemConfigFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 获取枚举信息 ✅
    /// </summary>
    /// <returns></returns>
    [HttpGet("enum")]
    public async Task<ActionResult<Dictionary<string, List<EnumDictionary>>>> GetEnumConfigsAsync()
    {
        return await manager.GetEnumConfigsAsync();
    }
    /// <summary>
    /// 新增 ✅
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<SystemConfig>> AddAsync(SystemConfigAddDto dto)
    {
        SystemConfig entity = await manager.CreateNewEntityAsync(dto);
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新 ✅
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<ActionResult<SystemConfig?>> UpdateAsync([FromRoute] Guid id, SystemConfigUpdateDto dto)
    {
        SystemConfig? current = await manager.GetCurrentAsync(id);
        if (current == null) { return NotFound(ErrorMsg.NotFoundResource); };
        return await manager.UpdateAsync(current, dto);
    }

    /// <summary>
    /// 详情 ✅
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SystemConfig?>> GetDetailAsync([FromRoute] Guid id)
    {
        SystemConfig? res = await manager.FindAsync(id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除 ✅
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<SystemConfig?>> DeleteAsync([FromRoute] Guid id)
    {
        // 注意删除权限
        SystemConfig? entity = await manager.GetCurrentAsync(id);
        if (entity == null) { return NotFound(); };
        return entity.IsSystem
            ? Problem("系统配置，无法删除!")
            : await manager.DeleteAsync(entity);
    }
}