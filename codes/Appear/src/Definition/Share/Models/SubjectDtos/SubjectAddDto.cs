namespace Share.Models.SubjectDtos;
/// <summary>
/// 主题添加时请求结构
/// </summary>
/// <see cref="Entity.Subject"/>
public class SubjectAddDto
{
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
}
