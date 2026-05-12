#nullable enable
using Microsoft.EntityFrameworkCore;
using TourismGuide.Web.Models;

namespace TourismGuide.Web.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Attraction> Attractions { get; set; }
}