using InspectionApi.Data;
using InspectionApi.Interfaces.Repositories;
using InspectionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionApi.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DataContext _context;

        public StatusRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> GetStatusesAsync()
        {
            return await _context.Statuses.AsNoTracking().ToListAsync();
        }

        public async Task<int> AddStatusAsync(Status status)
        {
            var data = await _context.Statuses.AddAsync(status);
            await _context.SaveChangesAsync();

            return data.Entity.Id;
        }

        public async Task<Status?> UpdateStatusAsync(Status status)
        {
            var data = _context.Statuses.Update(status);
            await _context.SaveChangesAsync();

            return data.Entity;
        }

        public async Task<int> DeleteStatusAsync(Status status)
        {
            var data = _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return data.Entity.Id;
        }

        public async Task<Status?> GetByIdAsync(int id)
        {
            return await _context.Statuses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
