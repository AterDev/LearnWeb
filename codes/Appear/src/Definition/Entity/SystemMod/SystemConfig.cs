namespace Entity.System;
/// <summary>
/// 系统配置
/// </summary>
[Index(nameof(Key))]
[Index(nameof(IsSystem))]
[Index(nameof(Valid))]
[Index(nameof(GroupName))]
[Module(Modules.System)]
public class SystemConfig : IEntityBase
{
    #region const 
    public const string System = "System";
    #endregion

    [MaxLength(100)]
    public required string Key { get; set; }
    /// <summary>
    /// 以json字符串形式存储
    /// </summary>
    [MaxLength(2000)]
    public string Value { get; set; } = string.Empty;
    [MaxLength(500)]
    public string? Description { get; set; }
    public bool Valid { get; set; } = true;

    /// <summary>
    /// 是否属于系统配置
    /// </summary>
    public bool IsSystem { get; set; }

    /// <summary>
    /// 组
    /// </summary>
    public string? GroupName { get; set; }
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
}
