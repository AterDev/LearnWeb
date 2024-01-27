using Share.Models.SubjectOptionDtos;

namespace Application.Manager;
/// <summary>
/// 主题选项
/// </summary>
public class SubjectOptionManager(
    DataAccessContext<SubjectOption> dataContext,
    ILogger<SubjectOptionManager> logger,
    IUserContext userContext) : ManagerBase<SubjectOption, SubjectOptionUpdateDto, SubjectOptionFilterDto, SubjectOptionItemDto>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SubjectOption> CreateNewEntityAsync(SubjectOptionAddDto dto)
    {
        var entity = dto.MapTo<SubjectOptionAddDto, SubjectOption>();
        Command.Db.Entry(entity).Property("SubjectId").CurrentValue = dto.SubjectId;
        // or entity.SubjectId = dto.SubjectId;
        // other required props
        return await Task.FromResult(entity);
    }

    public override async Task<SubjectOption> UpdateAsync(SubjectOption entity, SubjectOptionUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<SubjectOptionItemDto>> FilterAsync(SubjectOptionFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.SubjectId, q => q.Subject.Id == filter.SubjectId);
        return await Query.FilterAsync<SubjectOptionItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 投票
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> VoteOptionAsync(Guid id)
    {
        var option = await GetCurrentAsync(id);
        if (option == null) { return false; }

        option.Count++;

        var record = new VoteRecord
        {
            SubjectOptionId = id,
            UserId = _userContext.UserId
        };

        CommandContext.Add(record);
        return await CommandContext.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<SubjectOption?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
