using CourierAPI.Data;
using CourierAPI.Models;

namespace CourierAPI.Helpers
{
    public static class Seeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DeliverymanCastingDbContext>();
            context.Database.EnsureCreated();
            AddDeliveries(context);
        }
        private static void AddDeliveries(DeliverymanCastingDbContext context)
        {
            if (context.Deliveries.FirstOrDefault() != null) return;

            context.Clients.Add(new Client
            {
                Deliveries = new[]
                {
                    new Delivery
                    {
                        Name = "Komiks Asterix in Germany",
                        StartLocation = new Location("Karolkowa", "3", "Warszawa", "01-443", "Polska"),
                        EndLocation = new Location("Licznijkowa", "12", "Pisz", "13-442", "Polska"),
                    }
                }
            });

            context.Clients.Add(new Client
            {
                Deliveries = new[]
                {
                    new Delivery
                    {
                        Name = "Keyboard MX Mechanical",
                        StartLocation = new Location("Ragrahaza", "13", "Suchowola", "11-143", "Polska"),
                        EndLocation = new Location("Majerka", "2", "Dubowo", "3-412", "Polska"),
                    }
                }
            });

            context.SaveChanges();
        }
    }
}
