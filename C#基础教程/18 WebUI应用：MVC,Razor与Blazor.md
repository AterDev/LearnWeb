# WebUI应用：MVC,Razor Pages和Blazor

微软为除了为桌面开发者提供了很多专门的解决方案，也为Web开发者提供了很多解决方案。在互联网的影响下，微软内部本身也有很多Web开发的需求，这也催生了很多Web开发的技术，包括`Typescript`的出现。

时至今日，如果我们要开发WebUI应用，我们可以选择`MVC`，`Razor Pages`和`Blazor`，而不用考虑`ASP`，`WebForm`等过时的技术。

## 创建示例解决方案

我们暂时不用关心`MVC`，`Razor Pages`和`Blazor`的区别，这不是基础教程要教的内容，我们还是通过示例直观感受下。

创建新项目，选择`ASP.NET Core Web App(MVC)`，命名为`MvcApp`，解决方案名称为`WebUISample`，使用默认选项创建即可。

## 项目示例

这次，我们来做一个简单的记事本示例：

- 用户通过网页输入内容，然后提交；
- 我们将提交内容保存起来(存储到本地文件);
- 查询本地文件，将多个内容显示在网页上;

对文件的读写逻辑，是可以复用的，所以我们可以将这部分逻辑单独提取出来，放到一个类库项目中。

## 类库编写

添加一个类库项目，命名为`Core`，然后添加一个类，命名为`NoteService`，代码如下：

```csharp
namespace Core;

public class NoteService
{
    public string RootPath { get; init; }
    public NoteService(string path)
    {
        RootPath = path;
    }

    /// <summary>
    /// 写入文件
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public bool Save(string content)
    {
        var fileName = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString() + ".txt";
        try
        {
            File.WriteAllText(Path.Combine(RootPath + fileName), content);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    /// <summary>
    /// 获取所有文件内容
    /// </summary>
    /// <returns></returns>
    public List<string> GetNotes()
    {
        var res = new List<string>();
        var files = Directory.GetFiles(RootPath, "*.txt", SearchOption.TopDirectoryOnly);
        foreach (var file in files)
        {
            res.Add(File.ReadAllText(file));
        }
        return res;
    }
}

```

代码很简单，就是写入文件和读取文件的逻辑。

## MVC

现在将我们的关注点放到`MVC`项目，可以看到`MvcApp`的项目目录结构，包含了`Controllers`,`Models`,`Views`，就是MVC的三个核心部分。

现在我们来实现页面部分，将`Views/Home/Index.cshtml`的内容替换为：

```html
<div class="container p-0">
    <div class="d-flex gap-2">
        <div class="col-6">
            @* 用户录入 *@
            <form action="Index">
                <textarea class="form-control" placeholder="写下您的记录" rows="5"></textarea>
                <button class="btn btn-primary">保存</button>
            </form>
        </div>
        <div class="col-6">
            @* 内容展示 *@
            <div class="d-flex flex-column gap-2">
                <pre>笔记本内容</pre>
            </div>
        </div>
    </div>
</div>
```

现在我们来运行项目，在命令行中定位到`MvcApp`项目根目录下，然后使用`dotnet watch run`来运行项目。

我们将看到类似内容:
![mvc](../images/csharpBase/mvcapp1.png)

目前还只是简单的布局，既没有按钮事件，也没有显示逻辑，接下来我们来实现逻辑。

> [!TIP]
> 使用`dotnet watch run`，可以在代码发生变化时，自动重新编译并运行项目，而不用反复手动操作。在Web开发中非常有用。

### 实现控制器

引用`Core`类库，然后将`HomeController`替换成:

```csharp
using Core;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers;
public class HomeController(ILogger<HomeController> logger, IWebHostEnvironment env) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly IWebHostEnvironment _env = env;

    [HttpGet]
    public IActionResult Index()
    {
        var noteService = new NoteService(_env.WebRootPath);
        var notes = noteService.GetNotes();
        return View(notes);
    }

    [HttpPost]
    public IActionResult Index(string content)
    {
        var noteService = new NoteService(_env.WebRootPath);
        var res = noteService.Save(content);
        return RedirectToAction("Index");
    }
}
```

现在我们更新下`Index.cshtml`，内容如下:

```razor
@model List<string>
<div class="container p-0">
    <div class="d-flex gap-2">
        <div class="col-6">
            @* 用户录入 *@
            <form asp-action="Index" method="post">
                <textarea class="form-control" placeholder="写下您的记录" rows="5" name="content"></textarea>
                <button type="submit" class="btn btn-primary">保存</button>
            </form>
        </div>
        <div class="col-6">
            @* 内容展示 *@
            <div class="d-flex flex-column">
                @foreach (var item in Model)
                {
                    <pre style="border:1px solid gray;padding:8px">@item</pre>
                }
            </div>
        </div>
    </div>
</div>
```

可以看到，`Index.cshtml`从纯`html`内容，加入了一些模板变化，以及模型绑定，用来将我们控制器返回的`notes`变量，可以在页面上显示。

现在我们来输入内容并点击保存按钮，看下实际的效果。

### 总结说明

MVC设计模式，其实就是抽象页面中要提交的数据以及要展示的数据，将它们定义成模型，而控制器用来实现逻辑，如接收请求的模型，以及返回响应的模型，MVC框架会自己将返回的模型绑定，我们可以直接在页面中使用。

此外，cshtml中的语法，我们通常称之为`razor`，它设计精妙，使用灵活方便，只需要记住一个'@'符号，就可以在html中嵌入C#代码，非常方便。

## 使用Razor Page来实现

现在我们来看看`Razor Page`是如何实现以上内容的。

### 创建项目

右键解决方案，添加新项目，选择`ASP.NET Core Web App(Razor Pages)`，命名为`RazorPage`。

然后引用`Core`项目，我们将复用`NoteService`类。

### 逻辑实现

我们先修改`Index.cshtml`，内容如下:

```razor
@page
@model IndexModel
<div class="container p-0">
    <div class="d-flex gap-2">
        <div class="col-6">
            @* 用户录入 *@
            <form asp-action="Index" method="post">
                <textarea class="form-control" placeholder="写下您的记录" rows="5" name="content"></textarea>
                <button type="submit" class="btn btn-primary">保存</button>
            </form>
        </div>
        <div class="col-6">
            @* 内容展示 *@
            <div class="d-flex flex-column">
                @foreach (var item in Model.Notes)
                {
                    <pre style="border:1px solid gray;padding:8px">@item</pre>
                }
            </div>
        </div>
    </div>
</div>
```

然后，我们来实现`Index.cshtml.cs`:

```csharp
using Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage.Pages;
public class IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment env) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IWebHostEnvironment _env = env;
    public List<string> Notes { get; set; } = [];
    public void OnGet()
    {
        var noteService = new NoteService(_env.WebRootPath);
        Notes = noteService.GetNotes();
    }

    public void OnPost(string content)
    {
        var noteService = new NoteService(_env.WebRootPath);
        var res = noteService.Save(content);
        Notes = noteService.GetNotes();
    }
}
```

现在我们来运行项目，看下效果。

### Razor Page总结

`Razor Page`从名称能看出来，它是对`Page`的抽象，页面是核心，其他是用来配合Page的展示的。它比较适合制作简单可复用的组件，然后在其他项目中使用，因为它以Page为单位，不用依赖其他内容。

而MVC是以`Controller`为核心，`Views`是用来展示的，它可有可无。

## Blazor

`Blazor`是近几年来微软着重投资并且发展较好的技术。

如果说`MVC`重后端逻辑，`Razor Page`是前后端结合，那么`Blazor`就是前端技术。它本质上是运行在`浏览器`中的，而不是服务器中。

我们还是通过项目直观感受下其中的不同吧。

### 创建项目

选择`Blazor WebAssembly Standalone App`，命名为：`BlazorApp`。

由于`Blazor`是基于`wasm`运行在浏览器中的，我们无法直接访问本地文件，所以本示例就不再实现文件读写逻辑了。

我们直接修改`Home.razor`中的内容:

```razor
@page "/"
<PageTitle>Home</PageTitle>
<div class="container p-0">
    <div class="d-flex gap-2">
        <div class="col-6">
            @* 用户录入 *@
            <textarea class="form-control" placeholder="写下您的记录" rows="5" @bind="Content"></textarea>
            <button class="btn btn-primary" @onclick="AddNote">保存</button>
        </div>
        <div class="col-6">
            @* 内容展示 *@
            <div class="d-flex flex-column">
                @foreach (var item in Notes)
                {
                    <pre style="border:1px solid gray;padding:8px">@item</pre>
                }
            </div>
        </div>
    </div>
</div>
@code {
    public List<string> Notes { get; set; } = [];
    public string Content { get; set; } = "";

    void AddNote()
    {
        Notes.Add(Content);
        Content = "";
    }
}
```

现在我们来运行项目，看下效果。

这里我们将逻辑写到了`@code{}`代码块中，当然对于复杂的应用，我们也仍然可拆分成`.cs`文件来编写逻辑代码，这就与`Razor Page`有些接近了。

## 总结

技术的发展总是不断的迭代，`MVC`，`Razor Page`和`Blazor`都是微软为Web开发者提供的解决方案，面向不同的场景，我们可以根据实际需求来选择。
它们之间有不同，也有相似之处，在模板实现方面都使用了`razor`语法。

在实际开发中，我们可以根据实际需求来选择

- `MVC`适合后端逻辑复杂的应用
- `Razor Page`适合简单的页面，以及可复用的情景
- `Blazor`适合使用`C#`和`.NET`生态来开发浏览器应用
