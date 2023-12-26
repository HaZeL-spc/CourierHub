using CourierAPI.Logic;
using CourierAPI.Models;
using CourierAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IDeliveriesLogic _logic;
        public DeliveriesController(IDeliveryRepository deliveryRepository, 
            IDeliveriesLogic logic)
        {
            _logic = logic;
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

        [HttpPost]
        [Route("PickUpDelivery")]
        public async Task<IActionResult> PickUpDelivery([FromBody] DeliveryDto d, CancellationToken cancellationToken)
        {
            var logicResponse = await _logic.PickUpDelivery(d, cancellationToken);

            if (logicResponse.Success)
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpPost]
        [Route("DeliverDelivery")]
        public async Task<IActionResult> DeliverDelivery([FromBody] DeliveryDto d, CancellationToken cancellationToken)
        {
            var logicResponse = await _logic.DeliverDelivery(d, cancellationToken);

            if (logicResponse.Success)
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpPost]
        [Route("CancelDelivery")]
        public async Task<IActionResult> CancelDelivery([FromBody] DeliveryDto d, CancellationToken cancellationToken)
        {
            var logicResponse = await _logic.CancelDelivery(d, cancellationToken);

            if (logicResponse.Success)
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
