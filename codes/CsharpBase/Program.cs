string data = """
小明 18  2.5
小红  19  3。2
  张三   20    3500
李四  21  4000 
""";

// 使用换行符进行分割，转换成数组
var lines = data.Split("\n");


foreach (var line in lines)
{
    var parts = line.Split(" "); // 使用一个空格分隔内容

    //parts = parts.Where(p => !string.IsNullOrEmpty(p)).ToArray(); // 过滤空格

    string[] tempParts = new string[3];
    var index = 0;
    foreach (var item in parts)
    {
        if (!string.IsNullOrEmpty(item) && index < 3)
        {
            tempParts[index] = item;
            index++;
        }
    }
    parts = tempParts;

    int money; // 存款(元)
    // 对存款进行特殊兼容处理
    string moneyStr = parts[2];
    moneyStr = moneyStr.Replace("。", "."); // 替换全角符号
    // 统一成元为单位的整数
    if (moneyStr.Contains('.'))
    {
        double doubleMoney = double.Parse(moneyStr);// 转换成double
        money = (int)(doubleMoney * 10000); // 转换成整数
        parts[2] = money.ToString();
    }
    string newLine = string.Join(',', parts);
    Console.WriteLine(newLine);
}