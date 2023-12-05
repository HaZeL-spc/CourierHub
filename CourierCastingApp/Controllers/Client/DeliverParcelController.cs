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
		private ICourierRepository _courierRepository;

		public DeliverParcelController(IInquiryRepository inquiryRepository, ICourierRepository courierRepository)
		{
			_inquiryRepository = inquiryRepository;
			_courierRepository = courierRepository;
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

				//_inquiryRepository.CreateInquiry(inquiryDto);

				TempData["SuccessMessage"] = "Inquiry created successfully!";
				return RedirectToAction("Index");
			}

			return View(model); // Return to the same view with validation error messages.
		}

		[HttpPost]
		public async Task<IActionResult> GetBestCourier(InquiryFormModel model)
		{
            if (ModelState.IsValid)
            {
                //DateTime combinedDateTime = model.DeliveryDate.AsDateTime()

                // Create DateTime variable by combining DateOnly and TimeOnly

                InquiryDto inquiryDto = new InquiryDto(model);

				var result = await _courierRepository.GetBestCourier(inquiryDto);
				if (result.Success)
				{
					TempData["SuccessMessage"] = "Inquiry created successfully!";
					return RedirectToAction("Index");
				}
                //_inquiryRepository.CreateInquiry(inquiryDto);
            }
			return View("Index", model);
        }
	}
}
