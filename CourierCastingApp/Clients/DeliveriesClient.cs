using CourierCastingApp.Helpers;
using CourierCastingApp.Models;

namespace CourierCastingApp.Clients
{
    public interface IDeliveriesClient
    {
        public Task<Result<IEnumerable<DeliveryModel>>> GetAllDeliveries();
        public Task<Result<DeliveryModel>> GetDelivery(int deliveryId);
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
        public async Task<Result<IEnumerable<DeliveryModel>>> GetAllDeliveries()
        {
            var response = await _client.GetAsync(_configuration.GetSection("DefaultURIs")["DeliveriesURI"]!);
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<DeliveryModel>? deliveries = await response.Content.ReadFromJsonAsync<IEnumerable<DeliveryModel>>();
                return deliveries == null ? Result.Fail<IEnumerable<DeliveryModel>>("Resource not found") : Result.Ok(deliveries);
            }
            return Result.Fail<IEnumerable<DeliveryModel>>("Failed to get response");
        }

        public async Task<Result<DeliveryModel>> GetDelivery(int deliveryId)
        {
            var response = await _client.GetAsync($"{_configuration.GetSection("DefaultURIs")["DeliveriesURI"]!}/GetDelivery/{deliveryId}");
            if (response.IsSuccessStatusCode)
            {
                DeliveryModel? deliveries = await response.Content.ReadFromJsonAsync<DeliveryModel>();
                return deliveries == null ? Result.Fail<DeliveryModel>("Resource not found") : Result.Ok(deliveries);
            }
            return Result.Fail<DeliveryModel>("Failed to get response");
        }
    }
}
