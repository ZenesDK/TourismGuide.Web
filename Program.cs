using TourismGuide.Web.Models; // <-- Добавить эту строку
using Microsoft.EntityFrameworkCore;
using TourismGuide.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cities}/{action=Index}/{id?}");

// --- Пример использования моделей ---
// Пример добавления тестовых данных
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!context.Cities.Any())
    {
        context.Cities.AddRange(new[]
        {
            new City
            {
                Name = "Москва",
                Region = "Центральный федеральный округ",
                Population = 13_000_000,
                History = "Столица России с 1918 года.",
                PhotoImageFileName = "moscow.jpg"
            },
            new City
            {
                Name = "Санкт-Петербург",
                Region = "Северо-Западный федеральный округ",
                Population = 5_600_000,
                History = "Основан Петром I в 1703 году.",
                PhotoImageFileName = "spb.jpg"
            }
        });
        context.SaveChanges();
    }
}

app.Run();