using EFCore.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(BlogContext context) : ControllerBase
{
    private readonly BlogContext _context = context;

    // 用户的添加
    [HttpPost]
    public IActionResult AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok();
    }

    // 用户列表的查询
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    // 博客的添加
    [HttpPost("blogs")]
    public IActionResult AddBlog(Blog blog)
    {
        _context.Blogs.Add(blog);
        _context.SaveChanges();
        return Ok();
    }

    // 博客的修改
    [HttpPut("blogs/{id}")]
    public IActionResult UpdateBlog(Guid id, Blog updatedBlog)
    {
        var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
        if (blog == null)
        {
            return NotFound();
        }

        blog.Title = updatedBlog.Title;
        blog.Content = updatedBlog.Content;
        _context.SaveChanges();
        return Ok();
    }

    // 博客的删除
    [HttpDelete("blogs/{id}")]
    public IActionResult DeleteBlog(Guid id)
    {
        var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
        if (blog == null)
        {
            return NotFound();
        }

        _context.Blogs.Remove(blog);
        _context.SaveChanges();
        return Ok();
    }

    // 博客标签的修改
    [HttpPut("blogs/{id}/tags")]
    public IActionResult UpdateBlogTags(Guid id, List<string> tags)
    {
        var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
        if (blog == null)
        {
            return NotFound();
        }

        blog.Tags = tags;
        _context.SaveChanges();
        return Ok();
    }
}
