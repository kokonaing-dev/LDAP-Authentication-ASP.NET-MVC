using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LDAP_Authentication_V2._0.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            var username = HttpContext.Session.GetString("User");
            ViewBag.Username = username;
            return View();
        }

    }
}
