using System.ComponentModel.DataAnnotations;

namespace EFCore.Models;

public class BlogUpdateDto
{
    /// <summary>
    /// 标题
    /// </summary>
    [Length(1, 30)]
    public string? Title { get; set; }
    /// <summary>
    /// 内容
    /// </summary>
    [MaxLength(2000)]
    public string? Content { get; set; }
    /// <summary>
    /// 标签
    /// </summary>
    public List<string>? Tags { get; set; }
}
