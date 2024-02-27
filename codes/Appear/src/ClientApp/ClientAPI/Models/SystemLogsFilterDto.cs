namespace ClientAPI.Models;
/// <summary>
/// 系统日志查询筛选
/// </summary>
public class SystemLogsFilterDto {
    public int PageIndex { get; set; } = default!;
    public int PageSize { get; set; } = default!;
    public Dictionary<string, bool>? OrderBy { get; set; }
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
    public DateOnly? StartDate { get; set; }
    /// <summary>
    /// 结束时间
    /// </summary>
    public DateOnly? EndDate { get; set; }
    public Guid? SystemUserId { get; set; }

}
