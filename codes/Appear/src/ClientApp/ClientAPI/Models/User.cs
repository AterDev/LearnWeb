namespace ClientAPI.Models;
/// <summary>
/// 用户账户
/// </summary>
public class User {
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = default!;
    public UserType UserType { get; set; }
    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Email { get; set; }
    public bool EmailConfirmed { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; } = default!;
    public bool TwoFactorEnabled { get; set; } = default!;
    public DateTimeOffset? LockoutEnd { get; set; }
    public bool LockoutEnabled { get; set; } = default!;
    public int AccessFailedCount { get; set; } = default!;
    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTimeOffset? LastLoginTime { get; set; }
    /// <summary>
    /// 密码重试次数
    /// </summary>
    public int RetryCount { get; set; } = default!;
    /// <summary>
    /// 头像url
    /// </summary>
    public string? Avatar { get; set; }
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
    public List<VoteRecord> VoteRecords { get; set; }

}
