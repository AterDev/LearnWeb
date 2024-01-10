using SystemMod.Models.SystemLogsDtos;
namespace SystemMod.Controllers;

/// <summary>
/// 系统日志
/// </summary>
/// <see cref="SystemLogsManager"/>
public class SystemLogsController(
    IUserContext user,
    ILogger<SystemLogsController> logger,
    SystemLogsManager manager
        ) : ClientControllerBase<SystemLogsManager>(manager, user, logger)
{

    /// <summary>
    /// Operation Log Query
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<SystemLogsItemDto>>> FilterAsync(SystemLogsFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }
}