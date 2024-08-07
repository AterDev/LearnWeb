namespace CsharpAdvance.XmlComment;
public class XmlComment
{
    // 代码注释
    public static void CodeComment()
    {
        var a = 1; // 单选注释
        /* 
         * 多行注释
         * var b = 2;
         * var c = 3;
         */

        //var b = 2;
        //var c = 3;
    }

    /// <summary>
    /// 注释跳转
    /// </summary>
    /// <param name="xml"></param>
    /// <see href="http://blog.dusi.dev" cref="Parse.ParseXml(string)"/>
    /// <returns></returns>
    public string Example(string xml)
    {
        // TODO:预处理
        var res = Parse.ParseXml(xml);
        return res;
    }

    /// <summary>
    /// 注释继承
    /// </summary>
    public void Example1()
    {
        var cat = new Cat()
        {
            Name = "小黑"
        };

        cat.Speak("喵！");
    }

}
