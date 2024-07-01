using System.Net.Http.Json;

public class HttpHelper
{
    public HttpClient HttpClient { get; init; }
    public HttpHelper(string baseAddress)
    {

        HttpClient = new HttpClient()
        {
            BaseAddress = new Uri(baseAddress),
            Timeout = TimeSpan.FromSeconds(10)
        };
    }

    public async Task GetTest()
    {
        try
        {
            var response = await HttpClient.GetAsync("/api/test");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("请求成功");
            }
            else
            {
                Console.WriteLine("请求失败");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
        }
    }

    public async Task PostTest()
    {
        try
        {
            var data = new { Name = "Chris", Age = 18 };
            var response = await HttpClient.PostAsJsonAsync("/api/test",data);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("请求成功");
            }
            else
            {
                Console.WriteLine("请求失败");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex);
        }
    }
}