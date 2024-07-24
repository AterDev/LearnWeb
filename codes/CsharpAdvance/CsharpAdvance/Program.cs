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

#region NullableExample
using CsharpAdvance;

NullableExample.Model model = null;
var name = model?.Name ?? "未知";
Console.WriteLine(name);

NullableExample.Test();

#endregion