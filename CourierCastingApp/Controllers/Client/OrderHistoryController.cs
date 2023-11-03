using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
    public class OrderHistoryController : BaseController
    {

        public OrderHistoryController(ICourierCastingAppRepository courierRepository) : base(courierRepository)
        { }
        public IActionResult Index()
        {
            return View();
        }
    }
}
