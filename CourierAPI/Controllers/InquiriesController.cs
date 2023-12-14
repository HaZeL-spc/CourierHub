using CourierAPI.Helpers;
using CourierAPI.Logic;
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
        private readonly IInquiriesLogic _logic;
        public InquiriesController(IInquiryRepository inquiryRepository, IInquiriesLogic inquiriesLogic)
        {
            _inquiryRepository = inquiryRepository;
            _logic = inquiriesLogic;
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
        [Route("CreateInquiry")]
		public async Task<IActionResult> CreateInquiry([FromBody] InquiryDTO inquiryDto)
		{
            var result = await _inquiryRepository.AddInquiry(inquiryDto);
            if (result.Success)
            {
                return Ok("Inquiry added successfully.");
			}

            return Ok("Failed to add inquiry");
		}

        [HttpPost]
        [Route("AcceptInquiry")]
        public async Task<IActionResult> AcceptInquiry([FromBody] InquiryDTO inquiry, CancellationToken cancellationToken)
        {
            var logicResponse = await _logic.AcceptInquiry(inquiry, cancellationToken);

            if (logicResponse.Success)
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
