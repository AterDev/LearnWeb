using Models.SubjectItemDto';
namespace Models.ResourceClient.Subject
public class SubjectItemDtoPageList {
    public int Count { get; set; }
    public List<SubjectItemDto> Data { get; set; }
    public int PageIndex { get; set; }

}
