using CourierAPI.Helpers;
using CourierAPI.Models.CourierAPI.Models;

namespace CourierAPI.Models
{
    public class InquiryModel
    {
        public double DimX { get; set; }
        public double DimY { get; set; }
        public double DimZ { get; set; }
        public double Weight { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Name { get; set; } = "";
        public LocationModel StartLocation { get; set; } = new LocationModel();
        public LocationModel EndLocation { get; set; } = new LocationModel();
        public bool HightPriority { get; set; }
        public bool WeekendDelivery { get; set; }
        public int Id { get; set; }
        public InquiryStatus Status { get; set; } = InquiryStatus.NotConsidered;
        
        
        public InquiryModel()
        {

        }

        public void SetAcceptedByOfficeWorker()
        {

        }
    }
}
