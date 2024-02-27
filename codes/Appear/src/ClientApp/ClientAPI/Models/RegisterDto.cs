namespace ClientAPI.Models;
/// <summary>
/// 用户注册
/// </summary>
public class RegisterDto {
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = default!;
    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// 验证码
    /// </summary>
    public string? VerifyCode { get; set; }
    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; } = default!;

}
