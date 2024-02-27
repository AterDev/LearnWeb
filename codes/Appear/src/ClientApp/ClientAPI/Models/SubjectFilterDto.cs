namespace ClientAPI.Models;
/// <summary>
/// 主题查询筛选
/// </summary>
public class SubjectFilterDto {
    public int PageIndex { get; set; } = default!;
    public int PageSize { get; set; } = default!;
    public Dictionary<string, bool>? OrderBy { get; set; }
    public string? Name { get; set; }
    public SubjectType SubjectType { get; set; }
    /// <summary>
    /// 开始日期
    /// </summary>
    public DateOnly? StartDate { get; set; }
    /// <summary>
    /// 结束日期
    /// </summary>
    public DateOnly? EndDate { get; set; }

}
