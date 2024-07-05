using System.Text;

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
            File.WriteAllText(Path.Combine(RootPath, fileName), content, Encoding.UTF8);
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
