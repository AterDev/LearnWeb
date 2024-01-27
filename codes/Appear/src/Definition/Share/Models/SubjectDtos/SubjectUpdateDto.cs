namespace Share.Models.SubjectDtos;
/// <summary>
/// 主题更新时请求结构
/// </summary>
/// <see cref="Entity.Subject"/>
public class SubjectUpdateDto
{
    [Length(2, 30)]
    public string? Name { get; set; }
    [MaxLength(2000)]
    public string? Description { get; set; }
    public SubjectType? SubjectType { get; set; }
    /// <summary>
    /// 开始日期
    /// </summary>
    public DateOnly? StartDate { get; set; }
    /// <summary>
    /// 结束日期
    /// </summary>
    public DateOnly? EndDate { get; set; }
}
