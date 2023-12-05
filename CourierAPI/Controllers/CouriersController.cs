using Microsoft.AspNetCore.Mvc;
using CourierAPI.Services;
using CourierAPI.Models;

namespace CourierAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CouriersController : ControllerBase
	{
		private readonly ICourierRepository _courierRepository;
		public CouriersController(ICourierRepository courierRepository)
		{
			_courierRepository = courierRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Get(
			[FromQuery] string start,
			[FromQuery] string end,
			[FromQuery] string highPriority,
			[FromQuery] string dayOfWeek, 
			CancellationToken cancellationToken)
		{
			var result = await _courierRepository.GetBestCourier(start, end, highPriority, dayOfWeek, cancellationToken);
			if (result.Success)
				return Ok(result.Value);
			else
				return NotFound();
		}
	}
}