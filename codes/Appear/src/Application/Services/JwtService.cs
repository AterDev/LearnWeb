using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class JwtService(string sign, string audience, string issuer)
{
    /// <summary>
    /// 过期时间，分
    /// </summary>
    public int TokenExpires { get; set; }
    public int RefreshTokenExpires { get; set; }
    public string Sign { get; set; } = sign;
    public string Audience { get; set; } = audience;
    public string Issuer { get; set; } = issuer;
    public List<Claim>? Claims { get; set; }

    /// <summary>
    /// 生成jwt token
    /// </summary>
    /// <param name="id"></param>
    /// <param name="roles">角色</param>
    /// <returns></returns>
    public string GetToken(string id, string[] roles)
    {
        SymmetricSecurityKey signingKey = new(Encoding.UTF8.GetBytes(Sign));
        SigningCredentials signingCredentials = new(signingKey, SecurityAlgorithms.HmacSha256);
        List<Claim> claims = [new Claim(ClaimTypes.NameIdentifier, id)];
        if (roles.Length != 0)
        {
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
        }
        if (Claims != null && Claims.Count != 0)
        {
            claims.AddRange(Claims);
        }
        JwtSecurityToken jwt = new(Issuer, Audience, claims,
            expires: DateTime.UtcNow.AddMinutes(TokenExpires),
            signingCredentials: signingCredentials);
        string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
}
