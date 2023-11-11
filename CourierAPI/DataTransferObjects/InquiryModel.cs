using System.Diagnostics.CodeAnalysis;

namespace CourierAPI.Models
{
    public class InquiryModel
    {
        [SetsRequiredMembers]
        public InquiryModel(
            double dimX, double dimY, double dimZ, double weight,
            DateOnly deliveryDate,
            LocationModel startLocation, LocationModel endLocation,
            bool hightPriority, bool weekendDelivery,
            int id = -1
            )
        {
            DimX = dimX; DimY = dimY; DimZ = dimZ;
            Weight = weight;
            DeliveryDate = deliveryDate;
            StartLocation = startLocation;
            EndLocation = endLocation;
            HightPriority = hightPriority;
            WeekendDelivery = weekendDelivery;
            if (id != -1)
                Id = id;
        }

        public required double DimX { get; set; }
        public required double DimY { get; set; }
        public required double DimZ { get; set; }
        public required double Weight { get; set; }
        public required DateOnly DeliveryDate { get; set; }
        public required LocationModel StartLocation { get; set; }
        public required LocationModel EndLocation { get; set; }
        public required bool HightPriority { get; set; }
        public required bool WeekendDelivery { get; set; }
        public int Id { get; set; }
    }
}
