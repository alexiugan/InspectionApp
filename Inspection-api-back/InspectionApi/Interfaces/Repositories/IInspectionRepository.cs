using InspectionApi.Models;

namespace InspectionApi.Interfaces.Repositories
{
    public interface IInspectionRepository
    {
        Task<List<Inspection>> GetInspectionsAsync();
        Task<int> AddInspectionAsync(Inspection inspection);
        Task<Inspection?> UpdateInspectionAsync(Inspection inspection);
        Task<int> DeleteInspectionAsync(Inspection inspection);
        Task<Inspection?> GetByIdAsync(int id);
    }
}
