using CourierAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly DeliverymanCastingDbContext _dbContext;
        private DeliveriesModel _deliveries;
        public DeliveriesController(DeliverymanCastingDbContext dbContext)
        {
            _dbContext = dbContext;
            _deliveries = new DeliveriesModel(_dbContext);
        }
         
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var deliveries = await _deliveries.AsList();
            if (deliveries is not null)
                return Ok(deliveries);
            else
                return BadRequest();
        }
    }
}
