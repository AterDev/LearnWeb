using SystemMod.Models.SystemPermissionGroupDtos;

namespace SystemMod.Manager;

public class SystemPermissionGroupManager(
    DataAccessContext<SystemPermissionGroup> dataContext,
    ILogger<SystemPermissionGroupManager> logger
        ) : ManagerBase<SystemPermissionGroup, SystemPermissionGroupUpdateDto, SystemPermissionGroupFilterDto, SystemPermissionGroupItemDto>(dataContext, logger)
{

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SystemPermissionGroup> CreateNewEntityAsync(SystemPermissionGroupAddDto dto)
    {
        SystemPermissionGroup entity = dto.MapTo<SystemPermissionGroupAddDto, SystemPermissionGroup>();
        return await Task.FromResult(entity);
    }

    public override async Task<SystemPermissionGroup> UpdateAsync(SystemPermissionGroup entity, SystemPermissionGroupUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<SystemPermissionGroupItemDto>> FilterAsync(SystemPermissionGroupFilterDto filter)
    {
        Queryable = Queryable.WhereNotNull(filter.Name, q => q.Name.Contains(filter.Name!));
        return await Query.PageListAsync<SystemPermissionGroupItemDto>(Queryable, filter.PageIndex, filter.PageSize);

    }

    public override async Task<SystemPermissionGroup?> FindAsync(Guid id)
    {
        return await Query.Db.Include(g => g.Permissions)
            .AsNoTracking()
            .SingleOrDefaultAsync(g => g.Id == id);
    }

    public override Task<SystemPermissionGroup?> DeleteAsync(SystemPermissionGroup entity, bool softDelete = true)
    {
        // load permissions
        return base.DeleteAsync(entity, false);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<SystemPermissionGroup?> GetOwnedAsync(Guid id)
    {
        IQueryable<SystemPermissionGroup> query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
