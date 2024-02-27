namespace ClientAPI.Models;
public class VoteRecordItemDtoPageList {
    public int Count { get; set; } = default!;
    public List<VoteRecordItemDto> Data { get; set; }
    public int PageIndex { get; set; } = default!;

}
