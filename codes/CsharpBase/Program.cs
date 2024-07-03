var httpServer = new SocketHelper("httpServer", 8080);
var httpTask = Task.Run(() => httpServer.StartHttpServer());
await Task.Delay(500);

var http = new HttpHelper("http://localhost:8080");
await http.GetTest();

await Task.Delay(500);

await http.PostTest();

Task.WaitAll(httpTask);
