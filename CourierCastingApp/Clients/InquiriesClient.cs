using CourierCastingApp.Clients;
using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace CourierCastingApp.Clients
{
    public interface IInquiriesClient
    {
        public Task<Result<IEnumerable<InquiryDto>>> GetAllInquiries();
        public Task<Result> AcceptInquiry(InquiryDto inquiry);

		public Task<Result> CreateInquiry(InquiryDto newInquiry);
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

		public async Task<Result> CreateInquiry(InquiryDto newInquiry)
		{
			try
			{
				// Convert the object to JSON
				var jsonInquiry = JsonConvert.SerializeObject(newInquiry);
				var content = new StringContent(jsonInquiry, Encoding.UTF8, "application/json");
				var myUrl = _configuration.GetSection("DefaultURIs")["InquiriesURI"];

				// POST request
				var response = await _client.PostAsync(_configuration.GetSection("DefaultURIs")["CreateInquiriesURI"]!, content);

				if (response.IsSuccessStatusCode)
				{
					//InquiryDto? createdInquiry = await response.Content.ReadFromJsonAsync<InquiryDto>();
					return /*createdInquiry == null ? Result.Fail("Failed to create inquiry") :*/ Result.Ok();
				}

				return Result.Fail($"Failed to create inquiry. Status code: {response.StatusCode}");
			}
			catch (Exception ex)
			{
				return Result.Fail($"Error: {ex.Message}");
			}
		}
	

        public async Task<Result> AcceptInquiry(InquiryDto inquiry)
        {
            try
            {
                var uri = _configuration.GetSection("DefaultURIs")["AcceptInquiryURI"];
                
                var jsonInquiry = JsonConvert.SerializeObject(inquiry);
                var content = new StringContent(jsonInquiry, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content);

                return response.IsSuccessStatusCode
                    ? Result.Ok()
                    : Result.Fail($"Failed to accept inquiry. Status code: {response.StatusCode}");
            }
            catch (Exception ex) 
            {
                return Result.Fail($"Error: {ex.Message}");
            }
        }
    }
}
