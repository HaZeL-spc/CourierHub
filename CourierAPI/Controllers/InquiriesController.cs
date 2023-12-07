using CourierAPI.Models;
using CourierAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiriesController : ControllerBase
    {
        private readonly IInquiryRepository _inquiryRepository;
        public InquiriesController(IInquiryRepository inquiryRepository)
        {
            _inquiryRepository = inquiryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _inquiryRepository.GetAllInquiries(cancellationToken);
            if (result.Success)
                return Ok(result.Value );
            else
                return NotFound();
        }

		[HttpPost]
		public async Task<IActionResult> CreateInquiry([FromBody] InquiryDTO inquiryDto)
		{
            var result = await _inquiryRepository.AddInquiry(inquiryDto);
            if (result.Success)
            {
                return Ok("Inquiry added successfully.");
			}

            return Ok("Failed to add inquiry");
		}
	}
}
