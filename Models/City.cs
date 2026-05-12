#nullable enable
using System.ComponentModel.DataAnnotations;

namespace TourismGuide.Web.Models;

public class City
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string Region { get; set; } = string.Empty;
    
    public int Population { get; set; }
    
    [Required]
    public string History { get; set; } = string.Empty;
    
    public string? CoatOfArmsImageFileName { get; set; }
    
    public string? PhotoImageFileName { get; set; }
    
    public List<Attraction> Attractions { get; set; } = new();
}