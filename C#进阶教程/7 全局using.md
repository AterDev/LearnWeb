# 全局 using 指令

C#10中添加了`global using`指令，可以在整个项目中引入命名空间，而不需要在每个文件中都添加using指令。

## 问题

当我们使用类库或其他命名空间的类时，我们通常会使用`using`引用命名空间，我们经常会看到每个类文件的开头有很多`using`引用。

当我们进行代码重构时，比如修改目录结构和命名空间时，我们可以直接修改`global using`指令，而不需要修改每个文件。

## 解决方案

现在我们创建新项目时，默认就已经添加了全局 using 指令，我们可以在项目属性中查看。

![全局 using 指令](../images/csharpAdvance//globalusing1.png)

默认项目，已经全局引用了常用的命名空间，结合`顶级语句`，现在当我们创建项目时，模板代码可以只有一行：

```csharp
Console.WriteLine("Hello World!");
```

而以前的默认`Program.cs`中的代码大概如下:

```csharp
using System;
namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

当我们需要添加额外的全局引用时，可以在根目录中添加一个`.cs`文件，名称随意，在其中添加全局using指令，如创建`GlobalUsing.cs`文件，内容如下:

```Csharp
global using CsharpAdvance.Models;
```

这样，任何文件使用`CsharpAdvance.Models`命名空间的类时，都不需要再添加`using`指令。

## 总结

全局引用(global using)

- 减少重复的引用，即减少了代码行数，也减少了开发负担。
- 更方便代码重构