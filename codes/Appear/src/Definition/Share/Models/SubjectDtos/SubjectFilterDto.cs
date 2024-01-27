namespace Share.Models.SubjectDtos;
/// <summary>
/// 主题查询筛选
/// </summary>
/// <see cref="Entity.Subject"/>
public class SubjectFilterDto : FilterBase
{
    [Length(2, 30)]
    public string? Name { get; set; }
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
