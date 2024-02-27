namespace ClientAPI.Services;
/// <summary>
/// 投票记录
/// </summary>
public class VoteRecordService(IHttpClientFactory httpClient) : BaseService(httpClient)
{
    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="data">VoteRecordFilterDto</param>
    /// <returns></returns>
    public async Task<VoteRecordItemDtoPageList?> FilterAsync(VoteRecordFilterDto data)
    {
        var url = $"/api/VoteRecord/filter";
        return await PostJsonAsync<VoteRecordItemDtoPageList?>(url, data);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="data">VoteRecordAddDto</param>
    /// <returns></returns>
    public async Task<VoteRecord?> AddAsync(VoteRecordAddDto data)
    {
        var url = $"/api/VoteRecord";
        return await PostJsonAsync<VoteRecord?>(url, data);
    }

    /// <summary>
    /// 部分更新
    /// </summary>
    /// <param name="id"> </param>
    /// <param name="data">VoteRecordUpdateDto</param>
    /// <returns></returns>
    public async Task<VoteRecord?> UpdateAsync(Guid id, VoteRecordUpdateDto data)
    {
        var url = $"/api/VoteRecord/{id}";
        return await PatchJsonAsync<VoteRecord>(url, data);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"> </param>
    /// <returns></returns>
    public async Task<VoteRecord?> GetDetailAsync(Guid id)
    {
        var url = $"/api/VoteRecord/{id}";
        return await GetJsonAsync<VoteRecord?>(url);
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"> </param>
    /// <returns></returns>
    public async Task<VoteRecord?> DeleteAsync(Guid id)
    {
        var url = $"/api/VoteRecord/{id}";
        return await DeleteJsonAsync<VoteRecord?>(url);
    }

}