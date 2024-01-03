using CourierCastingApp.Clients;
using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using CourierCastingApp.Services;
using CourierCastingApp.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    public class OfferRequestsController : Controller
    {
        private IDeliveryRepository _deliveryRepository;
        private IInquiryRepository _inquiryRepository;
        private IInquiriesClient _inquiriesClient;
        public OfferRequestsController(
            IDeliveryRepository deliveryRepository,
            IInquiryRepository inquiryRepository,
            IInquiriesClient inquiriesClient
            )
        {
            _inquiriesClient = inquiriesClient;
            _deliveryRepository = deliveryRepository;
            _inquiryRepository = inquiryRepository;
        }

        public async Task<IActionResult> Index()
        {

            var resultInquiries = await _inquiryRepository.GetAllInquiries();
            var resultDeliveries = await _deliveryRepository.GetAllDeliveries();
            if (resultDeliveries.Success && resultInquiries.Success)
            {
                ICollection<DeliveryVm> deliveries = resultDeliveries.Value.Select(d => new DeliveryVm(d)).ToList();
                ICollection<InquiryVm> inquiries = resultInquiries.Value.Select(i => new InquiryVm(i)).ToList();

                return View((inquiries, deliveries));
            }

            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AcceptInquiry([FromBody] InquiryVm i)
        {
            // make converter? i cannot use constructor cause vm and dto can depend on each other both ways

            InquiryDto inquiry = new InquiryDto(i.DimX, i.DimY, i.DimZ, i.Weight, i.DeliveryDate, i.Name,
                new LocationDto
                {
                    City = i.EndLocation.City,
                    Country = i.EndLocation.Country,
                    PostCode = i.EndLocation.PostCode,
                    Street = i.EndLocation.Street,
                    StreetNumber = i.EndLocation.StreetNumber
                },
                new LocationDto
                {
                    City = i.StartLocation.City,
                    Country = i.StartLocation.Country,
                    PostCode = i.StartLocation.PostCode,
                    Street = i.StartLocation.Street,
                    StreetNumber = i.StartLocation.StreetNumber
                },
                i.HightPriority, i.WeekendDelivery, new CourierDto(), i.Id, i.InquiryStatus
                );

            var logicResult = await _inquiryRepository.AcceptInquiry(inquiry);

            if (logicResult.Success)
            {
                return RedirectToAction("Index", "OfferRequests");
            }
            else
                return StatusCode(500, $"Internal Server Error: {logicResult.Error}");
        }

        [HttpPost]
        public async Task<IActionResult> RejectInquiry([FromBody] InquiryVm i)
        {
            // make converter? i cannot use constructor cause vm and dto can depend on each other both ways

            InquiryDto inquiry = new InquiryDto(i.DimX, i.DimY, i.DimZ, i.Weight, i.DeliveryDate, i.Name,
                new LocationDto
                {
                    City = i.EndLocation.City,
                    Country = i.EndLocation.Country,
                    PostCode = i.EndLocation.PostCode,
                    Street = i.EndLocation.Street,
                    StreetNumber = i.EndLocation.StreetNumber
                },
                new LocationDto
                {
                    City = i.StartLocation.City,
                    Country = i.StartLocation.Country,
                    PostCode = i.StartLocation.PostCode,
                    Street = i.StartLocation.Street,
                    StreetNumber = i.StartLocation.StreetNumber
                },
                i.HightPriority, i.WeekendDelivery, new CourierDto(), i.Id, i.InquiryStatus
                );

            var logicResult = await _inquiryRepository.RejectInquiry(inquiry);

            if (logicResult.Success)
            {
                return RedirectToAction("Index", "OfferRequests");
            }
            else
                return StatusCode(500, $"Internal Server Error: {logicResult.Error}");
        }
    }
}
