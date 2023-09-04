using System.Diagnostics;
using ASP_NET_HW_12.Data;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_HW_12.Models;

namespace ASP_NET_HW_12.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context,
            IDataContextInitializer initializer) {
            _logger = logger;
            _context = context;

            initializer.Initialize();
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}