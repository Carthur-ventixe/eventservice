using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

public class CreateEventModel
{
    public string Title { get; set; } = null!;
    public DateTime EventDate { get; set; }
    public string Description { get; set; } = null!;
    public string? Image { get; set; }
    public string Location { get; set; } = null!;
    public decimal StartPrice { get; set; }
    public List<EventPackageModel> EventPackages { get; set; } = [];
}
