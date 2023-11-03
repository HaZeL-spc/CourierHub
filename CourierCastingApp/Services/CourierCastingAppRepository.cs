using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CourierCastingApp.Services
{
    public interface ICourierCastingAppRepository
    {
        public Task<Result<int>> CountAllSessions();
    }

    public class CourierCastingAppRepository : ICourierCastingAppRepository
    {
        private readonly CourierCastingAppDbContext _dbContext;

        public CourierCastingAppRepository(CourierCastingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<int>> CountAllSessions()
        {
            try
            {
                int recordCount = await _dbContext.SessionHistory.CountAsync();
                return Result.Ok<int>(recordCount);
            }
            catch (Exception ex)
            {
                return Result.Fail<int>($"Failed to receive data: {ex.Message}");
            }
        }
    }
}
