using CourierCastingApp.Clients;
using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using Microsoft.AspNetCore.Mvc;

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

    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly IDeliveriesClient _deliveriesClient;

        public DeliveryRepository(IDeliveriesClient deliveriesClient)
        {
            _deliveriesClient = deliveriesClient;
        }

        public Task<Result> AddDelivery(DeliveryModel employee)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteDelivery(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<DeliveryModel>>> GetAllDeliveries()
        {
            return await _deliveriesClient.GetAllDeliveries();
        }

        public Task<Result<DeliveryModel>> GetDelivery(DeliveryModel deliveryId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateDelivery(DeliveryModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
