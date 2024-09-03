#region 类的成员
//var person = new Person("张三")
//{
//    Birthday = new DateTimeOffset(1990, 1, 1, 0, 0, 0, TimeSpan.Zero)
//};


//Console.WriteLine($"姓名:{person.Name},年龄:{person.Age}");
//// Console.WriteLine("生日:"+ person.Birthday); // 无法访问
//// person.Name = "123";     // 无法访问
//// person.Birthday = DateTimeOffset.Now; // 无法访问

//person.ChangeName("李四");
//Console.WriteLine($"姓名:{person.Name},年龄:{person.Age}");

#endregion

#region StringExample

//StringExample.NormalString();
//StringExample.EscapingString();
//StringExample.InterpolationString();
//StringExample.RawString();

#endregion

#region 空值处理

//NullableExample.Model model = null;
//var name = model?.Name ?? "未知";
//Console.WriteLine(name);

//NullableExample.Test();

#endregion

#region 集合表达式

//GenericCollection.DictionaryExample();
//GenericCollection.InlineExample();

#endregion

#region 类型别名

//TypeAlias.Test();
//任意类型别名.演示输出();

#endregion

#region 预处理指令

#endregion

#region 特性

//var attr = new AttributeExample { Name = "特性" };
//attr.SetNewName("新特性名称");

#endregion

#region XML注释

//Parse.ParseXml("");

#endregion

#region 分部类和方法

//var partial = new PartialClass(10, 20);

//Console.WriteLine($"周长为{partial.Length}");
//Console.WriteLine($"面积为{partial.Area}");
#endregion

#region 扩展方法
Console.WriteLine(string.IsNullOrEmpty("   ")); // false
Console.WriteLine(string.IsNullOrWhiteSpace("   ")); // true


string? str = null;

if (!string.IsNullOrWhiteSpace(str))
{
    Console.WriteLine(str.Length);
}

if (str.IsNotEmpty())
{
    Console.WriteLine(str.ToLower());
}
#endregion




