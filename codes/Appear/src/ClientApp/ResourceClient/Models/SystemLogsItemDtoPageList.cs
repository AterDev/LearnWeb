using Models.SystemLogsItemDto';
namespace Models.ResourceClient.SystemLogs
public class SystemLogsItemDtoPageList {
    public int Count { get; set; }
    public List<SystemLogsItemDto> Data { get; set; }
    public int PageIndex { get; set; }

}
