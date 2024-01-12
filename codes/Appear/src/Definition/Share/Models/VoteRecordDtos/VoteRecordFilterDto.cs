using Entity;
namespace Share.Models.VoteRecordDtos;
/// <summary>
/// 投票记录查询筛选
/// </summary>
/// <see cref="Entity.VoteRecord"/>
public class VoteRecordFilterDto : FilterBase
{
    public Guid? UserId { get; set; }
    public Guid? SubjectOptionId { get; set; }
    
}
