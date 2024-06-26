using System.Net;
using System.Net.Sockets;
using System.Text;

public class SocketHelper
{
    /// <summary>
    /// 端口
    /// </summary>
    public int Port { get; init; }

    public string Name { get; init; }
    public Socket Socket { get; init; }
    public SocketHelper(string name, int port)
    {
        Name = name;
        Port = port;
        Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
            SendTimeout = 1000
        };
    }

    public void StartRun(int? targetPort = null)
    {
        Socket.Bind(new IPEndPoint(IPAddress.Any, Port));

        if (Name == "p1")
        {
            // 如果是p1，则主动连接p2
            Socket.Connect(new IPEndPoint(IPAddress.Loopback, targetPort.Value));
            Output("连接成功");
            Socket.Send(Encoding.UTF8.GetBytes($"你好，我是{Name}"));

            var buffer = new byte[1024];
            var received = Socket.Receive(buffer);
            var data = Encoding.UTF8.GetString(buffer, 0, received);
            Output("收到数据：" + data);
        }
        else
        {
            // 监听
            Socket.Listen(10);
            Output($"开始监听：" + Port);
            while (true)
            {
                var client = Socket.Accept();
                Output("新连接建立：" + client.RemoteEndPoint?.ToString());
                var buffer = new byte[1024];
                var received = client.Receive(buffer);
                var data = Encoding.UTF8.GetString(buffer, 0, received);
                Output("收到数据：" + data);

                Task.Delay(1000).Wait();
                client.Send(Encoding.UTF8.GetBytes($"我是{Name},已经收到信息了"));
                client.Close();
            }
        }
    }
    private void Output(string msg)
    {
        Console.WriteLine($"[{Name}]: {msg}");
    }
}