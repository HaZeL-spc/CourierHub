using CourierAPI.Data;
using CourierAPI.Helpers;

namespace CourierAPI.Models
{
    public class DeliveryModel
    {
        public required Delivery Delivery { get; set; }
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
        public void Edit()
        {

        }

        private void SetDelivered()
        {
            Delivery.Status = DeliveryStatus.Delivered;
            Delivery.FinishedDeliveryTime = DateTime.Now;
        }
        private void SetPickedUp()
        {
            Delivery.Status = DeliveryStatus.PickedUp;
            Delivery.PickedUpTime = DateTime.Now;
        }
        private void SetCancelled()
        {
            Delivery.Status = DeliveryStatus.Cancelled;
            Delivery.FinishedDeliveryTime = DateTime.Now;
        }
    }
}
