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
                return Ok(result.Value);
            else
                return NotFound();
        }

		[HttpPost]
		public async Task<ActionResult<string>> CreateInquiry([FromBody] InquiryDTO inquiryDto)
		{
            var result = await _inquiryRepository.AddInquiry(inquiryDto);
            if (result.Success)
            {
                return Ok(result);
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

        [HttpPost]
        [Route("RejectInquiry")]
        public async Task<IActionResult> RejectInquiry([FromBody] InquiryDTO inquiry, CancellationToken cancellationToken)
        {
            var logicResponse = await _logic.RejectInquiry(inquiry, cancellationToken);

            if (logicResponse.Success)
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
