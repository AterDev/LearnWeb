using System.ComponentModel.DataAnnotations;

namespace EFCore.Entity;

/// <summary>
/// 博客实体
/// </summary>
public class Blog
{
    public Guid Id { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    [Length(1, 30)]
    public required string Title { get; set; }
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
    public User User { get; set; } = null!;
}
