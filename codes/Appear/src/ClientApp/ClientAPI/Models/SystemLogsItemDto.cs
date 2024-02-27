namespace ClientAPI.Models;
/// <summary>
/// 系统日志列表元素
/// </summary>
public class SystemLogsItemDto {
    /// <summary>
    /// 操作人名称
    /// </summary>
    public string ActionUserName { get; set; } = default!;
    /// <summary>
    /// 操作对象名称
    /// </summary>
    public string TargetName { get; set; } = default!;
    /// <summary>
    /// 操作路由
    /// </summary>
    public string Route { get; set; } = default!;
    public ActionType ActionType { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string? Description { get; set; }
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;

}
