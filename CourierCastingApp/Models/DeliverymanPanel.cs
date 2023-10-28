namespace CourierCastingApp.Models
{
    public class DeliverymanPanel
    {
        private Dictionary<int, Delivery> Deliveries = new Dictionary<int, Delivery>();

        public IReadOnlyList<Delivery> GetDeliveries()
        {
            return Deliveries.Values.ToList().AsReadOnly();
        }
        public void Modify(int Id, Delivery delivery)
        {
            Delivery? deliveryToModify;
            if (Deliveries.TryGetValue(Id, out deliveryToModify))
                deliveryToModify = delivery;
        }
    }
}
