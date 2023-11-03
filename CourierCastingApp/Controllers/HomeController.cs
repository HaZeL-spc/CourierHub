using CourierCastingApp.Models;
using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CourierCastingApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICourierCastingAppRepository courierRepository):base(courierRepository)
        {
            _logger = logger;
        } 

        public async Task<ActionResult> Index()
        {
            var result = await _courierRepository.CountAllSessions();
            if (result.Success)
            {
                return View(result.Value);
            }
            

            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}