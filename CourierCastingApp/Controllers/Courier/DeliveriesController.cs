using CourierCastingApp.Services;
using CourierCastingApp.Filters;
using Microsoft.AspNetCore.Mvc;
using CourierCastingApp.ViewModels;

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
            {
                var deliveries = result.Value.Select(d => new DeliveryVm(d)).ToList();

                return View(deliveries);
            }
            
            else
                return NotFound();
        }
    }
}
