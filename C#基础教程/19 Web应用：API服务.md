# Web应用：API服务

后台提供API服务，前端通过API调用后台服务，这是现代Web应用的常见模式。

## 从MVC到API

我们之前已经见过`MVC`设计模式了，`控制器`返回`view`，本质上是通过`http`协议返回`html`内容。

那么在前后端分离的开发模式中，我们通常返回`json`格式的数据，然后前端获取到数据进行渲染即可。

也就是说`MVC`的整体架构仍然适用于`API`，只是返回内容不同，只需要针对`API`做一些易用性的支持台即可。

## 编写接口

我们接下来将使用接口的方式，来实现记事本的功能。

- 添加新项目，选择`ASP.NET Core Web API`，名称为`WebAPI`，在更多选择中，将`使用Controller`选项去除，然后创建即可。
- 引用`Core`类库。
- 修改`Program.cs`中代码

```csharp
using Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 获取记事本接口
app.MapGet("/notes", (IWebHostEnvironment _env) =>
{
    var note = new NoteService(_env.ContentRootPath);
    return note.GetNotes();
});

// 添加内容
app.MapPost("/notes", (IWebHostEnvironment _env, string content) =>
{
    var noteService = new NoteService(_env.ContentRootPath);
    noteService.Save(content);
    return Results.Ok();
});

app.Run();
```

我们在项目根目录下执行`dotnet watch run`.我们将看到`swagger`页面，可以通过`swagger`页面来测试接口。

> [!NOTE]
> 如果运行出现错误，可在VS中右键项目，选择编译，编译成功后，再运行。

>
> [!TIP]
> 编写API，有基于传统`MVC`而来的`Controller`方式，也有`MiniAPI`方式，这里我们使用`MiniAPI`来演示，它对于只有几个接口的简单项目非常适用。

## 总结

可以看到，API的方式更关注于后台的逻辑，跟页面没有关系，它只需要接收、处理和返回数据，至于数据之后怎么处理，这不是它的事。

这样的好处是，我们已经见过很多类型的客户端了，所有的客户端都可以通过`Http`去向接口请求数据，然后在自己的客户端进行渲染。

> [!TIP]
> 可以通过免费视频[ASP.NET Core API](https://www.bilibili.com/video/BV1FC411r7q7/?spm_id_from=333.788&vd_source=7989703b95b1c04d56c116d2748f5059)，了解更多关于API相关的内容。
