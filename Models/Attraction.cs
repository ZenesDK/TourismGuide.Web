#nullable enable
using System.ComponentModel.DataAnnotations;

namespace TourismGuide.Web.Models;

public class Attraction
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
    
    public int CityId { get; set; }
    public City? City { get; set; }
    
    [Required]
    public string History { get; set; } = string.Empty;
    
    public string? PhotoImageFileName { get; set; }
    
    [StringLength(100)]
    public string? OpeningHours { get; set; }
    
    public decimal? TicketPrice { get; set; }
}