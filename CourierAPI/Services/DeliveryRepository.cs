using CourierAPI.Data;
using CourierAPI.Helpers;
using CourierAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourierAPI.Services;

public interface IDeliveryRepository
{
    public Task<Result<IEnumerable<DeliveryDto>>> GetAllDeliveries(CancellationToken cancellationToken);
    public Task<Result<DeliveryDto>> GetDelivery(int deliveryId, CancellationToken cancellationToken);
    public Task<Result> AddDelivery(DeliveryDto employee);
    public Task<Result> UpdateDelivery(DeliveryDto employee);
    public Task<Result> DeleteDelivery(int deliveryId);
}
public class DeliveryRepository : IDeliveryRepository
{
    private readonly DeliverymanCastingDbContext _dbContext;

    public DeliveryRepository(DeliverymanCastingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Result> AddDelivery(DeliveryDto employee)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteDelivery(int deliveryId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<DeliveryDto>>> GetAllDeliveries(CancellationToken cancellationToken)
    {
        try
        {
            var deliveries = await _dbContext.Deliveries
                .Include(x => x.EndLocation)
                .Include(x => x.StartLocation)
                .Include(x => x.Client)
                .Select(x => new DeliveryDto(x.Id, x.Status, x.Name, new LocationModel(x.StartLocation), new LocationModel(x.EndLocation), x.PickedUpTime, x.FinishedDeliveryTime, x.Client.Id))
                .ToArrayAsync(cancellationToken);
            return Result.Ok<IEnumerable<DeliveryDto>>(deliveries);
        }
        catch
        {
            return Result.Fail<IEnumerable<DeliveryDto>>("Failed to recieve data");
        }
    }

    public async Task<Result<DeliveryDto>> GetDelivery(int deliveryId, CancellationToken cancellationToken)
    {
        try
        {
            var delivery = await _dbContext.Deliveries
                .Include(x => x.EndLocation)
                .Include(x => x.StartLocation)
                .Include(x => x.Client)
                .Where(x => x.Id == deliveryId)
                .Select(x => new DeliveryDto(x.Id, x.Status, x.Name, new LocationModel(x.StartLocation), new LocationModel(x.EndLocation), x.PickedUpTime, x.FinishedDeliveryTime, x.Client.Id))
                .FirstOrDefaultAsync(cancellationToken);
            if (delivery is null)
                return Result.Fail<DeliveryDto>("Delivery not found");
            else
                return Result.Ok(delivery);
        }
        catch
        {
            return Result.Fail<DeliveryDto>("Failed to recieve data");
        }
    }

    public Task<Result> UpdateDelivery(DeliveryDto employee)
    {
        throw new NotImplementedException();
    }
}
