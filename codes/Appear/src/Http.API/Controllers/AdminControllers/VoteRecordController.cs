using Share.Models.VoteRecordDtos;
namespace Http.API.Controllers.AdminControllers;

/// <summary>
/// 投票记录
/// </summary>
/// <see cref="Application.Manager.VoteRecordManager"/>
public class VoteRecordController(
    IUserContext user,
    ILogger<VoteRecordController> logger,
    VoteRecordManager manager,
        UserManager userManager,
        SubjectOptionManager subjectOptionManager
    ) : RestControllerBase<VoteRecordManager>(manager, user, logger)
{
    private readonly UserManager _userManager = userManager;
    private readonly SubjectOptionManager _subjectOptionManager = subjectOptionManager;


    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<VoteRecordItemDto>>> FilterAsync(VoteRecordFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<VoteRecord>> AddAsync(VoteRecordAddDto dto)
    {
        if (!await _user.ExistAsync()) { return NotFound(ErrorMsg.NotFoundUser); }
        if (!await _subjectOptionManager.ExistAsync(dto.SubjectOptionId))
        {
            return NotFound("不存在的选项");
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
    public async Task<ActionResult<VoteRecord?>> UpdateAsync([FromRoute] Guid id, VoteRecordUpdateDto dto)
    {
        var current = await manager.GetCurrentAsync(id);
        if (current == null) { return NotFound("不存在的资源"); };
        if (dto.SubjectOptionId != null && current.SubjectOption.Id != dto.SubjectOptionId)
        {
            var subjectOption = await _subjectOptionManager.GetCurrentAsync(dto.SubjectOptionId.Value);
            if (subjectOption == null) { return NotFound("不存在的选项"); }
            current.SubjectOption = subjectOption;
        }
        return await manager.UpdateAsync(current, dto);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<VoteRecord?>> GetDetailAsync([FromRoute] Guid id)
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
    public async Task<ActionResult<VoteRecord?>> DeleteAsync([FromRoute] Guid id)
    {
        // 注意删除权限
        var entity = await manager.GetCurrentAsync(id);
        if (entity == null) { return NotFound(); };
        // return Forbid();
        return await manager.DeleteAsync(entity);
    }
}