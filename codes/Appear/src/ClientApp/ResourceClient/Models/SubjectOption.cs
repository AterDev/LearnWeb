using Models.Subject';
namespace Models.ResourceClient
/// <summary>
/// 主题选项
/// </summary>
public class SubjectOption {
    public string Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
    /// <summary>
    /// 主题
    /// </summary>
    public Subject Subject { get; set; }
    public string SubjectId { get; set; }
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }
    public string? Detail { get; set; }
    /// <summary>
    /// 投票数量
    /// </summary>
    public int Count { get; set; }

}
