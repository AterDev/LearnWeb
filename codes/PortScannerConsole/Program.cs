using System.Net;
using System.Text;
using PortScanner;

if (args.Length == 0)
{
    Console.WriteLine("请输入IP地址");
    return;
}
string ip = args[0];
if (IPAddress.TryParse(ip, out var ipAddress))
{
    try
    {
        var startPort = args.Length > 1 ? int.Parse(args[1]) : 1;
        var endPort = args.Length > 2 ? int.Parse(args[2]) : 80;
        Console.WriteLine("开始扫描ip:" + ip);
        var helper = new ScannerHelper(ipAddress, startPort, endPort);
        var ports = helper.ScanPortsTask();
        Console.WriteLine("扫描完成");

        if (ports.Count > 0)
        {
            var content = string.Join(Environment.NewLine, ports);
            await File.WriteAllTextAsync("./result.txt", content, Encoding.UTF8);
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("请输入正确的端口");
    }
}
else
{
    Console.WriteLine("IP地址不合法");
}
