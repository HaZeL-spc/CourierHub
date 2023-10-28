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

            context.Deliveries.Add(new Delivery("Komiks Asterix in Germany", 
                new Location("Karolkowa", "3", "Warszawa", "01-443", "Polska"), 
                new Location("Licznijkowa", "12", "Pisz", "13-442", "Polska")
                ));
            context.Deliveries.Add(new Delivery("Keyboard MX Mechanical", 
                new Location("Ragrahaza", "13", "Suchowola", "11-143", "Polska"), 
                new Location("Majerka", "2", "Dubowo", "3-412", "Polska")
                ));

            context.SaveChanges();
        }
    }
}
