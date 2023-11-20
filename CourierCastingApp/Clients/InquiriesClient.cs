using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using CourierCastingApp.Models;

namespace CourierCastingApp.Clients
{
    public interface IInquiriesClient
    {
        public Task<Result<IEnumerable<InquiryDto>>> GetAllInquiries();
        //public Task<Result<DeliveryDto>> GetDelivery(int deliveryId);
    }

    public class InquiriesClient : IInquiriesClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public InquiriesClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async Task<Result<IEnumerable<InquiryDto>>> GetAllInquiries()
        {
            var response = await _client.GetAsync(_configuration.GetSection("DefaultURIs")["InquiriesURI"]!);
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<InquiryDto>? inquiries = await response.Content.ReadFromJsonAsync<IEnumerable<InquiryDto>>();
                return inquiries == null ? Result.Fail<IEnumerable<InquiryDto>>("Resource not found") : Result.Ok(inquiries);
            }
            return Result.Fail<IEnumerable<InquiryDto>>("Failed to get response");
        }
    }
}
