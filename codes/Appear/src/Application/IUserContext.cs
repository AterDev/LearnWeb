namespace Application;
public interface IUserContext : IUserContextBase
{
    Claim? FindClaim(string claimType);
    Task<User?> GetUserAsync();
}
