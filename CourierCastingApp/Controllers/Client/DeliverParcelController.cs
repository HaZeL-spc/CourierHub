using CourierCastingApp.Models;
using CourierCastingApp.Models.Form;
using CourierCastingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
    public class DeliverParcelController : Controller
    {
		private IDeliveryRepository _deliveryRepository;

		public DeliverParcelController(IDeliveryRepository deliveryRepository)
		{
			_deliveryRepository = deliveryRepository;
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
                var result = await _deliveryRepository.GetAllDeliveries();
                Console.Write("fit");
			}

            return View(model); // Return to the same view with validation error messages.
        }
    }
}
