using System.ComponentModel.DataAnnotations;

namespace EFCore.Models;

public class BlogAddDto
{
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
}
