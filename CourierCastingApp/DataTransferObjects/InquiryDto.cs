using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.DataTransferObjects
{
    public class InquiryDto
    {
        public InquiryDto(
            double dimX, double dimY, double dimZ, double weight, 
            DateOnly deliveryDate, 
            LocationDto startLocation, LocationDto endLocation, 
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

        [Required]
        public double DimX { get; set; }
        [Required]
        public double DimY { get; set; }
        [Required]
        public double DimZ { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public DateOnly DeliveryDate { get; set; }
        [Required]
        public LocationDto StartLocation { get; set; }
        [Required]
        public LocationDto EndLocation { get; set; }
        [Required]
        public bool HightPriority { get; set; }
        [Required]
        public bool WeekendDelivery { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
