using Models.ActionType';
namespace Models.ResourceClient.SystemLogs
/// <summary>
/// 系统日志查询筛选
/// </summary>
public class SystemLogsFilterDto {
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public object? OrderBy { get; set; }
    /// <summary>
    /// 操作人名称
    /// </summary>
    public string? ActionUserName { get; set; }
    /// <summary>
    /// 操作对象名称
    /// </summary>
    public string? TargetName { get; set; }
    public ActionType ActionType { get; set; }
    /// <summary>
    /// 开始时间
    /// </summary>
    public string? StartDate { get; set; }
    /// <summary>
    /// 结束时间
    /// </summary>
    public string? EndDate { get; set; }
    public string? SystemUserId { get; set; }

}
