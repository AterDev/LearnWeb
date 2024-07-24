namespace CsharpAdvance;
public class StringExample
{

    public static void NormalString()
    {
        var path = "c:\\for\\bar.txt";
        var sentence = "小明说：\"他很穷，吃不起饭了\"";
        var dialog = "小明说：\"粮食短缺\"\n小红说：\"可以去打野！\"";

        Console.WriteLine(path);
        Console.WriteLine(sentence);
        Console.WriteLine(dialog);
    }
    public static void EscapingString()
    {
        var path = @"c:\for\bar.txt";
        var sentence = @"小明说：""他很穷，吃不起饭了""";
        var dialog = @"小明说：""粮食短缺""
小红说：""可以去打野！""";
        Console.WriteLine(path);
        Console.WriteLine(sentence);
        Console.WriteLine(dialog);
    }

    public static void InterpolationString()
    {
        var fileName = "bar.txt";
        var path0 = $"c:\\{fileName}";
        var path1 = $@"c:\{fileName}";
        var path2 = $@"c:\{{{fileName}}}";

        Console.WriteLine("path0:{0}", path0);
        Console.WriteLine("path1:{0}", path1);
        Console.WriteLine("path2:{0}", path2);
    }

    public static void RawString()
    {
        var fileName = "bar.txt";

        var path0 = $"""c:\{fileName}""";
        var path1 = $$"""the {path} is c:\{{fileName}}""";
        var path2 = $$$"""the {{path}} is c:\{{{fileName}}}""";

        var sentence = """
            小明说："粮食短缺"
            小红说:"可以去打野" 
            """;
        var json = """
            {
                "name": "张三",
                "age": 18
            }
            """;

        Console.WriteLine(path0);
        Console.WriteLine(path1);
        Console.WriteLine(path2);
        Console.WriteLine(sentence);
        Console.WriteLine(json);
    }
}
