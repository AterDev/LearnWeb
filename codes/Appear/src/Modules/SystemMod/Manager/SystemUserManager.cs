using SystemMod.Models.SystemUserDtos;

namespace SystemMod.Manager;

public class SystemUserManager(
    DataAccessContext<SystemUser> dataContext,
    IUserContext userContext,
    IConfiguration configuration,
    ILogger<SystemUserManager> logger) : ManagerBase<SystemUser, SystemUserUpdateDto, SystemUserFilterDto, SystemUserItemDto>(dataContext, logger)
{
    private readonly IUserContext _userContext = userContext;
    private readonly IConfiguration _configuration = configuration;

    /// <summary>
    /// 获取验证码
    /// 也可自己实现图片验证码
    /// </summary>
    /// <param name="length">验证码长度</param>
    /// <returns></returns>
    public string GetCaptcha(int length = 6)
    {
        return HashCrypto.GetRnd(length);
    }

    /// <summary>
    /// 更新密码
    /// </summary>
    /// <param name="user"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public async Task<bool> ChangePasswordAsync(SystemUser user, string newPassword)
    {
        user.PasswordSalt = HashCrypto.BuildSalt();
        user.PasswordHash = HashCrypto.GeneratePwd(newPassword, user.PasswordSalt);
        Command.Update(user);
        return await Command.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<SystemUser> CreateNewEntityAsync(SystemUserAddDto dto)
    {
        SystemUser entity = dto.MapTo<SystemUserAddDto, SystemUser>();
        // 密码处理
        entity.PasswordSalt = HashCrypto.BuildSalt();
        entity.PasswordHash = HashCrypto.GeneratePwd(dto.Password, entity.PasswordSalt);
        // 角色处理
        if (dto.RoleIds != null && dto.RoleIds.Count != 0)
        {
            IQueryable<SystemRole> roles = CommandContext.SystemRoles.Where(r => dto.RoleIds.Contains(r.Id));
            entity.SystemRoles = roles.ToList();
        }
        return Task.FromResult(entity);
    }

    public override async Task<SystemUser> UpdateAsync(SystemUser entity, SystemUserUpdateDto dto)
    {

        if (dto.Password != null)
        {
            entity.PasswordSalt = HashCrypto.BuildSalt();
            entity.PasswordHash = HashCrypto.GeneratePwd(dto.Password, entity.PasswordSalt);
        }

        return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<SystemUserItemDto>> FilterAsync(SystemUserFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.UserName, q => q.UserName == filter.UserName)
            .WhereNotNull(filter.RealName, q => q.RealName == filter.RealName)
            .WhereNotNull(filter.Email, q => q.Email == filter.Email)
            .WhereNotNull(filter.PhoneNumber, q => q.PhoneNumber == filter.PhoneNumber)
            .WhereNotNull(filter.Sex, q => q.Sex == filter.Sex)
            .WhereNotNull(filter.EmailConfirmed, q => q.EmailConfirmed == filter.EmailConfirmed)
            .WhereNotNull(filter.PhoneNumberConfirmed, q => q.PhoneNumberConfirmed == filter.PhoneNumberConfirmed);

        if (filter.RoleId != null)
        {
            Queryable = Queryable.Where(q => q.SystemRoles.Any(r => r.Id == filter.RoleId));
        }

        return await Query.FilterAsync<SystemUserItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<SystemUser?> GetOwnedAsync(Guid id)
    {
        IQueryable<SystemUser> query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        query = query.Where(q => q.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

    /// <summary>
    /// 初始化管理员角色和账号
    /// </summary>
    /// <returns></returns>
    public async Task InitSystemUserAndRoleAsync()
    {
        // 判断是否初始化
        SystemRole? role = await CommandContext.SystemRoles.SingleOrDefaultAsync(r => r.NameValue == AppConst.AdminUser);

        if (role != null) { return; }

        var defaultPassword = _configuration.GetValue<string>("Key:DefaultPassword");
        if (string.IsNullOrWhiteSpace(defaultPassword))
        {
            defaultPassword = "Hello.Net";
        }

        SystemRole superRole = new()
        {
            Name = AppConst.SuperAdmin,
            NameValue = AppConst.SuperAdmin,
        };
        SystemRole adminRole = new()
        {
            Name = AppConst.AdminUser,
            NameValue = AppConst.AdminUser,
        };
        var salt = HashCrypto.BuildSalt();
        SystemUser systemUser = new()
        {
            UserName = "admin",
            PasswordSalt = salt,
            PasswordHash = HashCrypto.GeneratePwd(defaultPassword, salt),
            SystemRoles = new List<SystemRole>() { superRole, adminRole },
        };
        CommandContext.SystemRoles.Add(adminRole);
        CommandContext.SystemRoles.Add(superRole);
        CommandContext.SystemUsers.Add(systemUser);
        await CommandContext.SaveChangesAsync();
    }

}
