using CourierAPI.Data;
using CourierAPI.Helpers;
using CourierAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CourierAPI.Services;

public interface IInquiryRepository
{
	public Task<Result<IEnumerable<InquiryDTO>>> GetAllInquiries(CancellationToken cancellationToken);
	//public Task<Result<DeliveryDto>> GetDelivery(int deliveryId, CancellationToken cancellationToken);
	public Task<Result> AddInquiry(InquiryDTO inquiry);
	//public Task<Result> UpdateDelivery(DeliveryDto employee);
	//public Task<Result> DeleteDelivery(int deliveryId);
}
public class InquiryRepository : IInquiryRepository
{
	private readonly DeliverymanCastingDbContext _dbContext;

	public InquiryRepository(DeliverymanCastingDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	//public Task<Result> AddDelivery(DeliveryDto employee)
	//{
	//    throw new NotImplementedException();
	//}

	//public Task<Result> DeleteDelivery(int deliveryId)
	//{
	//    throw new NotImplementedException();
	//}

	public async Task<Result<IEnumerable<InquiryDTO>>> GetAllInquiries(CancellationToken cancellationToken)
	{
		try
		{
			var inquiries = await _dbContext.Inquiries
				.Include(x => x.StartLocation)
				.Include(x => x.EndLocation)
				.Select(x => new InquiryDTO(
					x.DimX, x.DimY, x.DimZ,
					x.Weight, x.DeliveryDate,
					x.Name, new LocationDTO(x.StartLocation),
					new LocationDTO(x.EndLocation),
					x.HightPriority, x.WeekendDelivery,
					new CourierDTO(x.Courier), x.Id))
				.ToListAsync(cancellationToken);

			return Result.Ok<IEnumerable<InquiryDTO>>(inquiries);
		}
		catch
		{
			return Result.Fail<IEnumerable<InquiryDTO>>("Failed to recieve data");
		}
	}

	public async Task<Result> AddInquiry(InquiryDTO inquiry)
	{
		try
		{
			_dbContext.Inquiries.Add(new Inquiry(inquiry));
			// Save changes to the database
			await _dbContext.SaveChangesAsync();

			return Result.Ok("Inquiry added successfully.");
		}
		catch (Exception ex)
		{
			// Log the exception
			return Result.Fail("Failed to add inquiry.");
		}
	}

	//public async Task<Result<DeliveryDto>> GetDelivery(int deliveryId, CancellationToken cancellationToken)
	//{
	//    try
	//    {
	//        var delivery = await _dbContext.Deliveries
	//            .Include(x => x.EndLocation)
	//            .Include(x => x.StartLocation)
	//            .Include(x => x.Client)
	//            .Where(x => x.Id == deliveryId)
	//            .Select(x => new DeliveryDto(x.Id, x.Status, x.Name, new LocationDTO(x.StartLocation), new LocationDTO(x.EndLocation), x.PickedUpTime, x.FinishedDeliveryTime, x.Client.Id))
	//            .FirstOrDefaultAsync(cancellationToken);
	//        if (delivery is null)
	//            return Result.Fail<DeliveryDto>("Delivery not found");
	//        else
	//            return Result.Ok(delivery);
	//    }
	//    catch
	//    {
	//        return Result.Fail<DeliveryDto>("Failed to recieve data");
	//    }
	//}

	//public Task<Result> UpdateDelivery(DeliveryDto employee)
	//{
	//    throw new NotImplementedException();
	//}
}
