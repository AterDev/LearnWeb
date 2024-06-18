
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("请输入一个值，判断是整数、小数、布尔值、日期时间还是字符串");
string? input = Console.ReadLine();// 等待输入
if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("输入为空，不判断");
}
else if (int.TryParse(input, out int number))
{
    Console.WriteLine("输入的是整数:" + number);
}
else if (double.TryParse(input, out double doubleNumber))
{
    Console.WriteLine("输入的是小数:" + doubleNumber);
}
else if (bool.TryParse(input, out bool boolValue))
{
    // true or false，不区分大小写，都会认为是bool
    Console.WriteLine("输入的是布尔值:" + boolValue);
}
else if (DateTime.TryParse(input, out DateTime dateTime))
{
    Console.WriteLine("输入的是日期时间:" + dateTime);
}
else
{
    Console.WriteLine("输入的是字符串:" + input);
}
