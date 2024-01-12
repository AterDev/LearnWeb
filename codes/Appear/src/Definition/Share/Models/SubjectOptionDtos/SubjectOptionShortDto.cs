using Entity;
namespace Share.Models.SubjectOptionDtos;
/// <summary>
/// 主题选项概要
/// </summary>
/// <see cref="Entity.SubjectOption"/>
public class SubjectOptionShortDto
{
    public Subject Subject { get; set; } = default!;
    /// <summary>
    /// 投票数量
    /// </summary>
    public int Count { get; set; }
    
}
