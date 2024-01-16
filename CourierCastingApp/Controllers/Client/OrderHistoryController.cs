using CourierCastingApp.Services;
using CourierCastingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Controllers.Client
{
    public class OrderHistoryController : Controller
    {
        private IDeliveryRepository _deliveryRepository;
        public OrderHistoryController(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string startLocationFilter, string endLocationFilter, string sortOrder)
        {
            var result = await _deliveryRepository.GetAllDeliveries();

            if (result.Success)
            {
                var deliveries = result.Value.Select(d => new DeliveryVm(d)).ToList();

                // Filtruj dostawy na podstawie lokalizacji początkowej i końcowej
                if (!string.IsNullOrEmpty(startLocationFilter))
                {
                    deliveries = deliveries.Where(d => d.StartLocation.City.Contains(startLocationFilter, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (!string.IsNullOrEmpty(endLocationFilter))
                {
                    deliveries = deliveries.Where(d => d.EndLocation.City.Contains(endLocationFilter, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                // Sortowanie
                deliveries = ApplySorting(deliveries, sortOrder);

                return View(deliveries);
            }
            else
            {
                return NotFound();
            }
        }

        private List<DeliveryVm> ApplySorting(List<DeliveryVm> deliveries, string sortOrder)
        {
            switch (sortOrder)
            {
                case "oldest":
                    deliveries = deliveries.OrderBy(d => d.Id).ToList();
                    break;
                case "newest":
                default:
                    deliveries = deliveries.OrderByDescending(d => d.Id).ToList();
                    break;
            }

            return deliveries;
        }


    }
}
