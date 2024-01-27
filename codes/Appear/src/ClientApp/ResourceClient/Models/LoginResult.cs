namespace Models.ResourceClient.User
public class LoginResult {
    public string Id { get; set; }
    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; set; }
    public List<string> Roles { get; set; }
    /// <summary>
    /// token
    /// </summary>
    public string Token { get; set; }

}
