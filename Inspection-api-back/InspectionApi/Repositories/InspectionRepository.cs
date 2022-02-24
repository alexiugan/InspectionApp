using InspectionApi.Data;
using InspectionApi.Interfaces.Repositories;
using InspectionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionApi.Repositories
{
    public class InspectionRepository : IInspectionRepository
    {
        private readonly DataContext _context;

        public InspectionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Inspection>> GetInspectionsAsync()
        {
            return await _context.Inspections.AsNoTracking().ToListAsync();
        }

        public async Task<int> AddInspectionAsync(Inspection inspection)
        {
            var data = await _context.Inspections.AddAsync(inspection);
            await _context.SaveChangesAsync();

            return data.Entity.Id;
        }

        public async Task<Inspection?> UpdateInspectionAsync(Inspection inspection)
        {
            var data = _context.Inspections.Update(inspection);
            await _context.SaveChangesAsync();

            return data.Entity;
        }

        public async Task<int> DeleteInspectionAsync(Inspection inspection)
        {
            var data = _context.Inspections.Remove(inspection);
            await _context.SaveChangesAsync();

            return data.Entity.Id;
        }

        public async Task<Inspection?> GetByIdAsync(int id)
        {
            return await _context.Inspections.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
