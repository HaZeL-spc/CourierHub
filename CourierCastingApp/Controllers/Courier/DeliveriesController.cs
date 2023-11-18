using CourierCastingApp.Services;
using CourierCastingApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class DeliveriesController : Controller
    {
        private IDeliveryRepository _deliveryRepository;
        private IDeliveryConverter _deliveryConverter;
        public DeliveriesController(IDeliveryRepository deliveryRepository, IDeliveryConverter converter)
        {
            _deliveryConverter = converter;
            _deliveryRepository = deliveryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _deliveryRepository.GetAllDeliveries();
            if (result.Success)
            {
                var deliveries = _deliveryConverter.DtoToVmList(result.Value);

                return View(deliveries);
            }
            
            else
                return NotFound();
        }
    }
}
