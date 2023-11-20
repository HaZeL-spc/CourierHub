using CourierCastingApp.Clients;
using Polly.Timeout;
using Polly;
using Polly.Extensions.Http;
using CourierCastingApp.Services;

namespace CourierCastingApp.Helpers
{
    public static class ServicesSetup
    {
        public static void SetupServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IInquiryRepository, InquiryRepository>();

            builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    // TODO: Add your own certificate validation logic here
                    return true;
                };

            builder.Services.AddHttpClient<IInquiriesClient, InquiriesClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetSection("DefaultURIs")["BaseURI"]!);
            }).ConfigurePrimaryHttpMessageHandler(() => handler)
            .AddPolicyHandler(Policy
                .Handle<TimeoutRejectedException>()
                .OrTransientHttpError()
                .WaitAndRetryAsync(new[]
                    {
                        // number of retries and delay between them
                        TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(500),
                        TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(5),
                    }))
            .AddPolicyHandler(Policy
                .TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(1))); // timeout for each request

            builder.Services.AddHttpClient<IDeliveriesClient, DeliveriesClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetSection("DefaultURIs")["BaseURI"]!);
            }).ConfigurePrimaryHttpMessageHandler(() => handler)
            .AddPolicyHandler(Policy
                .Handle<TimeoutRejectedException>()
                .OrTransientHttpError()
                .WaitAndRetryAsync(new[]
                    {
                        // number of retries and delay between them
                         TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(500),
                        TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(5),
                    }))
            //.AddPolicyHandler(Policy
            //    .Handle<TimeoutRejectedException>()
            //    .OrTransientHttpError()
            //    .CircuitBreakerAsync(
            //        5,                       // how much subsequant failures should open circuit
            //        TimeSpan.FromSeconds(30) // how long circuit should be opened before trying again
            //        ))
            .AddPolicyHandler(Policy
                .TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(1))); // timeout for each request
            
        }
    }
}
