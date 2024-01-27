using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace EFCore.Entity;

/// <summary>
/// 博客实体
/// </summary>
[Index(nameof(Title))]
public class Blog
{
    public Guid Id { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    [Length(1, 30)]
    [MaxLength(100)]
    public required string Title { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(200)]
    public string? Description { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [MaxLength(2000)]
    public required string Content { get; set; }
    /// <summary>
    /// 标签
    /// </summary>
    public List<string>? Tags { get; set; }

    public required Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
}
