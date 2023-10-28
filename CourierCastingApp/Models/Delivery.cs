using CourierCastingApp.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.Models
{
    public class Delivery
    {
        [SetsRequiredMembers]
        public Delivery(int id, string name, Location startLocation, Location endLocation) 
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
        public required Location StartLocation { get; set; }
        public required Location EndLocation { get; set; }
        public DateTime PickedUpTime;
        public DateTime FinishedDeliveryTime;

        public void ChangeStatus(DeliveryStatus status)
        {
            // call to CourierAPI
        }
    }
}
