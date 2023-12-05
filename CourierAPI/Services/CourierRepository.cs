using CourierAPI.Models;
using CourierAPI.Helpers;
using System.Threading;
using Microsoft.Extensions.Primitives;
using Microsoft.EntityFrameworkCore;
using CourierAPI.Data;

namespace CourierAPI.Services
{
	public interface ICourierRepository
	{
		public Task<Result<CourierDTO>> GetBestCourier(string start, string end, string highPriority, string dayOfWeek, CancellationToken cancellationToken);
	}

	public class CourierRepository : ICourierRepository
	{
		private readonly DeliverymanCastingDbContext _dbContext;

		public CourierRepository(DeliverymanCastingDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Result<CourierDTO>> GetBestCourier(string start, string end, string highPriority, string dayOfWeek, CancellationToken cancellationToken)
		{
			try
			{
				bool highPriorityBool = bool.Parse(highPriority);
				var courier = await _dbContext.Couriers
					.Where(c =>
						((c.Start == start && c.End == end) ||
						(c.Start == end && c.End == start)) &&
						(((dayOfWeek == "6" || dayOfWeek == "0") && c.CzyWeekend) ||
						(dayOfWeek != "6" && dayOfWeek != "0")) &&
						c.Workload < c.MaxPackages
						)
					.OrderBy(c => highPriorityBool ? c.CenaHighPriority : c.Cena)
					.Select(c => new CourierDTO
					{
						Id = c.Id,
						Start = c.Start,
						End = c.End,
						Cena = c.Cena,
						CenaHighPriority = c.CenaHighPriority,
						CzyWeekend = c.CzyWeekend,
						Workload = c.Workload,
						MaxPackages = c.MaxPackages
					})
					.FirstOrDefaultAsync(cancellationToken);


				if (courier is null)
					return Result.Fail<CourierDTO>("Delivery not found");
				else
					return Result.Ok(courier);
			} catch (Exception e)
			{
				return Result.Fail<CourierDTO>("Failed to recieve data");
			}

			throw new NotImplementedException();
		}
	}
}
