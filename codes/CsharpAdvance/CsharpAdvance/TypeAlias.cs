namespace CsharpAdvance
{
    using Worker955 = SomeWhere.Worker;
    using Worker996 = GoodPlace.Worker;
    using WorkPeople = ThePeopleFromGoodPlace;

    /// <summary>
    /// 类型别名
    /// </summary>
    public class TypeAlias
    {
        public static void Test()
        {
            WorkPeople.Work();
            // 使用完整的命名空间来区分不同的Worker
            // var worker1 = new SomeWhere.Worker();
            // var worker2 = new GoodPlace.Worker();

            // 使用别名来区分不同的Worker
            var worker3 = new Worker996();
            var worker4 = new Worker955();

            worker3.WorkHours();
            worker4.WorkHours();
        }
    }

    public class ThePeopleFromGoodPlace
    {
        public static void Work()
        {
            Console.WriteLine("劳动最光荣，劳动到死");
        }
    }
}

namespace SomeWhere
{
    public class Worker
    {
        public int WorkDays { get; set; } = 5;
        public int DayHours { get; set; } = 7;

        public void WorkHours()
        {
            Console.WriteLine("一周工作{0}小时", WorkDays * DayHours);
        }
    }
}

namespace GoodPlace
{
    public class Worker
    {
        public int WorkDays { get; set; } = 6;
        public int DayHours { get; set; } = 12;

        public void WorkHours()
        {
            Console.WriteLine("一周工作{0}小时", WorkDays * DayHours);
        }
    }
}

namespace CsharpAdvance.AnyTypeAlias
{
    using 字符串 = string;
    using 整形 = int;
    using 点 = (int x, int y);

    public class 任意类型别名
    {
        public static void 演示输出()
        {
            整形 整数a = 10;
            字符串 标题 = "这是一个标题";
            点 点 = (10, 20);

            输出(整数a.ToString());
            输出(标题);
            输出($"{点.x},{点.y}");
        }

        public static void 输出(字符串 msg)
        {
            Console.WriteLine(msg);
        }
    }
}

