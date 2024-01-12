using Entity;
namespace Share.Models.SubjectOptionDtos;
/// <summary>
/// 主题选项更新时请求结构
/// </summary>
/// <see cref="Entity.SubjectOption"/>
public class SubjectOptionUpdateDto
{
    public Guid? SubjectId { get; set; }
    /// <summary>
    /// 内容
    /// </summary>
    [Length(2, 200)]
    public string? Content { get; set; }
    [MaxLength(2000)]
    public string? Detail { get; set; }
    /// <summary>
    /// 投票数量
    /// </summary>
    public int? Count { get; set; }
    
}
