using CourierCastingApp.Clients;
using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;

namespace CourierCastingApp.Services
{
    public interface ICourierRepository
    {
        public Task<Result<CourierDto>> GetBestCourier(InquiryDto inquiry);
    }

    public class CourierRepository : ICourierRepository
    {
        private readonly ICouriersClient _couriersClient;

        public CourierRepository(ICouriersClient couriersClient)
        {
            _couriersClient = couriersClient;
        }

        public Task<Result<CourierDto>> GetBestCourier(InquiryDto inquiry)
        {
            return _couriersClient.GetBestCourier(inquiry);
        }
    }

}