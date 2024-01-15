using Share.Models.SubjectDtos;
namespace Http.API.Controllers;

/// <summary>
/// 主题
/// </summary>
/// <see cref="Application.Manager.SubjectManager"/>
public class SubjectController(
    IUserContext user,
    ILogger<SubjectController> logger,
    SubjectManager manager
    ) : ClientControllerBase<SubjectManager>(manager, user, logger)
{
    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<SubjectItemDto>>> FilterAsync(SubjectFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Subject?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync(id);
        return (res == null) ? NotFound() : res;
    }

}