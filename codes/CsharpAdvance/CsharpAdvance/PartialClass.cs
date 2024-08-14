namespace CsharpAdvance;
/// <summary>
/// 分部类和方法
/// </summary>
public partial class PartialClass
{
    /// <summary>
    /// 宽
    /// </summary>
    public int Width { get; set; }
    /// <summary>
    /// 高
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// 求周长和面积
    /// </summary>
    public void Calculate()
    {
        CalculateLength();
        CalculateArea();
    }

    public PartialClass(int width, int height)
    {
        Width = width;
        Height = height;
        Calculate();
    }

    /// <summary>
    /// 待实现
    /// </summary>
    public partial void CalculateLength();

    /// <summary>
    /// 待实现
    /// </summary>
    public partial void CalculateArea();
}


/// <summary>
/// 另一个人实现算法
/// </summary>
public partial class PartialClass
{
    /// <summary>
    /// 周长
    /// </summary>
    public int Length { get; private set; }

    /// <summary>
    /// 面积
    /// </summary>
    public int Area { get; private set; }

    /// <summary>
    /// 计算长度
    /// </summary>
    public partial void CalculateLength()
    {
        Length = 2 * (Width + Height);
    }

    /// <summary>
    /// 计算面积
    /// </summary>
    public partial void CalculateArea()
    {
        Area = Width * Height;
    }
}
