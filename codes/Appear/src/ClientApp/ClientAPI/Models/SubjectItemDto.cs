namespace ClientAPI.Models;
/// <summary>
/// 主题列表元素
/// </summary>
public class SubjectItemDto {
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public string Name { get; set; } = default!;
    public SubjectType SubjectType { get; set; }
    /// <summary>
    /// 开始日期
    /// </summary>
    public DateOnly StartDate { get; set; } = default!;
    /// <summary>
    /// 结束日期
    /// </summary>
    public DateOnly EndDate { get; set; } = default!;

}
