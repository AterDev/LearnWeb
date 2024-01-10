using System.Text.Json.Serialization;

namespace Entity.System;
/// <summary>
/// 系统用户
/// </summary>
[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(PhoneNumber), IsUnique = true)]
[Index(nameof(CreatedTime))]
[Index(nameof(IsDeleted))]
[Module(Modules.System)]
public class SystemUser : IEntityBase
{
    /// <summary>
    /// 用户名
    /// </summary>
    [Length(3, 30)]
    public required string UserName { get; set; }
    /// <summary>
    /// 真实姓名
    /// </summary>
    [Length(2, 30)]
    public string? RealName { get; set; }
    [MaxLength(100)]
    [EmailAddress]
    public string? Email { get; set; }
    public bool EmailConfirmed { get; set; }
    [JsonIgnore]
    [MaxLength(100)]
    public string PasswordHash { get; set; } = default!;
    [JsonIgnore]
    [MaxLength(60)]
    public string PasswordSalt { get; set; } = default!;
    [Phone]
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTimeOffset? LastLoginTime { get; set; }
    /// <summary>
    /// 密码重试次数
    /// </summary>
    public int RetryCount { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }
    public ICollection<SystemRole> SystemRoles { get; set; } = [];
    public ICollection<SystemLogs> SystemLogs { get; set; } = [];
    public ICollection<SystemOrganization> SystemOrganizations { get; set; } = [];
    /// <summary>
    /// 性别
    /// </summary>
    public Sex Sex { get; set; } = Sex.Male;
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
}

/// <summary>
/// 性别
/// </summary>
public enum Sex
{
    Male,
    Female,
    Else
}
