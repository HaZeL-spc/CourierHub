using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using CourierCastingApp.Models;

namespace CourierCastingApp.Clients
{
    public interface IDeliveriesClient
    {
        public Task<Result<IEnumerable<DeliveryDto>>> GetAllDeliveries();
        public Task<Result<DeliveryDto>> GetDelivery(int deliveryId);
    }

    public class DeliveriesClient : IDeliveriesClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public DeliveriesClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }
        public async Task<Result<IEnumerable<DeliveryDto>>> GetAllDeliveries()
        {
            var response = await _client.GetAsync(_configuration.GetSection("DefaultURIs")["DeliveriesURI"]!);
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<DeliveryDto>? deliveries = await response.Content.ReadFromJsonAsync<IEnumerable<DeliveryDto>>();
                return deliveries == null ? Result.Fail<IEnumerable<DeliveryDto>>("Resource not found") : Result.Ok(deliveries);
            }
            return Result.Fail<IEnumerable<DeliveryDto>>("Failed to get response");
        }

        public async Task<Result<DeliveryDto>> GetDelivery(int deliveryId)
        {
            var response = await _client.GetAsync($"{_configuration.GetSection("DefaultURIs")["DeliveriesURI"]!}/GetDelivery/{deliveryId}");
            if (response.IsSuccessStatusCode)
            {
                DeliveryDto? deliveries = await response.Content.ReadFromJsonAsync<DeliveryDto>();
                return deliveries == null ? Result.Fail<DeliveryDto>("Resource not found") : Result.Ok(deliveries);
            }
            return Result.Fail<DeliveryDto>("Failed to get response");
        }
    }
}
