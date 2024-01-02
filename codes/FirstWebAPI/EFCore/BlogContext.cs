using EFCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCore;

public class BlogContext(DbContextOptions<BlogContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Blog> Blogs { get; set; }

}
