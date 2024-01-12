using Entity;
namespace Share.Models.VoteRecordDtos;
/// <summary>
/// 投票记录概要
/// </summary>
/// <see cref="Entity.VoteRecord"/>
public class VoteRecordShortDto
{
    /// <summary>
    /// 用户
    /// </summary>
    public User User { get; set; } = default!;
    /// <summary>
    /// 选项
    /// </summary>
    public SubjectOption SubjectOption { get; set; } = default!;
    
}
