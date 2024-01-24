using Blazored.LocalStorage;

namespace Vote.Services;

public class UserStateService
{
    public Guid UserId { get; set; }

    public string? UserName { get; set; }

    public bool IsLogin { get; set; }

    private readonly ILocalStorageService _storageService;

    public UserStateService(ILocalStorageService storageService)
    {
        _storageService = storageService;
        GetUserStateAsync().Wait();
    }

    public void SetUserState(Guid userId, string username)
    {
        IsLogin = true;
        UserId = userId;
        UserName = username;

        _storageService.SetItemAsync("UserId", UserId);
        _storageService.SetItemAsync("UserName", UserName);
    }

    public async Task GetUserStateAsync()
    {
        var username = await _storageService.GetItemAsStringAsync("UserName");
        var userId = await _storageService.GetItemAsync<Guid>("UserId");

        if (userId != Guid.Empty && !string.IsNullOrWhiteSpace(username))
        {
            UserId = userId;
            UserName = username;
            IsLogin = true;
        }
    }
}
