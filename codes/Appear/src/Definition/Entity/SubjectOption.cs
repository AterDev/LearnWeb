namespace Entity;

/// <summary>
/// 主题选项
/// </summary>
public class SubjectOption : IEntityBase
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(SubjectId))]
    public Subject Subject { get; set; } = null!;

    public Guid SubjectId { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [Length(2, 200)]
    public required string Content { get; set; }

    [MaxLength(2000)]
    public string? Detail { get; set; }

    /// <summary>
    /// 投票数量
    /// </summary>
    public int Count { get; set; }

    public ICollection<VoteRecord> VoteRecords = [];
}
