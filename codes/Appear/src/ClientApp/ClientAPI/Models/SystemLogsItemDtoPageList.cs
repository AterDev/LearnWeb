namespace ClientAPI.Models;
public class SystemLogsItemDtoPageList {
    public int Count { get; set; } = default!;
    public List<SystemLogsItemDto> Data { get; set; }
    public int PageIndex { get; set; } = default!;

}
