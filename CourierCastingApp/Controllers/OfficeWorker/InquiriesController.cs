using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class InquiriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
