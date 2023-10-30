﻿using CourierAPI.Helpers;
using CourierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourierAPI.Services
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DeliverymanCastingDbContext _dbContext;

        public DeliveryRepository(DeliverymanCastingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Result> AddDelivery(DeliveryModel employee)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteDelivery(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<DeliveryModel>>> GetAllDeliveries()
        {
            try
            {
                var query = from d in _dbContext.Deliveries
                            join el in _dbContext.Locations on d.EndLocation!.Id equals el.Id
                            join sl in _dbContext.Locations on d.StartLocation!.Id equals sl.Id
                            select new DeliveryModel(d.Id, d.Name, new LocationModel(sl), new LocationModel(el));
                var deliveries = await query.ToListAsync();
                return Result.Ok<IEnumerable<DeliveryModel>>(deliveries);
            }
            catch
            {
                return Result.Fail<IEnumerable<DeliveryModel>>("Failed to recieve data");
            }
        }

        public Task<Result<DeliveryModel>> GetDelivery(DeliveryModel deliveryId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateDelivery(DeliveryModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
