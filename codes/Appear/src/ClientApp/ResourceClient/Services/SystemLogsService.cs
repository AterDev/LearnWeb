using ResourceClient.Models;
namespace ResourceClient.Services;
/// <summary>
/// 系统日志
/// </summary>
public class SystemLogsService : BaseService
{
    public SystemLogsService(HttpClient httpClient) : base(httpClient)
    {

    }
    /// <summary>
    /// Operation Log Query
    /// </summary>
    /// <param name="data">SystemLogsFilterDto</param>
    /// <returns></returns>
    public async Task<PageList<SystemLogsItemDto>?> FilterAsync(SystemLogsFilterDto data) {
        var url = $"/api/SystemLogs/filter";
        return await PostJsonAsync<PageList<SystemLogsItemDto>?>(url, data);
    }

}