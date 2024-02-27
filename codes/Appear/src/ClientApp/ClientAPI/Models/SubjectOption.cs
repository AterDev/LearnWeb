namespace ClientAPI.Models;
/// <summary>
/// 主题选项
/// </summary>
public class SubjectOption {
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
    /// <summary>
    /// 主题
    /// </summary>
    public Subject Subject { get; set; } = default!;
    public Guid SubjectId { get; set; } = default!;
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; } = default!;
    public string? Detail { get; set; }
    /// <summary>
    /// 投票数量
    /// </summary>
    public int Count { get; set; } = default!;

}
