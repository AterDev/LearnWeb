using ResourceClient.Services;
namespace ResourceClient;

public class ClientClient
{
    public string? AccessToken { get; set; }
    private readonly HttpClient Http;
    public JsonSerializerOptions JsonSerializerOptions { get; set; }
    public ErrorResult? ErrorMsg { get; set; } = null;

    #region api services
    public SubjectService Subject { get; init; }
    public SystemLogsService SystemLogs { get; init; }
    public UserService User { get; init; }
    public VoteRecordService VoteRecord { get; init; }

    #endregion

    public ClientClient(HttpClient http)
    {
        Http = http;
        JsonSerializerOptions = new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        #region api services
        Subject = new SubjectService(http);
        SystemLogs = new SystemLogsService(http);
        User = new UserService(http);
        VoteRecord = new VoteRecordService(http);

        #endregion
    }

    public void SetToken(string token)
    {
        Http.DefaultRequestHeaders.Clear();
        Http.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
    }
}

public class ErrorResult
{
    public string? Title { get; set; }
    public string? Detail { get; set; }
    public int Status { get; set; } = 500;
    public string? TraceId { get; set; }
}
