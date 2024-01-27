using Models.SubjectType';
using Models.SubjectOption';
namespace Models.ResourceClient.Subject
/// <summary>
/// 主题
/// </summary>
public class Subject {
    public string Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public SubjectType SubjectType { get; set; }
    /// <summary>
    /// 开始日期
    /// </summary>
    public string StartDate { get; set; }
    /// <summary>
    /// 结束日期
    /// </summary>
    public string EndDate { get; set; }
    /// <summary>
    /// 选项
    /// </summary>
    public List<SubjectOption> SubjectOptions { get; set; }

}
