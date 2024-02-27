namespace ClientAPI.Services;
/// <summary>
/// 用户账户
/// </summary>
public class UserService(IHttpClientFactory httpClient) : BaseService(httpClient)
{
    /// <summary>
    /// 用户注册 ✅
    /// </summary>
    /// <param name="data">RegisterDto</param>
    /// <returns></returns>
    public async Task<User?> RegisterAsync(RegisterDto data)
    {
        var url = $"/api/User";
        return await PostJsonAsync<User?>(url, data);
    }

    /// <summary>
    /// 更新信息：头像 ✅
    /// </summary>
    /// <param name="data">UserUpdateDto</param>
    /// <returns></returns>
    public async Task<User?> UpdateAsync(UserUpdateDto data)
    {
        var url = $"/api/User";
        return await PutJsonAsync<User?>(url, data);
    }

    /// <summary>
    /// 详情 ✅
    /// </summary>
    /// <returns></returns>
    public async Task<User?> GetDetailAsync()
    {
        var url = $"/api/User";
        return await GetJsonAsync<User?>(url);
    }

    /// <summary>
    /// 注册时，发送邮箱验证码 ✅
    /// </summary>
    /// <param name="email"> </param>
    /// <returns></returns>
    public async Task<object?> SendRegVerifyCodeAsync(string? email)
    {
        var url = $"/api/User/regVerifyCode?email={email}";
        return await PostJsonAsync<object?>(url);
    }

    /// <summary>
    /// 登录时，发送邮箱验证码 ✅
    /// </summary>
    /// <param name="email"> </param>
    /// <returns></returns>
    public async Task<object?> SendVerifyCodeAsync(string? email)
    {
        var url = $"/api/User/loginVerifyCode?email={email}";
        return await PostJsonAsync<object?>(url);
    }

    /// <summary>
    /// 登录获取Token ✅
    /// </summary>
    /// <param name="data">LoginDto</param>
    /// <returns></returns>
    public async Task<LoginResult?> LoginAsync(LoginDto data)
    {
        var url = $"/api/User/login";
        return await PutJsonAsync<LoginResult?>(url, data);
    }

    /// <summary>
    /// 退出 ✅
    /// </summary>
    /// <param name="id">Guid </param>
    /// <returns></returns>
    public async Task<bool?> LogoutAsync(Guid id)
    {
        var url = $"/api/User/logout/{id}";
        return await PutJsonAsync<bool?>(url);
    }

    /// <summary>
    /// 修改密码 ✅
    /// </summary>
    /// <param name="password">string </param>
    /// <param name="newPassword">string </param>
    /// <returns></returns>
    public async Task<bool?> ChangePasswordAsync(string? password, string? newPassword)
    {
        var url = $"/api/User/changePassword?password={password}&newPassword={newPassword}";
        return await PutJsonAsync<bool?>(url);
    }

}