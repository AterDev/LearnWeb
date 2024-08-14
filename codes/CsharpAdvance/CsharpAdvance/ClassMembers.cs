namespace CsharpAdvance;
/// <summary>
/// 类的成员
/// </summary>
public class ClassMembers
{

}

/// <summary>
/// 定义一个人
/// </summary>
public class Person
{
    private string _name = string.Empty;
    /// <summary>
    /// 姓名，一个人必须要有名称
    /// </summary>
    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

    /// <summary>
    /// 年龄，是计算出来的，可读，不可改
    /// </summary>
    public int? Age
    {
        get
        {
            // 通过Birthday计算年龄
            if (Birthday.HasValue)
            {
                var now = DateTimeOffset.Now;
                var age = now.Year - Birthday.Value.Year;
                if (now < Birthday.Value.AddYears(age))
                {
                    age--;
                }
                return age;
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// 生日，敏感信息，可为空，但外部不可读取，内部也不可修改
    /// </summary>
    public DateTimeOffset? Birthday { private get; init; }


    public Person(string name)
    {
        Name = name;
    }

    public void ChangeName(string newName)
    {
        Name = newName;
        // TODO:修改名称带来的其他变更
    }
}

