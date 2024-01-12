using Entity;
namespace Share.Models.SubjectOptionDtos;
/// <summary>
/// 主题选项查询筛选
/// </summary>
/// <see cref="Entity.SubjectOption"/>
public class SubjectOptionFilterDto : FilterBase
{
    public Guid? SubjectId { get; set; }
    /// <summary>
    /// 内容
    /// </summary>
    [Length(2, 200)]
    public string? Content { get; set; }
    /// <summary>
    /// 投票数量
    /// </summary>
    public int? Count { get; set; }
    
}
