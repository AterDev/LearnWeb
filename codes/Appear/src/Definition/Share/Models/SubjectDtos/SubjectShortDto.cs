using Entity;
namespace Share.Models.SubjectDtos;
/// <summary>
/// 主题概要
/// </summary>
/// <see cref="Entity.Subject"/>
public class SubjectShortDto
{
    [Length(2, 30)]
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
    /// <summary>
    /// 投票规则
    /// </summary>
    public SubjectRule SubjectRule { get; set; } = default!;
    
}
