using Microsoft.AspNetCore.Mvc;

namespace TourismGuide.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Изменено: Заголовок для главной страницы
            ViewData["Title"] = "Главная";
            return View();
        }

        public IActionResult Privacy()
        {
            // Изменено: Заголовок для страницы конфиденциальности
            ViewData["Title"] = "Конфиденциальность";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}