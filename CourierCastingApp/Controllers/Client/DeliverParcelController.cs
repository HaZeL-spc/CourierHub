using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
    public class DeliverParcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
