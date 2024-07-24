namespace CsharpAdvance;
public class NullableExample
{
    public class Model
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        public string GetName()
        {
            return Name ?? string.Empty;
        }
        public void SetName(string newName)
        {
            Name ??= newName;
        }
    }

    public class Person
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName, string? middleName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName ?? string.Empty;
        }
        //public Person()
        //{
        //}
    }
    class Student : Person
    {
        public int ID { get; }
        public Student(int id, string firstName, string lastName, string? middleName = null)
            : base(firstName, lastName, middleName)
        {
            ID = id;
        }
    }

    public class PersonRequired
    {
        public required string FirstName { get; init; }
        public string MiddleName { get; init; } = string.Empty;
        public required string LastName { get; init; }
        //public PersonRequired(string firstName)
        //{
        //    FirstName = firstName;
        //}
    }
    public class StudentRequired : PersonRequired
    {
        //public StudentRequired(string firstName) : base(firstName)
        //{
        //}
        public required int ID { get; init; }
    }

    public static void Test()
    {
        var student = new Student(1, "张", "三");
        var studentRequired = new StudentRequired()
        {
            FirstName = "张",
            LastName = "三",
            ID = 1
        };

        //var s = new Person();
        //Console.WriteLine(s.FirstName == null);
    }
}

