using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CourierCastingApp.Clients
{
    public interface IInquiriesClient
    {
        public Task<Result<IEnumerable<InquiryDto>>> GetAllInquiries();
		public Task<Result<string>> CreateInquiry(InquiryDto newInquiry);
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
			System.Diagnostics.Debug.WriteLine(_configuration.GetSection("DefaultURIs")["InquiriesURI"]!);
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<InquiryDto>? inquiries = await response.Content.ReadFromJsonAsync<IEnumerable<InquiryDto>>();
                return inquiries == null ? Result.Fail<IEnumerable<InquiryDto>>("Resource not found") : Result.Ok(inquiries);
            }
            return Result.Fail<IEnumerable<InquiryDto>>("Failed to get response");
        }

		public async Task<Result<string>> CreateInquiry(InquiryDto newInquiry)
		{
			try
			{
				// Convert the object to JSON
				var jsonInquiry = JsonConvert.SerializeObject(newInquiry);
				var content = new StringContent(jsonInquiry, Encoding.UTF8, "application/json");
				var myUrl = _configuration.GetSection("DefaultURIs")["InquiriesURI"];

				// POST request
				var response = await _client.PostAsync(_configuration.GetSection("DefaultURIs")["InquiriesURI"]!, content);

				if (response.IsSuccessStatusCode)
				{
                    return response.IsSuccessStatusCode ? 
                        Result.Ok(response.Content.ToString()) : 
                        Result.Fail<string>($"Failed to create inquiry. Status code: {response.StatusCode}");
                }

				return Result.Fail<string>($"Failed to create inquiry. Status code: {response.StatusCode}");
			}
			catch (Exception ex)
			{
				return Result.Fail<string>($"Error: {ex.Message}");
			}
		}
	}
}
