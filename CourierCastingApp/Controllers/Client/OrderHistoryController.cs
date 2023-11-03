using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
    public class OrderHistoryController : Controller
    {

        public OrderHistoryController()
        { }
        public IActionResult Index()
        {
            return View();
        }
    }
}
