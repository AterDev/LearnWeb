using System.Text.Json.Serialization;

namespace SystemMod.Models.SystemMenuDtos;
public class SystemMenuSyncDto
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("accessCode")]
    public required string AccessCode { get; set; }
    [JsonPropertyName("menuType")]
    public int MenuType { get; set; } = 0;
    [JsonPropertyName("parentId")]
    public Guid? ParentId { get; set; }
    [JsonPropertyName("children")]
    public List<SystemMenuSyncDto> Children { get; set; } = [];
}
