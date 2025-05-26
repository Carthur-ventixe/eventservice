using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entities;

public class EventPackageEntity
{
    [Key]
    public int Id { get; set; }
    public int EventId { get; set; }
    public EventEntity Event { get; set; } = null!;
    public int PackageId { get; set; }
    public PackageEntity Package { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
}
