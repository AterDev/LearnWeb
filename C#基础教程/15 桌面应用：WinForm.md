# 桌面应用：WinForm

命令行对于开发者来说安装和使用很方便，但对于不熟悉或不习惯使用命令行的人来说，使用桌面应用会更加友好。在 Windows 平台上，我们可以使用 WinForm 来开发桌面应用。

我将使用`Visual Studio`来演示之后带有图形化开发的内容，因为这些内容都是特定于平台的。

## 创建WinForm应用

使用VS创建新项目，选择`Windows窗口应用`，其中解决方案名称为`PostScanner`,项目名为`WinFormsApp`。

我们现在来将之前的端口扫描工具做成一个带有UI的应用程序。界面其实很简单，我们需要

- 一些控件来填写参数(TextBox 与 Label)
- 一个按钮来启动扫描(Button)
- 最后一个文本框来显示扫描结果(TextBox)

打开工具箱，我们将进行以下操作：

1. 我们首先把控件拖动到窗口中，并进行排列和文本设置
2. 为需要用到的控件设置`Name`属性，以便在代码中引用
3. 设置结果文本框为多行

最终我们会看到类似内容:

![WinForm](../images/csharpBase/WinForm1.png)

### 通过程序集复用逻辑代码

我们可以将一些可复用的逻辑代码，单独放到一个程序集中，这样可以方便我们在不同的项目中复用。

如对输入参数的判断，以及实际执行`TCPClient`连接的代码。

右键解决方案，添加新项目，选择类库，命名为`ScannerLib`，我们可以将之前的`ScannerHelper.cs`类复制过来。

然后右键`WinformApp`项目，选择添加项目引用，将类库引用到当前项目中。

### 实现UI操作逻辑

界面有了，剩下的就是操作逻辑了。我们要先获取用户输入，对用户输入进行判断，错误时给出提示，没有错误时则执行扫描逻辑。完成后，在文本框中显示扫描结果。

现在我们来双击扫描按钮，进入代码编辑界面。我们需要在这里实现扫描逻辑。

```csharp
private async void scanBtn_Click(object sender, EventArgs e)
{
    // 获取控件值 
    var ipStr = IPBox.Text;
    var startPortStr = startBox.Text;
    var endPortStr = endBox.Text;

    // 判断用户输入
    if (string.IsNullOrWhiteSpace(ipStr))
    {
        MessageBox.Show("ip不可为空");
    }

    if (string.IsNullOrWhiteSpace(startPortStr) || string.IsNullOrWhiteSpace(endPortStr))
    {
        MessageBox.Show("端口不可为空");
    }

    if (int.TryParse(startPortStr, out var startPort) && int.TryParse(endPortStr, out var endPort))
    {
        if (startPort > endPort)
        {
            MessageBox.Show("起始端口不可大于结束端口");
        }

        if (IPAddress.TryParse(ipStr, out var ip))
        {
            // 防止重复点击
            scanBtn.Enabled = false;
            resultBox.Text = "扫描中..";
            // 开始端口扫描
            var helper = new ScannerHelper(ip, startPort, endPort);

            // 使用Task.Run来异步执行ScanPortsTask方法
            var ports = await Task.Run(() => helper.ScanPortsTask());

            if (ports.Count > 0)
            {
                var content = string.Join(Environment.NewLine, ports);
                resultBox.Text = "开放的端口" + Environment.NewLine + content;
            }
            else
            {
                resultBox.Text = "扫描结束，没有开放的端口";
            }
            // 结束后复原按钮状态
            scanBtn.Enabled = true;
        }
        else
        {
            MessageBox.Show("ip地址不合法");
        }
    }
    else
    {
        MessageBox.Show("端口必须为数字");
    }
}
```

我们运行下程序，看下效果，这样我们就完成了一个带UI界面的小工具，接下来我们尝试将它打包成可安装的应用。

> [!TIP]
> 以上代码使用`await Task.Run(() => helper.ScanPortsTask());`来异步执行扫描任务，这样可以避免UI线程被阻塞。否则在运行的时候，会出现 应用`假死`的现象。

## 发布程序

使用`VS`可以非常方便的发布程序，具体操作如下:

1. 右键项目，选择发布
2. 在弹窗中选择文件夹，下一步，选择ClickOnce发布
3. 选择要发布的路径，点击完成
4. 点击发布

## 安装程序

在目录中查看打包发布后的应用，我们会看到一个`setup.exe`文件，双击运行即可安装，这样该程序就作为一个应用安装到你的计算机了。

你可以在开始菜单中找到它，然后卸载它。

## 总结

WinForm是非常传统，甚至是有些古老的技术了。它提供了极其方便的方式(拖拽控件)来开发桌面应用，对于一些简单的工具，没有太多界面的要求，WinForm是一个非常好的选择。

虽然当前在开发Window程序中，WinForm已不再是默认选项，但.Net Core仍然为WinForm提供了支持。
