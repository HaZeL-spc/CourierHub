using CourierCastingApp.Helpers;
using CourierCastingApp.Models;

namespace CourierCastingApp.Services
{
    public interface IDeliveryRepository
    {
        public Task<Result<IEnumerable<DeliveryModel>>> GetAllDeliveries();
        public Task<Result<DeliveryModel>> GetDelivery(DeliveryModel deliveryId);
        public Task<Result> AddDelivery(DeliveryModel employee);
        public Task<Result> UpdateDelivery(DeliveryModel employee);
        public Task<Result> DeleteDelivery(int deliveryId);
    }
}
