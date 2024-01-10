namespace Entity;

/// <summary>
/// 投票规则 
/// </summary>
public class SubjectRule : IEntityBase
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
}
