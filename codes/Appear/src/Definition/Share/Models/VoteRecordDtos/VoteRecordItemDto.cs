using Entity;
namespace Share.Models.VoteRecordDtos;
/// <summary>
/// 投票记录列表元素
/// </summary>
/// <see cref="Entity.VoteRecord"/>
public class VoteRecordItemDto
{
    public DateTimeOffset CreatedTime { get; set; }
    
}
