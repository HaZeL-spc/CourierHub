using CourierCastingApp.Helpers;
using Microsoft.CodeAnalysis;

namespace CourierCastingApp.Models
{
    public class Delivery
    {
        public required int Id { get; set; }
        public required DeliveryStatus Status { get; set; }
        public required string Name { get; set; }
        public required Location StartLocation { get; set; }
        public required Location EndLocation { get; set; }
        public DateTime PickedUpTime;
        public DateTime FinishedDeliveryTime;


    }
}
