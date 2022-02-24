using InspectionApi.Models;

namespace InspectionApi.Interfaces.Repositories
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetStatusesAsync();
        Task<int> AddStatusAsync(Status status);
        Task<Status?> UpdateStatusAsync(Status status);
        Task<int> DeleteStatusAsync(Status status);
        Task<Status?> GetByIdAsync(int id);
    }
}
