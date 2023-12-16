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
			[FromQuery] string dayOfWeek)
		{
			var cancellationTokenSource = new CancellationTokenSource();
			cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));
			var cancellationToken = cancellationTokenSource.Token;

			try
			{
				var result = await _courierRepository.GetBestCourier(start, end, highPriority, dayOfWeek, cancellationToken);
				if (result.Success)
					return Ok(result.Value);
				else
					return NotFound();
			}
			catch (OperationCanceledException)
			{
				// Handle the cancellation exception here
				// For example, you might want to return a specific status code or message
				return StatusCode(504, "Request timed out");
			}
		}
	}
}