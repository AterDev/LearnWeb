// 模拟日志数据
LogHelper.Write("启动程序");
LogHelper.Write("运行程序");
for (int i = 0; i < 100; i++)
{
    if (i % 13 == 0)
    {
        LogHelper.Write("异常情况：" + i);
    }
    else
    {
        LogHelper.Write("正常日志：" + i);
    }
}
LogHelper.Write("结束程序");

// 读取异常
var date = DateTime.Now.ToString("yyyy-MM-dd");
var logPath = Path.Combine("logs", date + ".log");

LogHelper.GetExceptionMessage(logPath)
    .ForEach(Console.WriteLine);
