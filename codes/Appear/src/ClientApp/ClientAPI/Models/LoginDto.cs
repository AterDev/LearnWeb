namespace ClientAPI.Models;
/// <summary>
/// 登录
/// </summary>
public class LoginDto {
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    /// <summary>
    /// 验证码
    /// </summary>
    public string? VerifyCode { get; set; }

}
