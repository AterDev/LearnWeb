using Entity;
using Microsoft.AspNetCore.Mvc.Testing;

namespace API.Test;

public class UserTest : BaseTest
{
    public UserTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    // get user detail
    [Fact]
    public async Task GetDetailAsync()
    {
        var res = await _client.GetAsync("/api/user");
        Assert.True(res.IsSuccessStatusCode);
        var data = await res.Content.ReadFromJsonAsync<User>();
        Assert.NotNull(data);
    }

}
