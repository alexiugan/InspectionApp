using InspectionApi.DTOs;
using InspectionApi.Models;

namespace InspectionApi.Interfaces
{
    public interface IStatusService
    {
        Task<List<Status>> GetStatusesAsync();
        Task<int> AddStatusAsync(StatusDto statusDto);
        Task<Status?> UpdateStatusAsync(StatusDto statusDto);
        Task<int?> DeleteStatusAsync(int id);
    }
}
