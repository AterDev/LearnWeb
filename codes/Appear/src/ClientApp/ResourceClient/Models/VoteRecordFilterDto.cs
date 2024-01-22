namespace Models.ResourceClient.VoteRecord
/// <summary>
/// 投票记录查询筛选
/// </summary>
public class VoteRecordFilterDto {
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public object? OrderBy { get; set; }
    public string? UserId { get; set; }
    public string? SubjectOptionId { get; set; }

}
