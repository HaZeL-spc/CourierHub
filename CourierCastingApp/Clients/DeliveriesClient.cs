using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using Humanizer;
using Newtonsoft.Json;
using System.Text;

namespace CourierCastingApp.Clients
{
    public interface IDeliveriesClient
    {
        public Task<Result> CancelDelivery(DeliveryDto ddto);
        public Task<Result> DeliverDelivery(DeliveryDto ddto);
        public Task<Result<IEnumerable<DeliveryDto>>> GetAllDeliveries();
        public Task<Result<DeliveryDto>> GetDelivery(int deliveryId);
        public Task<Result> PickUpDelivery(DeliveryDto dto);
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

        public async Task<Result> CancelDelivery(DeliveryDto ddto)
        {
            try
            {
                var uri = _configuration.GetSection("DefaultURIs")["CancelDeliveryURI"];

                var jsonInquiry = JsonConvert.SerializeObject(ddto);
                var content = new StringContent(jsonInquiry, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content);

                return response.IsSuccessStatusCode
                    ? Result.Ok()
                    : Result.Fail($"Failed to deliver delivery. Status code: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error: {ex.Message}");
            }
        }

        public async Task<Result> DeliverDelivery(DeliveryDto ddto)
        {
            try
            {
                var uri = _configuration.GetSection("DefaultURIs")["DeliverDeliveryURI"];

                var jsonInquiry = JsonConvert.SerializeObject(ddto);
                var content = new StringContent(jsonInquiry, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content);

                return response.IsSuccessStatusCode
                    ? Result.Ok()
                    : Result.Fail($"Failed to deliver delivery. Status code: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error: {ex.Message}");
            }
        }

        public async Task<Result> PickUpDelivery(DeliveryDto dto)
        {
            try
            {
                var uri = _configuration.GetSection("DefaultURIs")["PickUpDeliveryURI"];

                var jsonInquiry = JsonConvert.SerializeObject(dto);
                var content = new StringContent(jsonInquiry, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content);

                return response.IsSuccessStatusCode
                    ? Result.Ok()
                    : Result.Fail($"Failed to pick up delivery. Status code: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error: {ex.Message}");
            }
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
