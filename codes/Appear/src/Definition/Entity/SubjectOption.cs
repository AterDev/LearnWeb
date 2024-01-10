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
}
