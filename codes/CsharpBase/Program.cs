/// <summary>
/// 个人
/// </summary>
public class Person
{
    /// <summary>
    /// 姓名
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// 年龄
    /// </summary>
    public int Age { get; set; }
    /// <summary>
    /// 存款
    /// </summary>
    public decimal Money { get; set; }
}

/// <summary>
/// 男人
/// </summary>
public class Man : Person, IMan, IWorker, IFather, IHusband
{
    public void BuyBagsForWife()
    {
        Console.WriteLine("为妻子买包");
    }

    public void EarnMoney()
    {
        Console.WriteLine("挣钱");
    }

    public void RaiseChildren()
    {
        Console.WriteLine("养小孩");
    }

    public void Work()
    {
        Console.WriteLine("打工");
    }
}

/// <summary>
/// 男人
/// </summary>
public interface IMan
{
    /// <summary>
    /// 挣钱
    /// </summary>
    void EarnMoney();
}
/// <summary>
/// 打工人
/// </summary>
public interface IWorker
{
    void Work();
}
/// <summary>
/// 父亲
/// </summary>
public interface IFather
{
    /// <summary>
    /// 养小孩
    /// </summary>
    void RaiseChildren();
}
/// <summary>
/// 丈夫
/// </summary>
public interface IHusband
{
    /// <summary>
    /// 为妻子买包
    /// </summary>
    void BuyBagsForWife();
}