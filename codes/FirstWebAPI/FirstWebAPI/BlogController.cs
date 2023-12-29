using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI;
[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    /// <summary>
    /// 从query中获取参数
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    [HttpGet]
    public List<Blog> GetList(int count)
    {
        // 查询前count 个数据
        Console.WriteLine(count);
        return [];
    }

    /// <summary>
    /// 从header中获取参数
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("page")]
    public List<Blog> GetList([FromHeader] int pageIndex, [FromHeader] int pageSize)
    {
        // 分页查询
        Console.WriteLine($"pageIndex:{pageIndex}, pageSize:{pageSize}");
        return [];
    }

    /// <summary>
    /// 从请求体中获取参数
    /// </summary>
    /// <param name="blog"></param>
    /// <returns></returns>
    [HttpPost]
    public Blog Add(Blog blog)
    {
        // 添加数据
        Console.WriteLine(blog);
        return blog;
    }

    /// <summary>
    /// 指定从请求体中获取参数
    /// </summary>
    /// <param name="id"></param>
    /// <param name="blog"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public ActionResult<Blog> Update(int id, [FromBody] Blog blog)
    {
        // 判断是否存在
        if (id != 1)
        {
            // 404
            return NotFound("未找到该博客");
        }
        try
        {

        }
        catch (Exception ex)
        {
            // 500
            return Problem($"异常错误{ex.Message}");
        }

        // TODO:执行更新逻辑成功
        return blog;
    }

    /// <summary>
    /// 指定从路由中获取参数
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public bool Delete([FromRoute] int id)
    {
        // 删除数据
        Console.WriteLine($"id:{id}");
        return true;
    }

    // download file
    [HttpGet("download")]
    public ActionResult Download()
    {
        var stream = System.IO.File.OpenRead("wwwroot/1.png");
        return File(stream, "image/png", "1.png");
    }

}


public record Blog
{
    [Display(Name = "博客标题")]
    [Length(2, 300, ErrorMessage = "{0}长度需要在{1}-{2}")]
    public required string Title { get; set; }
    public string? Description { get; set; }
    [MaxLength(1000)]
    public required string Content { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
}