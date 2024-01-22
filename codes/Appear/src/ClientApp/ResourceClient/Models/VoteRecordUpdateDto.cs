namespace Models.ResourceClient.VoteRecord
/// <summary>
/// 投票记录更新时请求结构
/// </summary>
public class VoteRecordUpdateDto {
    public string? UserId { get; set; }
    public string? SubjectOptionId { get; set; }

}
