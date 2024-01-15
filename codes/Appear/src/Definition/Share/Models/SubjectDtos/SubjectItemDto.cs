namespace Share.Models.SubjectDtos;
/// <summary>
/// 主题列表元素
/// </summary>
/// <see cref="Entity.Subject"/>
public class SubjectItemDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public string Name { get; set; } = default!;
    public SubjectType SubjectType { get; set; }
    /// <summary>
    /// 开始日期
    /// </summary>
    public DateOnly StartDate { get; set; }
    /// <summary>
    /// 结束日期
    /// </summary>
    public DateOnly EndDate { get; set; }
}
