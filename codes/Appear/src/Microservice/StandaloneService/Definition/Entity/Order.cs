
using System.ComponentModel.DataAnnotations;

namespace StandaloneService.Definition.Entity;

public class Order : IEntityBase
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }

    [Length(5, 20)]
    public required string Number { get; set; }
}
