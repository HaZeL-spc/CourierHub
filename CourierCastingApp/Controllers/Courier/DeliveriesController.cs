using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class DeliveriesController : BaseController
    {
        private IDeliveryRepository _deliveryRepository;
        public DeliveriesController(IDeliveryRepository deliveryRepository, ICourierCastingAppRepository courierRepository) : base(courierRepository)
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
