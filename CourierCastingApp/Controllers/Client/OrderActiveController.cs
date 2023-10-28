using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
    public class OrderActiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
