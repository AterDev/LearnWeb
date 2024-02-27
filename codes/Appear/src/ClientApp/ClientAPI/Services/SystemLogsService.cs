using ClientAPI.Models;
namespace ClientAPI.Services;
/// <summary>
/// 系统日志
/// </summary>
public class SystemLogsService(IHttpClientFactory httpClient) : BaseService(httpClient)
{
    /// <summary>
    /// Operation Log Query
    /// </summary>
    /// <param name="data">SystemLogsFilterDto</param>
    /// <returns></returns>
    public async Task<SystemLogsItemDtoPageList?> FilterAsync(SystemLogsFilterDto data) {
        var url = $"/api/SystemLogs/filter";
        return await PostJsonAsync<SystemLogsItemDtoPageList?>(url, data);
    }

}