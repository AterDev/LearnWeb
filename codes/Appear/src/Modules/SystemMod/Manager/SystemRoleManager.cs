using SystemMod.Models.SystemRoleDtos;

namespace SystemMod.Manager;

public class SystemRoleManager(
    DataAccessContext<SystemRole> dataContext,
    ILogger<SystemRoleManager> logger) : ManagerBase<SystemRole, SystemRoleUpdateDto, SystemRoleFilterDto, SystemRoleItemDto>(dataContext, logger)
{

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<SystemRole> CreateNewEntityAsync(SystemRoleAddDto dto)
    {
        SystemRole entity = dto.MapTo<SystemRoleAddDto, SystemRole>();
        // other required props
        return Task.FromResult(entity);
    }

    public override async Task<SystemRole> UpdateAsync(SystemRole entity, SystemRoleUpdateDto dto)
    {
        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<SystemRoleItemDto>> FilterAsync(SystemRoleFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Name, q => q.Name == filter.Name)
            .WhereNotNull(filter.NameValue, q => q.NameValue == filter.NameValue);
        return await Query.FilterAsync<SystemRoleItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 获取菜单
    /// </summary>
    /// <param name="systemRoles"></param>
    /// <returns></returns>
    public async Task<List<SystemMenu>> GetSystemMenusAsync(List<SystemRole> systemRoles)
    {
        IEnumerable<Guid> ids = systemRoles.Select(r => r.Id);
        return await CommandContext.SystemMenus
            .Where(m => m.Roles.Any(r => ids.Contains(r.Id)))
        .ToListAsync();
    }

    /// <summary>
    /// Set PermissionGroups
    /// </summary>
    /// <param name="current"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SystemRole?> SetPermissionGroupsAsync(SystemRole current, SystemRoleSetPermissionGroupsDto dto)
    {
        try
        {
            await CommandContext.Entry(current)
                .Collection(r => r.PermissionGroups)
                .LoadAsync();

            List<SystemPermissionGroup> groups = await CommandContext.SystemPermissionGroups
                .Where(m => dto.PermissionGroupIds.Contains(m.Id))
                .ToListAsync();
            current.PermissionGroups = groups;
            await Command.SaveChangesAsync();
            return current;
        }
        catch (Exception e)
        {
            _logger.LogError("set role permission groups failed:{message}", e.Message);
            return null;
        }
    }

    /// <summary>
    /// 获取权限组
    /// </summary>
    /// <param name="systemRoles"></param>
    /// <returns></returns>
    public async Task<List<SystemPermissionGroup>> GetPermissionGroupsAsync(List<SystemRole> systemRoles)
    {
        IEnumerable<Guid> ids = systemRoles.Select(r => r.Id);
        return await CommandContext.SystemPermissionGroups
            .Where(m => m.Roles.Any(r => ids.Contains(r.Id)))
            .ToListAsync();
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<SystemRole?> GetOwnedAsync(Guid id)
    {
        IQueryable<SystemRole> query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

    /// <summary>
    /// 更新角色菜单
    /// </summary>
    /// <param name="current"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<SystemRole?> SetMenusAsync(SystemRole current, SystemRoleSetMenusDto dto)
    {
        // 更新角色菜单
        try
        {
            await CommandContext.Entry(current)
                .Collection(r => r.Menus)
                .LoadAsync();

            current.Menus = new List<SystemMenu>();

            List<SystemMenu> menus = await CommandContext.SystemMenus
                .Where(m => dto.MenuIds.Contains(m.Id))
                .ToListAsync();
            current.Menus = menus;
            await Command.SaveChangesAsync();
            return current;
        }
        catch (Exception e)
        {
            _logger.LogError("update role menus failed:{message}", e.Message);
            return default;
        }

    }
}
