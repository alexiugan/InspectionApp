namespace InspectionApi.Interfaces.Repositories
{
    public interface IInspectionTypeRepository
    {
        Task<List<InspectionType>> GetInspectionTypesAsync();
        Task<int> AddInspectionTypeAsync(InspectionType inspectionType);
        Task<InspectionType?> UpdateInspectionTypeAsync(InspectionType inspectionType);
        Task<int> DeleteInspectionTypeAsync(InspectionType inspectionType);
        Task<InspectionType?> GetByIdAsync(int id);
    }
}
