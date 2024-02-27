namespace ClientAPI.Models;
/// <summary>
/// 投票记录查询筛选
/// </summary>
public class VoteRecordFilterDto {
    public int PageIndex { get; set; } = default!;
    public int PageSize { get; set; } = default!;
    public Dictionary<string, bool>? OrderBy { get; set; }
    public Guid? UserId { get; set; }
    public Guid? SubjectOptionId { get; set; }

}
