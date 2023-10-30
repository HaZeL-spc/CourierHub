using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourierCastingApp.Services
{
    public class DeliveryRepository : IDeliveryRepository
    {
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
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = await client.GetAsync("https://courierapi/api/Deliveries");

                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<DeliveryModel>? deliveries = await response.Content.ReadFromJsonAsync<  IEnumerable<DeliveryModel>>();
                    return deliveries == null ? Result.Fail<IEnumerable<DeliveryModel>>("Resource not found") : Result.Ok(deliveries);
                }
                return Result.Fail<IEnumerable<DeliveryModel>>("Failed to get response");
            }
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
