namespace Entity;

/// <summary>
/// 投票记录
/// </summary>
public class VoteRecord : IEntityBase
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }

    /// <summary>
    /// 用户
    /// </summary>
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    public Guid UserId { get; set; }

    /// <summary>
    /// 选项
    /// </summary>
    [ForeignKey(nameof(SubjectOptionId))]
    public SubjectOption SubjectOption { get; set; } = null!;
    public Guid SubjectOptionId { get; set; }

}