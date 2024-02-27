namespace ClientAPI.Models;
/// <summary>
/// 用户账户更新时请求结构
/// </summary>
public class UserUpdateDto {
    public UserType UserType { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    public string? Avatar { get; set; }

}
