using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class OfferRequestsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
