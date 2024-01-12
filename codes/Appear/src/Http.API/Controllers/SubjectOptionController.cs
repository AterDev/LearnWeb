using Share.Models.SubjectOptionDtos;
namespace Http.API.Controllers;

/// <summary>
/// 主题选项
/// </summary>
/// <see cref="Application.Manager.SubjectOptionManager"/>
public class SubjectOptionController(
    IUserContext user,
    ILogger<SubjectOptionController> logger,
    SubjectOptionManager manager,
        SubjectManager subjectManager
    ) : ClientControllerBase<SubjectOptionManager>(manager, user, logger)
{
    private readonly SubjectManager _subjectManager = subjectManager;


    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<SubjectOptionItemDto>>> FilterAsync(SubjectOptionFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<SubjectOption>> AddAsync(SubjectOptionAddDto dto)
    {
        if (!await _subjectManager.ExistAsync(dto.SubjectId))
        {
            return NotFound("不存在的Subject");
        }
        var entity = await manager.CreateNewEntityAsync(dto);
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 部分更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<ActionResult<SubjectOption?>> UpdateAsync([FromRoute] Guid id, SubjectOptionUpdateDto dto)
    {
        var current = await manager.GetCurrentAsync(id);
        if (current == null) { return NotFound("不存在的资源"); };
        if (dto.SubjectId != null && current.Subject.Id != dto.SubjectId)
        {
            var subject = await _subjectManager.GetCurrentAsync(dto.SubjectId.Value);
            if (subject == null) { return NotFound("不存在的Subject"); }
            current.Subject = subject;
        }
        return await manager.UpdateAsync(current, dto);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SubjectOption?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync(id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<SubjectOption?>> DeleteAsync([FromRoute] Guid id)
    {
        // 注意删除权限
        var entity = await manager.GetCurrentAsync(id);
        if (entity == null) { return NotFound(); };
        // return Forbid();
        return await manager.DeleteAsync(entity);
    }
}