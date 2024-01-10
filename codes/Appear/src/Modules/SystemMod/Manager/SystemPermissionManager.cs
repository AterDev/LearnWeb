using SystemMod.Models.SystemPermissionDtos;

namespace SystemMod.Manager;
/// <summary>
/// 权限
/// </summary>
public class SystemPermissionManager(
    DataAccessContext<SystemPermission> dataContext,
    ILogger<SystemPermissionManager> logger
        ) : ManagerBase<SystemPermission, SystemPermissionUpdateDto, SystemPermissionFilterDto, SystemPermissionItemDto>(dataContext, logger)
{

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SystemPermission> CreateNewEntityAsync(SystemPermissionAddDto dto)
    {
        SystemPermission entity = dto.MapTo<SystemPermissionAddDto, SystemPermission>();
        Command.Db.Entry(entity).Property("GroupId").CurrentValue = dto.SystemPermissionGroupId;
        return await Task.FromResult(entity);
    }

    public override Task<SystemPermission?> GetCurrentAsync(Guid id, params string[]? navigations)
    {
        return base.GetCurrentAsync(id, navigations);
    }

    public override async Task<SystemPermission> UpdateAsync(SystemPermission entity, SystemPermissionUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<SystemPermissionItemDto>> FilterAsync(SystemPermissionFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Name, q => q.Name == filter.Name)
            .WhereNotNull(filter.PermissionType, q => q.PermissionType == filter.PermissionType)
            .WhereNotNull(filter.GroupId, q => q.Group.Id == filter.GroupId);

        return await Query.FilterAsync<SystemPermissionItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<SystemPermission?> GetOwnedAsync(Guid id)
    {
        IQueryable<SystemPermission> query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
