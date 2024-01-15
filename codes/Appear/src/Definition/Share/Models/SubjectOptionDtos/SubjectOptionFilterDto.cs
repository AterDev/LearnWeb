using Entity;
namespace Share.Models.SubjectOptionDtos;
/// <summary>
/// 主题选项查询筛选
/// </summary>
/// <see cref="Entity.SubjectOption"/>
public class SubjectOptionFilterDto : FilterBase
{
    public Guid? SubjectId { get; set; }
}
