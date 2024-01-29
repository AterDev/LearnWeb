using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace EFCore.Entity;

/// <summary>
/// 用户实体
/// </summary>
[Index(nameof(Name))]
public class User
{
    public Guid Id { get; set; }
    [Length(2, 40)]
    [MaxLength(40)]
    public required string Name { get; set; }

    public ICollection<Blog> Blogs { get; set; } = [];
}
