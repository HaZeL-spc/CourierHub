using CourierCastingApp.Services;
using CourierCastingApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class DeliveriesController : Controller
    {
        private IDeliveryRepository _deliveryRepository;
        public DeliveriesController(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _deliveryRepository.GetAllDeliveries();
            if (result.Success)
                return View(result.Value);
            else
                return NotFound();
        }
    }
}
