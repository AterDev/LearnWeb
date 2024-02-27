namespace ClientAPI.Models;
public class LoginResult {
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; set; } = default!;
    public List<string> Roles { get; set; } = default!;
    /// <summary>
    /// token
    /// </summary>
    public string Token { get; set; } = default!;

}
