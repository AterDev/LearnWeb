using Ater.Web.Core.Models;

using Microsoft.AspNetCore.Mvc.Testing;

using Share.Models.SubjectDtos;

namespace API.Test;

public class SubjectTest : BaseTest
{
    public SubjectTest(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetSubjectListAsync()
    {
        var requestData = new SubjectFilterDto
        {
            PageIndex = 1,
            PageSize = 10
        };

        var res = await _client.PostAsJsonAsync("/api/subject/filter", requestData);
        Assert.True(res.IsSuccessStatusCode);

        var data = await res.Content.ReadFromJsonAsync<PageList<SubjectItemDto>>();

        Assert.NotNull(data);
    }

}
