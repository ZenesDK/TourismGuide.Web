#nullable enable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismGuide.Web.Data;
using TourismGuide.Web.Models;

namespace TourismGuide.Web.Controllers;

public class CitiesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string searchString)
    {
        var cities = from c in _context.Cities select c;

        if (!string.IsNullOrEmpty(searchString))
        {
            cities = cities.Where(c => c.Name.Contains(searchString));
        }

        return View(await cities.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var city = await _context.Cities
            .Include(c => c.Attractions)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }
}