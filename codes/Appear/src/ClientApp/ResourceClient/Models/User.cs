using Models.UserType';
using Models.VoteRecord';
namespace Models.ResourceClient.User
/// <summary>
/// 用户账户
/// </summary>
public class User {
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }
    public UserType UserType { get; set; }
    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Email { get; set; }
    public bool EmailConfirmed { get; set; }
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
    public string? Avatar { get; set; }
    public string Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
    public List<VoteRecord> VoteRecords { get; set; }

}
