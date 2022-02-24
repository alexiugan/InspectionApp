using AutoMapper;
using InspectionApi.DTOs;
using InspectionApi.Interfaces;
using InspectionApi.Interfaces.Repositories;

namespace InspectionApi.Services
{
    public class InspectionTypeService : IInspectionTypeService
    {
        private readonly IInspectionTypeRepository _inspectionTypeRepository;
        private readonly IMapper _mapper;
        public InspectionTypeService(IInspectionTypeRepository inspectionTypeRepository, IMapper mapper)
        {
            _inspectionTypeRepository = inspectionTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<InspectionType>> GetInspectionTypesAsync()
        {
            return await _inspectionTypeRepository.GetInspectionTypesAsync();
        }

        public async Task<int> AddInspectionTypeAsync(InspectionTypeDto inspectionTypeDto)
        {
            var inspectionType = _mapper.Map<InspectionType>(inspectionTypeDto);
            return await _inspectionTypeRepository.AddInspectionTypeAsync(inspectionType);
        }

        public async Task<InspectionType?> UpdateInspectionTypeAsync(InspectionTypeDto inspectionTypeDto)
        {
            var inspectionType = _mapper.Map<InspectionType>(inspectionTypeDto);
            var data = await _inspectionTypeRepository.GetByIdAsync(inspectionType.Id);

            if (data == null)
            {
                return null;
            }

            UpdateInspectionType(data, inspectionType);
            return await _inspectionTypeRepository.UpdateInspectionTypeAsync(inspectionType);
        }
        public async Task<int?> DeleteInspectionTypeAsync(int id)
        {
            var data = await _inspectionTypeRepository.GetByIdAsync(id);

            if (data == null)
            {
                return null;
            }

            return await _inspectionTypeRepository.DeleteInspectionTypeAsync(data);
        }

        private static void UpdateInspectionType(
            InspectionType oldInspectionType,
            InspectionType newInspectionType)
        {
            oldInspectionType.InspectionName = newInspectionType.InspectionName;
        }
    }
}
