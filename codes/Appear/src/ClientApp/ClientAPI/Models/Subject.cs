namespace ClientAPI.Models;
/// <summary>
/// 主题
/// </summary>
public class Subject {
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    public bool IsDeleted { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public SubjectType SubjectType { get; set; }
    /// <summary>
    /// 开始日期
    /// </summary>
    public DateOnly StartDate { get; set; } = default!;
    /// <summary>
    /// 结束日期
    /// </summary>
    public DateOnly EndDate { get; set; } = default!;
    /// <summary>
    /// 选项
    /// </summary>
    public List<SubjectOption> SubjectOptions { get; set; }

}
