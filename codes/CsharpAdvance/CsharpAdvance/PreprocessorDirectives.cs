namespace CsharpAdvance;
/// <summary>
/// 预处理指令
/// </summary>
public class PreprocessorDirectives
{
    #region 库字段
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    #endregion

    #region 基本属性
    public required string Title { get; set; }
    public string? Content { get; set; }
    #endregion

    #region 业务关联属性
    public List<string> Tags { get; set; } = [];

    /// <summary>
    /// 关于用户的id
    /// </summary>
    public Guid UserId { get; set; }
    #endregion

    #region 方法
    public void Save()
    {
        // 保存数据
    }
    #endregion

    #region 私有方法
    private void Load()
    {
        // 加载数据
    }
    #endregion


    public static void Test()
    {
#if DEBUG
        Console.WriteLine("开发调试时输出的内容");
#endif
        // _logger.Log("记录日志");
    }

    static long GetUnixTimestamp()
    {
#if NET6_0_OR_GREATER
        // .NET Core 实现
        return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
#elif NET47
        // .NET Framework 实现
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (long)(DateTime.UtcNow - epoch).TotalSeconds;
#endif
    }
}
