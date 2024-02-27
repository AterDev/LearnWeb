using ClientAPI.Models;
namespace ClientAPI.Services;
/// <summary>
/// 主题
/// </summary>
public class SubjectService(IHttpClientFactory httpClient) : BaseService(httpClient)
{
    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="data">SubjectFilterDto</param>
    /// <returns></returns>
    public async Task<SubjectItemDtoPageList?> FilterAsync(SubjectFilterDto data) {
        var url = $"/api/Subject/filter";
        return await PostJsonAsync<SubjectItemDtoPageList?>(url, data);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"> </param>
    /// <returns></returns>
    public async Task<Subject?> GetDetailAsync(Guid id) {
        var url = $"/api/Subject/{id}";
        return await GetJsonAsync<Subject?>(url);
    }

}