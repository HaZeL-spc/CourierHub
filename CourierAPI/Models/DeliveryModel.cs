using CourierAPI.Helpers;
using CourierAPI.Models.CourierAPI.Models;

namespace CourierAPI.Models
{
    public class DeliveryModel
    {
        public DeliveryModel(DeliveryDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Status = dto.Status;
            StartLocation = new LocationModel(dto.StartLocation);
            EndLocation = new LocationModel(dto.EndLocation);
            PickedUpDeliveryTime = dto.PickedUptime;
            FinishedDeliveryTime = dto.FinishedDeliveryTime;
            ClientId = dto.ClientId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }
        public LocationModel StartLocation { get; set; }
        public LocationModel EndLocation { get; set; }
        public DateTime PickedUpDeliveryTime { get; set; }
        public DateTime FinishedDeliveryTime { get; set; }
        public int ClientId { get; set; }

        public void SetPickedUp()
        {
            Status = DeliveryStatus.PickedUp;
            PickedUpDeliveryTime = DateTime.Now;
        }

        public void SetDelivered()
        {
            Status = DeliveryStatus.Delivered;
            FinishedDeliveryTime = DateTime.Now;
        }

        public void SetCancelled()
        {
            Status = DeliveryStatus.Cancelled;
        }
    }
}
