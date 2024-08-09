namespace CsharpAdvance.XmlComment;

/// <summary>
/// Pasre xml
/// </summary>
internal class Parse
{
    /// <summary>
    /// 解析算法实现
    /// <paramref name="xml"/> 不可为空
    /// <br/>
    /// <example>
    ///    使用示例:
    /// <code>
    ///    var xmlStr = "";
    ///    Parse.ParseXml(xmlStr);
    /// </code>
    /// </example>
    /// </summary>
    /// 
    /// <param name="xml" > 不可为空的xml格式字符串</param>
    /// <returns>在xxxx的情况下，会返回空，表示xxxx</returns>
    /// <example> parseXml("content")</example>
    /// <exception cref="ArgumentNullException">xml为空字符串时</exception>
    public static string? ParseXml(string xml)
    {
        // TODO：具体实现
        if (string.IsNullOrWhiteSpace(xml))
        {
            throw new ArgumentNullException(nameof(xml), "空字符串");
        }
        return xml;
    }
}

public interface IAnimal
{
    /// <summary>
    /// 发声
    /// </summary>
    /// <param name="content"></param>
    void Speak(string content);
}
public class Animal : IAnimal
{
    public required string Name { get; set; }

    /// <summary>
    /// 动物叫
    /// </summary>
    /// <param name="content"></param>
    public virtual void Speak(string content)
    {
        Console.WriteLine("发音:" + content);
    }
}

public class Cat : Animal
{
    /// <inheritdoc cref="IAnimal.Speak"/>
    public override void Speak(string content)
    {
        base.Speak("猫叫:" + content);
    }
}
