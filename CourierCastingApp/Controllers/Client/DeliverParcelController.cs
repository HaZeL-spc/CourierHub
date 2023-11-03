using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
    public class DeliverParcelController : BaseController
    {
        public DeliverParcelController(ICourierCastingAppRepository courierRepository) : base(courierRepository)
        { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
