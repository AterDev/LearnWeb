namespace ClientAPI.Models;
/// <summary>
/// 投票记录更新时请求结构
/// </summary>
public class VoteRecordUpdateDto {
    public Guid? UserId { get; set; }
    public Guid? SubjectOptionId { get; set; }

}
