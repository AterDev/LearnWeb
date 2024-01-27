using EFCore.Entity;
using EFCore.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(BlogContext context) : ControllerBase
{
    private readonly BlogContext _context = context;

    // 用户的添加
    [HttpPost]
    public async Task<ActionResult<User>> AddUserAsync(string userName)
    {
        var exist = await _context.Users.AnyAsync(u => u.Name == userName);
        if (exist)
        {
            return Conflict("用户名已经存在");
        }

        var user = new User
        {
            Name = userName,
            Id = Guid.NewGuid()
        };
        _context.Users.Add(user);

        await _context.SaveChangesAsync();
        return user;
    }

    // 用户列表的查询
    [HttpGet]
    public async Task<List<User>> GetUsersAsync(string? name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            return await _context.Users.Where(x => x.Name.Equals(name)).ToListAsync() ?? [];
        }

        return await _context.Users.ToListAsync() ?? [];
    }

    // 博客搜索
    [HttpGet("blogs/{userId}")]
    public async Task<List<Blog>> GetBlogsAsync(Guid userId, string? title, string? tag)
    {
        var query = _context.Blogs.Where(x => x.UserId == userId).AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(x => x.Title.Contains(title));
        }
        if (!string.IsNullOrWhiteSpace(tag))
        {
            query = query.Where(x => x.Tags != null && x.Tags.Contains(tag));
        }

        return await query.ToListAsync() ?? [];
    }

    // 博客的添加
    [HttpPost("blogs")]
    public async Task<ActionResult<Blog>> AddBlogAsync(BlogAddDto dto)
    {
        var exist = await _context.Users.AnyAsync(u => u.Id == dto.UserId);
        if (!exist)
        {
            return Problem("用户不存在");
        }

        var blog = new Blog
        {
            Title = dto.Title,
            Content = dto.Content,
            UserId = dto.UserId,
            Tags = dto.Tags,
            Id = Guid.NewGuid()
        };
        _context.Blogs.Add(blog);
        await _context.SaveChangesAsync();
        return blog;
    }

    // 博客的修改
    [HttpPut("blogs/{id}")]
    public async Task<ActionResult<Blog>> UpdateBlogAsync(Guid id, BlogUpdateDto dto)
    {
        var userId = Guid.NewGuid();
        var blog = await _context.Blogs.Where(b => b.UserId == userId && b.Id == id).FirstOrDefaultAsync();
        if (blog == null)
        {
            return NotFound();
        }

        if (dto.Title != null) { blog.Title = dto.Title; }
        if (dto.Content != null) { blog.Content = dto.Content; }
        if (dto.Tags != null) { blog.Tags = dto.Tags; }

        await _context.SaveChangesAsync();
        return blog;
    }

    // 博客的删除
    [HttpDelete("blogs/{id}")]
    public async Task<ActionResult<bool>> DeleteBlogAsync(Guid id)
    {
        // any 查询 是否存在
        var exist = await _context.Blogs.AnyAsync(b => b.Id == id);
        if (!exist)
        {
            return NotFound();
        }
        int res = await _context.Blogs.Where(x => x.Id == id).ExecuteDeleteAsync();
        return res > 0;
    }
}
