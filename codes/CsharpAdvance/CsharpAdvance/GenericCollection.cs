namespace CsharpAdvance;

public class GenericCollection
{

    public List<string>? Names { get; set; }
    public List<string> Names1 { get; set; } = new List<string>();
    public List<string> Names2 { get; set; } = new();
    public List<string> Names3 { get; set; } = [];


    public static void DictionaryExample()
    {
        var dictionary = new Dictionary<string, object>
        {
            //["name"] = "张三",
            //["age"] = 18,
            { "name", "张三" },
            { "age", 18 }
        };

        foreach (var item in dictionary)
        {
            Console.WriteLine($"Key:{item.Key},Value:{item.Value}");
        }
    }

    public void ListExample()
    {
        string[] names = ["张三", "李四", "王五"];
        string[] names1 = { "张三", "李四", "王五" };
        var names2 = new string[] { "张三", "李四", "王五" };
        string[] names3 = [];

        // 使用List
        var list = new List<string> { "张三", "李四", "王五" };
        List<string> list1 = new() { "张三", "李四", "王五" };
        List<string> list2 = ["张三", "李四", "王五"];
        List<string> list3 = [];
    }

    public static void InlineExample()
    {
        string dateTimeString = "1990-01-01 13:22:11";
        string second = dateTimeString[^2..]; // 获取最后两个字符
        string dateString = dateTimeString[0..10];  //获取索引0-9的字符，不包含10

        Console.WriteLine(second);
        Console.WriteLine(dateTimeString);

        // 使用.. 内联集合值
        List<string> c1 = ["a", "b", "c"];
        List<string> c2 = ["d", "e", "f", "g"];
        List<string> c3 = [.. c1, .. c2];
        Console.WriteLine(string.Join(',', c3));
    }

}
