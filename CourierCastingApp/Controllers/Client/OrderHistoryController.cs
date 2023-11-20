using CourierCastingApp.Services;
using CourierCastingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
    public class OrderHistoryController : Controller
    {
        private IDeliveryRepository _deliveryRepository;
        public OrderHistoryController(IDeliveryRepository deliveryRepository)
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
