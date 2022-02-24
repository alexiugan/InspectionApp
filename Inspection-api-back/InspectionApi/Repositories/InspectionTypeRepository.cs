using InspectionApi.Data;
using InspectionApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InspectionApi.Repositories
{
    public class InspectionTypeRepository : IInspectionTypeRepository
    {
        private readonly DataContext _context;

        public InspectionTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<InspectionType>> GetInspectionTypesAsync()
        {
            return await _context.InspectionTypes.AsNoTracking().ToListAsync();
        }

        public async Task<int> AddInspectionTypeAsync(InspectionType inspectionType)
        {
            var data = await _context.InspectionTypes.AddAsync(inspectionType);
            await _context.SaveChangesAsync();

            return data.Entity.Id;
        }

        public async Task<InspectionType?> UpdateInspectionTypeAsync(InspectionType inspectionType)
        {
            var data = _context.InspectionTypes.Update(inspectionType);
            await _context.SaveChangesAsync();

            return data.Entity;
        }

        public async Task<int> DeleteInspectionTypeAsync(InspectionType inspectionType)
        {
            var data = _context.InspectionTypes.Remove(inspectionType);
            await _context.SaveChangesAsync();

            return data.Entity.Id;
        }

        public async Task<InspectionType?> GetByIdAsync(int id)
        {
            return await _context.InspectionTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
