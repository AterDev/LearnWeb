using System.Diagnostics;
using System.Text;
public class ProcessHelper
{
    public static Process[] GetProcesses()
    {
        return Process.GetProcesses();
    }

    public static double BytesToMegabytes(long bytes)
    {
        return bytes / 1024f / 1024f;
    }


    /// <summary>
    /// 运行命令
    /// </summary>
    /// <param name="command">命令程序</param>
    /// <param name="args">参数</param>
    /// <param name="output"></param>
    /// <returns></returns>
    public static bool RunCommand(string command, string? args, out string output)
    {
        var process = new Process();
        process.StartInfo.FileName = command;
        process.StartInfo.Arguments = args;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardOutput = true;

        var outputBuilder = new StringBuilder();
        var outputErrorBuilder = new StringBuilder();

        // 输出事件
        process.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                outputBuilder.AppendLine(e.Data);
            }
        };

        // 错误输出事件
        process.ErrorDataReceived += (sender, e) =>
        {

            if (!string.IsNullOrEmpty(e.Data))
            {
                outputErrorBuilder.AppendLine(e.Data);
            }
        };
        // 启动进程
        process.Start();
        // 读取输出
        process.BeginOutputReadLine();
        // 读取错误输出
        process.BeginErrorReadLine();
        // 等待进程结束
        process.WaitForExit();

        // 获取输出内容
        var errorOutput = outputErrorBuilder.ToString();
        output = outputBuilder.ToString();
        if (!string.IsNullOrWhiteSpace(errorOutput))
        {
            Console.WriteLine(errorOutput);
            return false;
        }
        else
        {
            Console.WriteLine(output);
            return true;
        }
    }
}