using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entities;

public class EventEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    [Column(TypeName = "datetime2")]
    public DateTime EventDate { get; set; }
    public string Description { get; set; } = null!;
    public string? Image { get; set; }
    public string Location { get; set; } = null!;
    public decimal StartPrice { get; set; }

    public ICollection<EventPackageEntity> Packages { get; set; } = [];
}


