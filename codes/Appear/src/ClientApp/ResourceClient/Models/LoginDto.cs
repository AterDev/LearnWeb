namespace Models.ResourceClient.User
/// <summary>
/// 登录
/// </summary>
public class LoginDto {
    public string UserName { get; set; }
    public string Password { get; set; }
    /// <summary>
    /// 验证码
    /// </summary>
    public string? VerifyCode { get; set; }

}
