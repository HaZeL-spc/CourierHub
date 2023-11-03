using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class OfferRequestsController : BaseController
    {
        public OfferRequestsController( ICourierCastingAppRepository courierRepository) : base(courierRepository)
        { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
