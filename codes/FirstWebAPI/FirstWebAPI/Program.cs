var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

// 默认路由返回
app.Map("/", () => "Hello World!");
// 返回请求内容
app.Map("/{name}", (string name) => "Hello " + name);

// 使用控制器默认路由模板
//app.MapDefaultControllerRoute();


app.MapControllers();


app.Run();
