using CourierCastingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers
{
    public class DeliverymanPanelController : Controller
    {
        public IActionResult Index()
        {
            return View(new DeliverymanPanel());
        }
    }
}
