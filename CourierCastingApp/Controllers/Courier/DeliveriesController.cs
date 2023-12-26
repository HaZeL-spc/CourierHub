using CourierCastingApp.Services;
using CourierCastingApp.Filters;
using Microsoft.AspNetCore.Mvc;
using CourierCastingApp.ViewModels;
using CourierCastingApp.DataTransferObjects;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class DeliveriesController : Controller
    {
        private IDeliveryRepository _deliveryRepository;
        private IDeliveryConverter _deliveryConverter;
        public DeliveriesController(IDeliveryRepository deliveryRepository, 
            IDeliveryConverter deliveryConverter)
        {
            _deliveryRepository = deliveryRepository;
            _deliveryConverter = deliveryConverter; 
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

        [HttpPost]
        public async Task<IActionResult> PickUpDelivery([FromBody] DeliveryVm d)
        {
            // make converter? i cannot use constructor cause vm and dto can depend on each other both ways

            DeliveryDto ddto = _deliveryConverter.VmToDto(d);

            var logicResult = await _deliveryRepository.PickUpDelivery(ddto);

            if (logicResult.Success)
            {
                return RedirectToAction("Index", "Deliveries");
            }
            else
                return StatusCode(500, $"Internal Server Error: {logicResult.Error}");
        }

        [HttpPost]
        // dodac info o route????????
        public async Task<IActionResult> DeliverDelivery([FromBody] DeliveryVm d)
        {
            DeliveryDto ddto = _deliveryConverter.VmToDto(d);

            var logicResult = await _deliveryRepository.DeliverDelivery(ddto);

            if (logicResult.Success)
            {
                return RedirectToAction("Index", "Deliveries");
            }
            else
                return StatusCode(500, $"Internal Server Error: {logicResult.Error}");
        }

        [HttpPost]
        // dodac info o route????????
        public async Task<IActionResult> CancelDelivery([FromBody] DeliveryVm d)
        {
            DeliveryDto ddto = _deliveryConverter.VmToDto(d);

            var logicResult = await _deliveryRepository.CancelDelivery(ddto);

            if (logicResult.Success)
            {
                return RedirectToAction("Index", "Deliveries");
            }
            else
                return StatusCode(500, $"Internal Server Error: {logicResult.Error}");
        }
    }
}
