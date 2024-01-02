using System.ComponentModel.DataAnnotations;

namespace EFCore.Entity;

/// <summary>
/// 用户实体
/// </summary>
public class User
{
    public Guid Id { get; set; }
    [Length(2, 40)]
    public required string Name { get; set; }

    public ICollection<Blog> Blogs { get; set; } = [];

}
