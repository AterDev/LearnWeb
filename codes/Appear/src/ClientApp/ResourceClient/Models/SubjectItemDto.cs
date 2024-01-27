using Models.SubjectType';
namespace Models.ResourceClient.Subject
/// <summary>
/// 主题列表元素
/// </summary>
public class SubjectItemDto {
    public string Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public string Name { get; set; }
    public SubjectType SubjectType { get; set; }
    /// <summary>
    /// 开始日期
    /// </summary>
    public string StartDate { get; set; }
    /// <summary>
    /// 结束日期
    /// </summary>
    public string EndDate { get; set; }

}
