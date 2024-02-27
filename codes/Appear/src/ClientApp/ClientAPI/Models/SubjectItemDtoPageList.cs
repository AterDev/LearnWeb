namespace ClientAPI.Models;
public class SubjectItemDtoPageList {
    public int Count { get; set; } = default!;
    public List<SubjectItemDto> Data { get; set; }
    public int PageIndex { get; set; } = default!;

}
