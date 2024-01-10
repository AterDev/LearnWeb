using SystemMod.Models.SystemPermissionGroupDtos;
namespace SystemMod.Controllers.AdminControllers;

/// <see cref="SystemPermissionGroupManager"/>
[Authorize(AppConst.SuperAdmin)]
public class SystemPermissionGroupController(
    IUserContext user,
    ILogger<SystemPermissionGroupController> logger,
    SystemPermissionGroupManager manager
        ) : RestControllerBase<SystemPermissionGroupManager>(manager, user, logger)
{

    /// <summary>
    /// 筛选 ✅
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<SystemPermissionGroupItemDto>>> FilterAsync(SystemPermissionGroupFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增 ✅
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<SystemPermissionGroup>> AddAsync(SystemPermissionGroupAddDto dto)
    {
        SystemPermissionGroup entity = await manager.CreateNewEntityAsync(dto);
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新 ✅
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<ActionResult<SystemPermissionGroup?>> UpdateAsync([FromRoute] Guid id, SystemPermissionGroupUpdateDto dto)
    {
        SystemPermissionGroup? current = await manager.GetCurrentAsync(id);
        if (current == null) { return NotFound(ErrorMsg.NotFoundResource); };
        return await manager.UpdateAsync(current, dto);
    }

    /// <summary>
    /// 详情 ✅
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SystemPermissionGroup?>> GetDetailAsync([FromRoute] Guid id)
    {
        SystemPermissionGroup? res = await manager.FindAsync(id);
        return res == null ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除 ✅
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<SystemPermissionGroup?>> DeleteAsync([FromRoute] Guid id)
    {
        // 注意删除权限
        SystemPermissionGroup? entity = await manager.GetCurrentAsync(id);
        if (entity == null) { return NotFound(); };
        // return Forbid();
        return await manager.DeleteAsync(entity);
    }
}