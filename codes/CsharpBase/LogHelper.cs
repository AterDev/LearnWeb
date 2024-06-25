using System.Text;

public class LogHelper
{
    public static void Write(string msg)
    {
        // 如果目录不存在，则创建
        if (!Directory.Exists("logs"))
        {
            Directory.CreateDirectory("logs");
        }

        var date = DateTime.Now.ToString("yyyy-MM-dd");
        var time = DateTime.Now.ToString("HH:mm:ss");

        // 每天一个日志文件
        string logPath = Path.Combine("logs", date + ".log");

        // 不存在，则创建该文件
        if (!File.Exists(logPath))
        {
            File.Create(logPath).Close();
        }

        //  追加写入
        using (var sw = new StreamWriter(logPath, true, Encoding.UTF8))
        {
            sw.WriteLine($"{time} {msg}");
        }
    }

    /// <summary>
    /// 获取异常信息
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static List<string> GetExceptionMessage(string path)
    {
        List<string> messages = [];

        // 简单做法，读取所有行: var lines = File.ReadAllLines(path);
        using (var sr = new StreamReader(path, Encoding.UTF8))
        {
            while (!sr.EndOfStream)
            {
                // 每次只读取一行
                var line = sr.ReadLine();
                if (line != null && line.Contains("异常"))
                {
                    messages.Add(line);
                }
            }
        }
        return messages;
    }
}