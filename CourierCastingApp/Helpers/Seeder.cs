using CourierCastingApp.Models;
using CourierCastingApp.Data;

namespace CourierCastingApp.Helpers
{
    public static class Seeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<CourierCastingAppDbContext>();
            context.Database.EnsureCreated();
            AddDeliveries(context);
        }
        private static void AddDeliveries(CourierCastingAppDbContext context)
        {
            if (context.SessionHistory.FirstOrDefault() != null) return;

            context.SessionHistory.Add(
                new SessionHistory(new DateTime(2023, 11, 2, 10, 30, 0))


                );
            context.SessionHistory.Add(
                 new SessionHistory(new DateTime(2023, 11, 2, 10, 31, 0))
                );
            context.SaveChanges();
        }
    }
}
