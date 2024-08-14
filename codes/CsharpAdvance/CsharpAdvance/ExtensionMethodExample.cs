using System.Diagnostics.CodeAnalysis;

namespace CsharpAdvance;
/// <summary>
/// 扩展方法示例
/// </summary>
public class ExtensionMethodExample
{

}

/// <summary>
/// 扩展方法
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// 判断是否为空字符串
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNotEmpty([NotNullWhen(true)] this string? str)
    {
        return !string.IsNullOrEmpty(str);
    }
}