using CourierAPI.Data;
using CourierAPI.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace CourierAPI.Models
{
    public class DeliveryModel
    {
        
        public int Id { get; set; }
        public required DeliveryStatus Status { get; set; }
        public required string Name { get; set; }
        public required LocationModel StartLocation { get; set; }
        public required LocationModel EndLocation { get; set; }
        public DateTime PickedUpTime;
        public DateTime FinishedDeliveryTime;

        [SetsRequiredMembers]
        public DeliveryModel(int id, string name, LocationModel startLocation, LocationModel endLocation)
        {
            Id = id;
            Name = name;
            StartLocation = startLocation;
            EndLocation = endLocation;
        }
        [SetsRequiredMembers]
        public DeliveryModel(string name, LocationModel startLocation, LocationModel endLocation)
        {
            Name = name;
            StartLocation = startLocation;
            EndLocation = endLocation;
        }
        [SetsRequiredMembers]
        public DeliveryModel(Delivery delivery)
        {
            Id = delivery.Id;
            Status = delivery.Status;
            Name = delivery.Name;
            StartLocation = new LocationModel(delivery.StartLocation!);
            EndLocation = new LocationModel(delivery.EndLocation!);
            PickedUpTime = delivery.PickedUpTime;
            FinishedDeliveryTime = delivery.FinishedDeliveryTime;
        }
        public void ChangeStatus(DeliveryStatus status)
        {
            switch (status)
            {
                case DeliveryStatus.Delivered:
                    SetDelivered();
                    break;
                case DeliveryStatus.PickedUp:
                    SetPickedUp();
                    break;
                case DeliveryStatus.Cancelled:
                    SetCancelled();
                    break;
            }
        }
        private void SetDelivered()
        {
            Status = DeliveryStatus.Delivered;
            FinishedDeliveryTime = DateTime.Now;
        }
        private void SetPickedUp()
        {
            Status = DeliveryStatus.PickedUp;
            PickedUpTime = DateTime.Now;
        }
        private void SetCancelled()
        {
            Status = DeliveryStatus.Cancelled;
            FinishedDeliveryTime = DateTime.Now;
        }
    }
}
