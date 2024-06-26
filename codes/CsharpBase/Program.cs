var p1 = new SocketHelper("p1", 10001);
var p2 = new SocketHelper("p2", 10002);

// p2作为服务端，先启动
var p2Task = Task.Run(() => p2.StartRun());
await Task.Delay(1000);
// p1作为客户端，连接p2
var p1Task = Task.Run(() => p1.StartRun(10002));


Task.WaitAll(p2Task, p1Task);