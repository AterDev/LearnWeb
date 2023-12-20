using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI;


[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool Login(string username, string password)
    {
        // TODO:业务逻辑实现
        Console.WriteLine(username + password);
        return true;
    }

    [HttpPost("password")]
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool ChangePassword(string password)
    {
        // TODO:业务逻辑实现
        Console.WriteLine(password);
        return true;
    }
}
