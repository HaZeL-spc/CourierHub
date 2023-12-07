using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Models;
using CourierCastingApp.Models.Forms;
using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
	public class DeliverParcelController : Controller
	{
		private IInquiryRepository _inquiryRepository;

		public DeliverParcelController(IInquiryRepository inquiryRepository)
		{
			_inquiryRepository = inquiryRepository;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(InquiryFormModel model)
		{
			if (ModelState.IsValid)
			{
				//DateTime combinedDateTime = model.DeliveryDate.AsDateTime()

				// Create DateTime variable by combining DateOnly and TimeOnly

				InquiryDto inquiryDto = new InquiryDto(model);
				var result = await _inquiryRepository.CreateInquiry(inquiryDto);

				if (result.isFailure)
					return StatusCode(500);

				TempData["SuccessMessage"] = "Inquiry created successfully!";
				return RedirectToAction("Index");
			}

			return View(model); // Return to the same view with validation error messages.
		}
	}
}
