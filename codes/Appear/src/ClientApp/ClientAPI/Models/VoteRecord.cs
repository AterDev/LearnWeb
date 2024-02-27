namespace ClientAPI.Models;
/// <summary>
/// 投票记录
/// </summary>
public class VoteRecord {
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
    /// <summary>
    /// 用户账户
    /// </summary>
    public User User { get; set; } = default!;
    public Guid UserId { get; set; } = default!;
    /// <summary>
    /// 主题选项
    /// </summary>
    public SubjectOption SubjectOption { get; set; } = default!;
    public Guid SubjectOptionId { get; set; } = default!;

}
