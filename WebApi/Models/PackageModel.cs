using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

public class PackageModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Position { get; set; }
    public string? Placement { get; set; }
    public decimal Price { get; set; }
    public int PackageId { get; set; }
}
