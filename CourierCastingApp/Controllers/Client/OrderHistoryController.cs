using CourierCastingApp.Services;
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
                return View(result.Value);
            else
                return NotFound();
        }
    }
}
