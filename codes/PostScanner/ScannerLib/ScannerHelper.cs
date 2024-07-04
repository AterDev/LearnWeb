using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace ScannerLib;

/// <summary>
/// 扫描帮助类
/// </summary>
public class ScannerHelper(IPAddress ip, int startPort, int endPort)
{
    public int StartPort { get; set; } = startPort;
    public int EndPort { get; set; } = endPort;
    public IPAddress IP { get; set; } = ip;

    public async Task<List<int>> ScanPortsAsync()
    {
        List<int> openPorts = [];
        for (int port = StartPort; port <= EndPort; port++)
        {
            using (var client = new TcpClient())
            {
                try
                {
                    var cancelTask = new CancellationTokenSource(1000);
                    await client.ConnectAsync(IP, port, cancelTask.Token);
                    if (client.Connected)
                    {
                        openPorts.Add(port);
                        Console.WriteLine($"{port} is open");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{port} isn't open:" + ex.Message);
                    continue;
                }
            }
        }
        return openPorts;
    }

    public List<int> ScanPortsTask()
    {
        var openPorts = new ConcurrentBag<int>();
        var ports = Enumerable.Range(StartPort, EndPort - StartPort + 1);
        var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

        Parallel.ForEach(ports, parallelOptions, (port) =>
        {
            using (var client = new TcpClient())
            {
                try
                {
                    var cancelTask = new CancellationTokenSource(1000);
                    client.ConnectAsync(IP, port).Wait(cancelTask.Token);
                    if (client.Connected)
                    {
                        openPorts.Add(port);
                        Console.WriteLine($"{port} is open");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{port} isn't open: " + ex.Message);
                }
            }
        });

        return openPorts.ToList();
    }
}