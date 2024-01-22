namespace Models.ResourceClient.VoteRecord
/// <summary>
/// 投票记录添加时请求结构
/// </summary>
public class VoteRecordAddDto {
    public string UserId { get; set; }
    public string SubjectOptionId { get; set; }

}
