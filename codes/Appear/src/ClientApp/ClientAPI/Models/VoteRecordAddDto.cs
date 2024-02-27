namespace ClientAPI.Models;
/// <summary>
/// 投票记录添加时请求结构
/// </summary>
public class VoteRecordAddDto {
    public Guid UserId { get; set; } = default!;
    public Guid SubjectOptionId { get; set; } = default!;

}
