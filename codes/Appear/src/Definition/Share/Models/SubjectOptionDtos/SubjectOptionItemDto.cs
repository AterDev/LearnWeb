using Entity;
namespace Share.Models.SubjectOptionDtos;
/// <summary>
/// 主题选项列表元素
/// </summary>
/// <see cref="Entity.SubjectOption"/>
public class SubjectOptionItemDto
{
    public DateTimeOffset CreatedTime { get; set; }
    /// <summary>
    /// 内容
    /// </summary>
    [Length(2, 200)]
    public string Content { get; set; } = default!;
    /// <summary>
    /// 投票数量
    /// </summary>
    public int Count { get; set; }
    
}
