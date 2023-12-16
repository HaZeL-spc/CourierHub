using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using Newtonsoft.Json;
using System.Text;

namespace CourierCastingApp.Clients
{
    public interface ICouriersClient
    {
        public Task<Result<List<CourierDto>>> GetBestCouriers(InquiryDto inquiry);
    }

    public class CouriersClient : ICouriersClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public CouriersClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

		public async Task<Result<List<CourierDto>>> GetBestCouriers(InquiryDto inquiry)
		{
			string queryParams = $"start={inquiry.StartLocation.City}&end={inquiry.EndLocation.City}&highPriority={inquiry.HightPriority}&dayOfWeek={(int)inquiry.DeliveryDate.DayOfWeek}";

			var response = await _client.GetAsync($"{_configuration.GetSection("DefaultURIs")["CouriersURI"]!}?{queryParams}");

			if (response.IsSuccessStatusCode)
			{
				List<CourierDto>? couriers = await response.Content.ReadFromJsonAsync<List<CourierDto>>();

				return couriers == null || couriers.Count == 0
					? Result.Fail<List<CourierDto>>("Resource not found")
					: Result.Ok(couriers);
			}

			return Result.Fail<List<CourierDto>>("Failed to get response");
		}

	}
}
