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
					x.Name, new LocationDTO(x.StartLocation),
					new LocationDTO(x.EndLocation),
					x.HightPriority, x.WeekendDelivery,
					new CourierDTO(x.Courier), x.Id, x.InquiryStatus))
				.ToListAsync(cancellationToken);

			return Result.Ok<IEnumerable<InquiryDTO>>(inquiries);
		}
		catch (Exception ex)
		{
			return Result.Fail<IEnumerable<InquiryDTO>>($"Failed to recieve data: {ex.Message}");
		}
	}

	public async Task<Result> AddInquiry(InquiryDTO inquiryDTO)
	{
		try
		{
            // Create new Location and Courier objects
            // Try to find the startLocation and endLocation in the database
            Location startLocation = _dbContext.Locations.FirstOrDefault(l => l.Street == inquiryDTO.StartLocation.Street &&
                                                                            l.StreetNumber == inquiryDTO.StartLocation.StreetNumber &&
                                                                            l.City == inquiryDTO.StartLocation.City &&
                                                                            l.PostCode == inquiryDTO.StartLocation.PostCode &&
                                                                            l.Country == inquiryDTO.StartLocation.Country);

            Location endLocation = _dbContext.Locations.FirstOrDefault(l => l.Street == inquiryDTO.EndLocation.Street &&
                                                                          l.StreetNumber == inquiryDTO.EndLocation.StreetNumber &&
                                                                          l.City == inquiryDTO.EndLocation.City &&
                                                                          l.PostCode == inquiryDTO.EndLocation.PostCode &&
                                                                          l.Country == inquiryDTO.EndLocation.Country);

            // If the startLocation or endLocation do not exist, create new ones
            if (startLocation == null)
            {
                startLocation = new Location(inquiryDTO.StartLocation);
                _dbContext.Locations.Add(startLocation);
            }
            if (endLocation == null)
            {
                endLocation = new Location(inquiryDTO.EndLocation);
                _dbContext.Locations.Add(endLocation);
            }
            Courier courier = await _dbContext.Couriers.FindAsync(inquiryDTO.Courier.Id);

            // Create the new Inquiry with the new entities
            Inquiry inquiry = new Inquiry
            {
                DimX = inquiryDTO.DimX,
                DimY = inquiryDTO.DimY,
                DimZ = inquiryDTO.DimZ,
                Weight = inquiryDTO.Weight,
                DeliveryDate = inquiryDTO.DeliveryDate,
                Name = inquiryDTO.Name,
                StartLocation = startLocation,
                EndLocation = endLocation,
                HightPriority = inquiryDTO.HightPriority,
                Courier = courier,
                WeekendDelivery = inquiryDTO.WeekendDelivery
            };

            // Add the new Inquiry to the DbContext
            _dbContext.Inquiries.Add(inquiry);
            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return Result.Ok("Successfully Added");
        }
		catch (Exception ex)
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
				.Select(x => new InquiryDTO(x))
				.FirstOrDefaultAsync();
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

			existingInquiry.InquiryStatus = data.InquiryStatus;

            await _dbContext.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error while trying to update inquiry in the database: {ex}");
        }
    }
}
