using Models.SubjectType';
namespace Models.ResourceClient.Subject
/// <summary>
/// 主题查询筛选
/// </summary>
public class SubjectFilterDto {
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public object? OrderBy { get; set; }
    public string? Name { get; set; }
    public SubjectType SubjectType { get; set; }
    /// <summary>
    /// 开始日期
    /// </summary>
    public string? StartDate { get; set; }
    /// <summary>
    /// 结束日期
    /// </summary>
    public string? EndDate { get; set; }

}
