using CourierCastingApp.Clients;
using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Services
{
    public interface IDeliveryRepository
    {
        public Task<Result<IEnumerable<DeliveryDto>>> GetAllDeliveries();
        public Task<Result<DeliveryDto>> GetDelivery(int deliveryId);
        public Task<Result> AddDelivery(DeliveryDto employee);
        public Task<Result> UpdateDelivery(DeliveryDto employee);
        public Task<Result> DeleteDelivery(int deliveryId);
        public Task<Result> PickUpDelivery(DeliveryDto delivery);
        public Task<Result> DeliverDelivery(DeliveryDto ddto);
        public Task<Result> CancelDelivery(DeliveryDto ddto);
    }

    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly IDeliveriesClient _deliveriesClient;

        public DeliveryRepository(IDeliveriesClient deliveriesClient)
        {
            _deliveriesClient = deliveriesClient;
        }

        public async Task<Result> CancelDelivery(DeliveryDto ddto)
        {
            return await _deliveriesClient.CancelDelivery(ddto);
        }

        public async Task<Result> PickUpDelivery(DeliveryDto dto)
        {
            return await _deliveriesClient.PickUpDelivery(dto);
        }

        public Task<Result> AddDelivery(DeliveryDto employee)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteDelivery(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<DeliveryDto>>> GetAllDeliveries()
        {
            return await _deliveriesClient.GetAllDeliveries();
        }

        public async Task<Result<DeliveryDto>> GetDelivery(int deliveryId)
        {
            return await _deliveriesClient.GetDelivery(deliveryId);
        }

        public Task<Result> UpdateDelivery(DeliveryDto employee)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> DeliverDelivery(DeliveryDto ddto)
        {
            return await _deliveriesClient.DeliverDelivery(ddto);
        }
    }
}
