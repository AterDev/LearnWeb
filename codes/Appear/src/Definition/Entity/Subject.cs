namespace Entity;

/// <summary>
/// 主题
/// </summary>
[Index(nameof(Name), IsUnique = true)]
[Index(nameof(StartDate))]
[Index(nameof(EndDate))]
[Index(nameof(SubjectType))]
public class Subject : IEntityBase
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }

    [Length(2, 30)]
    public required string Name { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    public SubjectType SubjectType { get; set; }

    /// <summary>
    /// 开始日期
    /// </summary>
    public DateOnly StartDate { get; set; }

    /// <summary>
    /// 结束日期
    /// </summary>
    public DateOnly EndDate { get; set; }

    /// <summary>
    /// 选项
    /// </summary>
    public ICollection<SubjectOption> SubjectOptions { get; set; } = [];

    /// <summary>
    /// 投票规则
    /// </summary>
    public SubjectRule SubjectRule { get; set; } = null!;
}

public enum SubjectType
{
    /// <summary>
    /// 选举
    /// </summary>
    [Description("选举")]
    Election,
    /// <summary>
    /// 投票
    /// </summary>
    [Description("投票")]
    Vote
}
