using CourierCastingApp.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.Models
{
    public class DeliveryModel
    {
        [SetsRequiredMembers]
        public DeliveryModel(int id, string name, LocationModel startLocation, LocationModel endLocation) 
        {
            Id = id;
            Status = DeliveryStatus.NotPickedUp;
            Name = name;
            StartLocation = startLocation;
            EndLocation = endLocation;
        }

        public required int Id { get; set; }
        public required DeliveryStatus Status { get; set; }
        public required string Name { get; set; }
        public required LocationModel StartLocation { get; set; }
        public required LocationModel EndLocation { get; set; }
        public DateTime PickedUpTime;
        public DateTime FinishedDeliveryTime;
    }
}
