using CourierAPI.Data;
using CourierAPI.Helpers;
using CourierAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CourierAPI.Services;

public interface IInquiryRepository
{
	public Task<Result<IEnumerable<InquiryDTO>>> GetAllInquiries(CancellationToken cancellationToken);
	public Task<Result<InquiryDTO>> GetById(int inquiryId, CancellationToken cancellationToken);
	public Task<Result> AddInquiry(InquiryDTO inquiry);
	public Task<Result> Update(InquiryDTO inquiry);
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
					x.Name, new LocationDTO(x.StartLocation!),
					new LocationDTO(x.EndLocation!),
					x.HightPriority, x.WeekendDelivery, x.Id, x.InquiryStatus))
				.ToListAsync(cancellationToken);

			return Result.Ok<IEnumerable<InquiryDTO>>(inquiries);
		}
		catch (Exception ex)
		{
			return Result.Fail<IEnumerable<InquiryDTO>>($"Failed to recieve data: {ex.Message}");
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
		catch
		{
			// Log the exception
			return Result.Fail("Failed to add inquiry.");
		}
	}

	public async Task<Result<InquiryDTO>> GetById(int inquiryId, CancellationToken cancellationToken)
	{
		try
		{
			var inquiry = await _dbContext.Inquiries
				.Include(x => x.StartLocation)
				.Include(x => x.EndLocation)
				.Where(x => x.Id == inquiryId)
				.Select(x => new InquiryDTO())
				.FirstOrDefaultAsync(cancellationToken);
			if (inquiry == null)
				return Result.Fail<InquiryDTO>("Inquiry not found.");
			else
				return Result.Ok(inquiry);

		}
		catch
		{
			return Result.Fail<InquiryDTO>("Error while trying to get inquiry by id from database.");
		}
	}

	public async Task<Result> Update(InquiryDTO inquiry)
    {
        try
        {
            var existingInquiry = await _dbContext.Inquiries
                .FirstOrDefaultAsync(x => x.Id == inquiry.Id);

            if (existingInquiry == null)
                return Result.Fail("Inquiry not found.");

			Inquiry data = new Inquiry(inquiry);

            _dbContext.Inquiries.Update(data);
            await _dbContext.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error while trying to update inquiry in the database: {ex}");
        }
    }
}
