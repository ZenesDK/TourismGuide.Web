#nullable enable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismGuide.Web.Data;
using TourismGuide.Web.Models;

namespace TourismGuide.Web.Controllers;

public class AttractionsController : Controller
{
    private readonly ApplicationDbContext _context;

    public AttractionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var attraction = await _context.Attractions
            .Include(a => a.City)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (attraction == null)
        {
            return NotFound();
        }

        return View(attraction);
    }

    public async Task<IActionResult> Index(string searchString)
    {
        var attractions = from a in _context.Attractions
                        .Include(a => a.City)
                        select a;

        if (!string.IsNullOrEmpty(searchString))
        {
            attractions = attractions.Where(a => a.Name.Contains(searchString));
        }

        ViewData["CurrentFilter"] = searchString;
        return View(await attractions.ToListAsync());
    }
}