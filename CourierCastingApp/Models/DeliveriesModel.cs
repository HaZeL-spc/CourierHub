namespace CourierCastingApp.Models
{
    public class DeliveriesModel
    {
        public async Task<IReadOnlyList<Delivery>> GetDeliveries()
        {
            // delete it! temporary solution (need to configure ssl connection!)
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = await client.GetAsync("https://courierapi/api/Deliveries");

                if (response.IsSuccessStatusCode)
                {
                    List<Delivery>? delivery = await response.Content.ReadFromJsonAsync<List<Delivery>>();
                    return delivery == null ? new List<Delivery>() { }.AsReadOnly() : delivery.AsReadOnly();
                }
                return new List<Delivery>();
            }
        }
        public void Modify(int Id, Delivery delivery)
        {
        }
    }
}
