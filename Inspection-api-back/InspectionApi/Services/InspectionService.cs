using AutoMapper;
using InspectionApi.DTOs;
using InspectionApi.Interfaces;
using InspectionApi.Interfaces.Repositories;
using InspectionApi.Models;

namespace InspectionApi.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;

        public InspectionService(IInspectionRepository inspectionRepository, IMapper mapper)
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
         }

        public async Task<List<Inspection>> GetInspectionsAsync()
        {
            return await _inspectionRepository.GetInspectionsAsync();
        }

        public async Task<int> AddInspectionAsync(InspectionDto inspectionDto)
        {
            var inspection = _mapper.Map<Inspection>(inspectionDto);
            return await _inspectionRepository.AddInspectionAsync(inspection);
        }

        public async Task<Inspection?> UpdateInspectionAsync(InspectionDto inspectionDto)
        {
            var inspection = _mapper.Map<Inspection>(inspectionDto);
            var data = await _inspectionRepository.GetByIdAsync(inspection.Id);

            if (data == null)
            {
                return null;
            }

            UpdateInspection(data, inspection);
            return await _inspectionRepository.UpdateInspectionAsync(inspection);
        }
        public async Task<int?> DeleteInspectionAsync(int id)
        {
            var data = await _inspectionRepository.GetByIdAsync(id);

            if (data == null)
            {
                return null;
            }

            return await _inspectionRepository.DeleteInspectionAsync(data);
        }

        private static void UpdateInspection(Inspection oldInspection, Inspection newInspection)
        {
            oldInspection.InspectionTypeId = newInspection.InspectionTypeId;
            oldInspection.Comments = newInspection.Comments;
            oldInspection.Status = newInspection.Status;
        }
    }
}
