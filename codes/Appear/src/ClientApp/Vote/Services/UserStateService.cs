using Blazored.LocalStorage;

namespace Vote.Services;

public class UserStateService
{
    public Guid UserId { get; set; }

    public string? UserName { get; set; }

    public bool IsLogin { get; set; }

    private readonly ISyncLocalStorageService _storageService;

    public UserStateService(ISyncLocalStorageService storageService)
    {
        _storageService = storageService;
        GetUserState();
    }

    public void SetUserState(Guid userId, string username)
    {
        IsLogin = true;
        UserId = userId;
        UserName = username;

        _storageService.SetItem<Guid>("UserId", UserId);
        _storageService.SetItem("UserName", UserName);
    }

    public void GetUserState()
    {
        var username = _storageService.GetItemAsString("UserName");
        var userId = _storageService.GetItem<Guid>("UserId");

        if (userId != Guid.Empty && !string.IsNullOrWhiteSpace(username))
        {
            UserId = userId;
            UserName = username;
            IsLogin = true;
        }
    }

    public void ClearUserStateAsync()
    {
        _storageService.Clear();
    }
}
