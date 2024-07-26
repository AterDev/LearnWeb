namespace CsharpAdvance;
public class AttributeExample
{
    [Description("人员信息")]
    [MaxLength(100, ErrorMessage = "超出了最大长度100")]
    public required string Name { get; set; }

    public Gender Gender { get; set; }

    public void SetName(string newName)
    {
        Name = newName;
    }

    [Obsolete("请使用 SetNewName 方法")]
    public void SetNewName([MaxLength(100)] string newName)
    {
        Name = newName;
    }
}
/// <summary>
/// 性别
/// </summary>
public enum Gender
{
    [Description("男")]
    男,
    [Description("女")]
    女
}

