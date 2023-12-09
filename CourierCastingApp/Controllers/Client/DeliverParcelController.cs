using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Models;
using CourierCastingApp.Models.Forms;
using CourierCastingApp.Services;
using CourierCastingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
			//TempData.Remove("MemoryInquiryResult");
				// If model is null, create a new instance
			if (TempData["MemoryInquiryResult"] is not null)
			{
				var viewModel = JsonConvert.DeserializeObject<InquiryResultVm>(TempData["MemoryInquiryResult"].ToString());
				return View(viewModel);
			}

			return View(new InquiryResultVm());
		}

		[HttpPost]
		public async Task<IActionResult> AddInquiryForm(InquiryResultVm model, int courierId)
		{
			if (model.validateInquiryModel())
			{

				var courier = new CourierDto(model.BestCouriers[courierId]);
                InquiryDto inquiryDto = new InquiryDto(model.InquiryModel, courier);

                var result = await _inquiryRepository.CreateInquiry(inquiryDto);

                if (result.Success)
				{
					TempData["SuccessMessage"] = "Inquiry created successfully!";
					return RedirectToAction("Index");
				}
			}

            return View("Index");
        }

		[HttpPost]
		public async Task<IActionResult> GetBestCourier(InquiryResultVm model)
		{
			InquiryResultVm viewModel = new InquiryResultVm
			{
				InquiryModel = model.InquiryModel
			};

			// Explicitly validate InquiryModel
			if (model.validateInquiryModel())
			{
				bool isWeekend = checkIfWeekend(model.InquiryModel.DeliveryDate);
				model.InquiryModel.WeekendDelivery = isWeekend;

                InquiryDto inquiryDto = new InquiryDto(model.InquiryModel);

				var result = await _courierRepository.GetBestCouriers(inquiryDto);
				viewModel.Success = result.Success;

				if (result.Success)
				{
					viewModel.Message = "Courier successfully obtained!";
					var couriers = new List<CourierVm>();

					foreach (var item in result.Value)
					{
						var courier = new CourierVm(item);
						couriers.Add(courier);
					}
					viewModel.BestCouriers = couriers.ToArray();
				} else
				{
					viewModel.Message = "No couriers";
				}

                TempData["MemoryInquiryResult"] = JsonConvert.SerializeObject(viewModel);
                return RedirectToAction("Index");
            }
			return View("Index");
        }
        public bool checkIfWeekend(DateOnly date)
        {
            int day = (int)date.DayOfWeek;
            return day == 6 || day == 0;
        }
    }
}
