using System.Net;
using PortScanner;

string ip = "110.42.161.183";
if (IPAddress.TryParse(ip, out var ipAddress))
{
    Console.WriteLine("开始扫描ip:" + ip);
    var helper = new ScannerHelper(ipAddress, 20, 10000);

    var ports = helper.ScanPortsTaskAsync();

    Console.WriteLine("扫描完成");
}
else
{
    Console.WriteLine("IP地址不合法");
}
