using InspectionApi.DTOs;

namespace InspectionApi.Interfaces
{
    public interface IInspectionTypeService
    {
        Task<List<InspectionType>> GetInspectionTypesAsync();
        Task<int> AddInspectionTypeAsync(InspectionTypeDto inspectionTypeDto);
        Task<InspectionType?> UpdateInspectionTypeAsync(InspectionTypeDto inspectionTypeDto);
        Task<int?> DeleteInspectionTypeAsync(int id);
    }
}
