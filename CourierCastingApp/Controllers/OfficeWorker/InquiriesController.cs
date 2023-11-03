using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class InquiriesController : BaseController
    {
        public InquiriesController(ICourierCastingAppRepository courierRepository) : base(courierRepository)
        { }
        public IActionResult Index()
        {
            return View();
        }
    }
}
