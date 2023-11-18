using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
    public class OrderHistoryController : Controller
    {
        private IDeliveryRepository _deliveryRepository;
        private IDeliveryConverter _converter;
        public OrderHistoryController(IDeliveryRepository deliveryRepository, IDeliveryConverter converter)
        {
            _converter = converter;
            _deliveryRepository = deliveryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _deliveryRepository.GetAllDeliveries();
            if (result.Success)
            {
                var deliveries = _converter.DtoToVmList(result.Value);
                return View(deliveries);
            }
            else
                return NotFound();
        }
    }
}
