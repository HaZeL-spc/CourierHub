using CourierAPI.Data;
using CourierAPI.Models;
using System.Security.Cryptography.X509Certificates;

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
            AddInquiries(context);
            AddCouriers(context);

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
        
        private static void AddInquiries(DeliverymanCastingDbContext context)
        {
            if (context.Inquiries.FirstOrDefault() != null) return;

            context.Inquiries.Add(new Inquiry
            {
                DimX = 9,
                DimY = 9,
                DimZ = 9,
                Weight = 33,
                HightPriority = true,
                WeekendDelivery = true,
                Name = "Komiks Maciek koks",
                StartLocation = new Location("Karolik", "311", "Warszawa", "01-443", "Polska"),
                EndLocation = new Location("Lici", "1332", "Mrozy", "13-441", "Polska"),
            });
            
            context.Inquiries.Add(new Inquiry
            {
                DimX = 19,
                DimY = 19,
                DimZ = 19,
                Weight = 3,
                HightPriority = false,
                WeekendDelivery = false,
                Name = "Kask",
                StartLocation = new Location("Ruska", "78", "Suwalken", "16-400", "Polska"),
                EndLocation = new Location("Czeska", "4", "Vilnus", "113-441", "Litwa"),
            });
        }

        private static void AddCouriers(DeliverymanCastingDbContext context)
        {
            if (context.Couriers.FirstOrDefault() != null) return;

            context.Couriers.Add(new Courier
            {
                Cena = 20,
                CenaHighPriority = 30,
                CzyWeekend = true,
                Workload = 0,
                MaxPackages = 5,
                Start = "Warszawa",
                End = "Płock"
            });

            context.Couriers.Add(new Courier
            {
                Cena = 15,
                CenaHighPriority = 32,
                CzyWeekend = false,
                Workload = 0,
                MaxPackages = 7,
                Start = "Płock",
                End = "Warszawa"
            });

            context.Couriers.Add(new Courier
            {
                Cena = 70,
                CenaHighPriority = 80,
                CzyWeekend = true,
                Workload = 0,
                MaxPackages = 12,
                Start = "Warszawa",
                End = "Wrocław"
            });

            context.SaveChanges();
        }
    }
}
