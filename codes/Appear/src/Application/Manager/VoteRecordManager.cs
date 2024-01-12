using Application.Manager;
using Share.Models.VoteRecordDtos;

namespace Application.Manager;
/// <summary>
/// 投票记录
/// </summary>
public class VoteRecordManager(
    DataAccessContext<VoteRecord> dataContext, 
    ILogger<VoteRecordManager> logger,
    IUserContext userContext) : ManagerBase<VoteRecord, VoteRecordUpdateDto, VoteRecordFilterDto, VoteRecordItemDto>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<VoteRecord> CreateNewEntityAsync(VoteRecordAddDto dto)
    {
        var entity = dto.MapTo<VoteRecordAddDto, VoteRecord>();
        Command.Db.Entry(entity).Property("UserId").CurrentValue = _userContext.UserId;
        // or entity.UserId = _userContext.UserId;
        Command.Db.Entry(entity).Property("SubjectOptionId").CurrentValue = dto.SubjectOptionId;
        // or entity.SubjectOptionId = dto.SubjectOptionId;
        // other required props
        return await Task.FromResult(entity);
    }

    public override async Task<VoteRecord> UpdateAsync(VoteRecord entity, VoteRecordUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<VoteRecordItemDto>> FilterAsync(VoteRecordFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.UserId, q => q.User.Id == filter.UserId)
            .WhereNotNull(filter.SubjectOptionId, q => q.SubjectOption.Id == filter.SubjectOptionId);
        // TODO: custom filter conditions
        return await Query.FilterAsync<VoteRecordItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<VoteRecord?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
