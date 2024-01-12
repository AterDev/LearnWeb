using Share.Models.SubjectDtos;

namespace Application.Manager;
/// <summary>
/// 主题
/// </summary>
public class SubjectManager(
    DataAccessContext<Subject> dataContext,
    ILogger<SubjectManager> logger,
    IUserContext userContext) : ManagerBase<Subject, SubjectUpdateDto, SubjectFilterDto, SubjectItemDto>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<Subject> CreateNewEntityAsync(SubjectAddDto dto)
    {
        var entity = dto.MapTo<SubjectAddDto, Subject>();
        /*
        if (dto.SubjectOptionIds != null && dto.SubjectOptionIds.Count > 0)
        {
            var subjectOptions = await CommandContext.SubjectOptions()
                .Where(t => dto.SubjectOptionIds.Contains(t.Id))
                .ToListAsync();
            if (subjectOptions != null)
            {
                entity.SubjectOptions = subjectOptions;
            }
        }
        */        // other required props
        return await Task.FromResult(entity);
    }

    public override async Task<Subject> UpdateAsync(Subject entity, SubjectUpdateDto dto)
    {
        /*
        if (dto.SubjectOptionIds != null && dto.SubjectOptionIds.Count > 0)
        {
            var subjectOptions = await CommandContext.SubjectOptions()
                .Where(t => dto.SubjectOptionIds.Contains(t.Id))
                .ToListAsync();
            if (subjectOptions != null)
            {
                entity.SubjectOptions = subjectOptions;
            }
        }
        */
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<SubjectItemDto>> FilterAsync(SubjectFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Name, q => q.Name == filter.Name)
            .WhereNotNull(filter.SubjectType, q => q.SubjectType == filter.SubjectType);
        return await Query.FilterAsync<SubjectItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Subject?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
