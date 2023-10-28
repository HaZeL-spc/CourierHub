using CourierAPI.Data;
using CourierAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourierAPI.Models
{
    public class DeliveriesModel
    {
        private readonly DeliverymanCastingDbContext _dbContext;
        public DeliveriesModel(DeliverymanCastingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<DeliveryModel>?> AsList()
        {
            try
            {
                var query = from d in _dbContext.Deliveries
                            join el in _dbContext.Locations on d.EndLocation!.Id equals el.Id
                            join sl in _dbContext.Locations on d.StartLocation!.Id equals sl.Id
                            select new DeliveryModel(d.Id, d.Name, new LocationModel(sl), new LocationModel(el));
                //List < DeliveryModel > deliveries = new List<DeliveryModel>();
                //foreach (var delivery in query.ToArray())
                //{
                //    if (delivery is not null)
                //        deliveries.Add(new DeliveryModel(delivery));
                //}
                var deliveries = await query.ToListAsync();
                return deliveries;
            }
            catch
            {
                return null;
            }

            //DeliveryModel d1 = new(1, "Headphones Pro", new LocationModel(1, "Karolkowa", "3", "Warszawa", "01-443", "Polska"), new LocationModel(3, "Licznijkowa", "12", "Pisz", "13-442", "Polska"));
            //DeliveryModel d2 = new(2, "Keyboard MX Mechanical", new LocationModel(2, "Ragrahaza", "13", "Suchowola", "11-143", "Polska"), new LocationModel(4, "Majerka", "2", "Dubowo", "3-412", "Polska"));

            //var res = new List<DeliveryModel>() { d1, d2 };
            //return res.AsReadOnly();
        }
        
    }
}
