using CourierCastingApp.Clients;
using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Services
{
    public interface IInquiryRepository
    {
        public Task<Result<IEnumerable<InquiryDto>>> GetAllInquiries();
        //public Task<Result<DeliveryDto>> GetDelivery(int deliveryId);
        //public Task<Result> AddDelivery(DeliveryDto employee);
        //public Task<Result> UpdateDelivery(DeliveryDto employee);
        //public Task<Result> DeleteDelivery(int deliveryId);
    }

    public class InquiryRepository : IInquiryRepository
    {
        private readonly IInquiriesClient _inquiriesClient;

        public InquiryRepository(IInquiriesClient inquiriesClient)
        {
            _inquiriesClient = inquiriesClient;
        }

        public async Task<Result<IEnumerable<InquiryDto>>> GetAllInquiries()
        {
            return await _inquiriesClient.GetAllInquiries();
        }
    }
}
