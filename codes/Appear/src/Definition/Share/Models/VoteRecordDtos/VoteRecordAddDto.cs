using Entity;
namespace Share.Models.VoteRecordDtos;
/// <summary>
/// 投票记录添加时请求结构
/// </summary>
/// <see cref="Entity.VoteRecord"/>
public class VoteRecordAddDto
{
    public Guid UserId { get; set; }
    public Guid SubjectOptionId { get; set; }
    
}
