using Models.ActionType';
namespace Models.ResourceClient.SystemLogs
/// <summary>
/// 系统日志列表元素
/// </summary>
public class SystemLogsItemDto {
    /// <summary>
    /// 操作人名称
    /// </summary>
    public string ActionUserName { get; set; }
    /// <summary>
    /// 操作对象名称
    /// </summary>
    public string TargetName { get; set; }
    /// <summary>
    /// 操作路由
    /// </summary>
    public string Route { get; set; }
    public ActionType ActionType { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string? Description { get; set; }
    public string Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }

}
