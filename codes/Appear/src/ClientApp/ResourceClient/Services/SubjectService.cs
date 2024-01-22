using ResourceClient.Models;
namespace ResourceClient.Services;
/// <summary>
/// 主题
/// </summary>
public class SubjectService : BaseService
{
    public SubjectService(HttpClient httpClient) : base(httpClient)
    {

    }
    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="data">SubjectFilterDto</param>
    /// <returns></returns>
    public async Task<PageList<SubjectItemDto>?> FilterAsync(SubjectFilterDto data) {
        var url = $"/api/Subject/filter";
        return await PostJsonAsync<PageList<SubjectItemDto>?>(url, data);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"> </param>
    /// <returns></returns>
    public async Task<Subject?> GetDetailAsync(string id) {
        var url = $"/api/Subject/{id}";
        return await GetJsonAsync<Subject?>(url);
    }

}