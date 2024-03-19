using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;
using Share.Models.UserDtos;

namespace API.Test;

public class BaseTest : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly IServiceProvider Services;
    protected readonly HttpClient _client;

    public BaseTest(WebApplicationFactory<Program> factory)
    {
        factory = factory.WithWebHostBuilder(builder =>
          {
              builder.ConfigureServices(services =>
              {
                  // 自定义服务集合
              });
              builder.UseEnvironment("Development");
          });

        Services = factory.Services.CreateScope().ServiceProvider;
        _client = factory.CreateClient();
        _client.BaseAddress = new Uri("http://localhost:5002");

        var token = GetTokenAsync().Result;

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    protected async Task<string> GetTokenAsync()
    {
        var loginDto = new LoginDto { UserName = "TestUser", Password = "Hello.Net" };
        var res = await _client.PutAsJsonAsync("/api/user/login", loginDto);

        Assert.True(res.IsSuccessStatusCode);
        var data = await res.Content.ReadFromJsonAsync<LoginResult>();

        Assert.NotNull(data);
        return data.Token;
    }

}
