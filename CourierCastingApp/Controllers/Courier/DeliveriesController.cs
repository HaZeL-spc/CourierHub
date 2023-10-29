using CourierCastingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class DeliveriesController : Controller
    {
        public IActionResult Index()
        {
            return View(new DeliveriesModel());
        }
    }
}
