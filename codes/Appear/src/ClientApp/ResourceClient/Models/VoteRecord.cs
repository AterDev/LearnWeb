using Models.User';
using Models.SubjectOption';
namespace Models.ResourceClient.VoteRecord
/// <summary>
/// 投票记录
/// </summary>
public class VoteRecord {
    public string Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
    /// <summary>
    /// 用户账户
    /// </summary>
    public User User { get; set; }
    public string UserId { get; set; }
    /// <summary>
    /// 主题选项
    /// </summary>
    public SubjectOption SubjectOption { get; set; }
    public string SubjectOptionId { get; set; }

}
