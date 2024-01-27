using Models.VoteRecordItemDto';
namespace Models.ResourceClient.VoteRecord
public class VoteRecordItemDtoPageList {
    public int Count { get; set; }
    public List<VoteRecordItemDto> Data { get; set; }
    public int PageIndex { get; set; }

}
