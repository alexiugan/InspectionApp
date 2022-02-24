using InspectionApi.DTOs;
using InspectionApi.Models;

namespace InspectionApi.Interfaces
{
    public interface IInspectionService
    {
        Task<List<Inspection>> GetInspectionsAsync();
        Task<int> AddInspectionAsync(InspectionDto inspectionDto);
        Task<Inspection?> UpdateInspectionAsync(InspectionDto inspectionDto);
        Task<int?> DeleteInspectionAsync(int id);
    }
}
