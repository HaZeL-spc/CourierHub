using CourierAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveryRepository _deliveryRepository;
        public DeliveriesController(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }
         
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken) 
        {
            var result = await _deliveryRepository.GetAllDeliveries(cancellationToken);
            if (result.Success)
                return Ok(result.Value);
            else
                return NotFound();
        }

    }
}
