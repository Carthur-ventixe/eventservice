using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

public class EventModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime EventDate { get; set; }
    public string Description { get; set; } = null!;
    public string? Image { get; set; }
    public string Location { get; set; } = null!;
    public decimal StartPrice { get; set; }
    public IEnumerable<PackageModel> Packages { get; set; } = [];
}
