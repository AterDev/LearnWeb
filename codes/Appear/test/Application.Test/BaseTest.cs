using Microsoft.AspNetCore.Mvc.Testing;

namespace Application.Test;

public class BaseTest : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly IServiceProvider Services;
    public BaseTest(WebApplicationFactory<Program> factory)
    {
        factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // 自定义服务集合
            });
            builder.UseEnvironment("Test");
        });
        Services = factory.Services.CreateScope().ServiceProvider;
    }
}
