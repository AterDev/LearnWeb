var httpServer = new SocketHelper("httpServer", 8080);
// p2作为服务端，先启动
var p2Task = Task.Run(() => httpServer.StartHttpServer());
await Task.Delay(500);

var http = new HttpHelper("http://localhost:8080");
await http.GetTest();

await Task.Delay(500);

await http.PostTest();

Task.WaitAll(p2Task);
