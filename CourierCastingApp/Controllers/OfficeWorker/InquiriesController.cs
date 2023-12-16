using CourierCastingApp.Services;
using CourierCastingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.OfficeWorker
{
    
    public class InquiriesController : Controller
    {
        private IInquiryRepository _inquiryRepository;
        public InquiriesController( IInquiryRepository inquiryRepository)
        {
            _inquiryRepository = inquiryRepository;
        }

        public async Task<IActionResult> Index(string startLocationFilter, string endLocationFilter)
        {
            var resultInquiries = await _inquiryRepository.GetAllInquiries();

            if (resultInquiries.Success)
            {
                ICollection<InquiryVm> inquiries = resultInquiries.Value.Select(i => new InquiryVm(i)).ToList();

                if (!string.IsNullOrEmpty(startLocationFilter))
                {
                    inquiries = inquiries.Where(i =>
                        i.StartLocation.City.Contains(startLocationFilter, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                if (!string.IsNullOrEmpty(endLocationFilter))
                {
                    inquiries = inquiries.Where(i =>
                        i.EndLocation.City.Contains(endLocationFilter, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                return View(inquiries);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
