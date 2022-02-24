using AutoMapper;
using InspectionApi.DTOs;
using InspectionApi.Interfaces;
using InspectionApi.Interfaces.Repositories;
using InspectionApi.Models;

namespace InspectionApi.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        public StatusService(IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<List<Status>> GetStatusesAsync()
        {
            return await _statusRepository.GetStatusesAsync();
        }

        public async Task<int> AddStatusAsync(StatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);
            return await _statusRepository.AddStatusAsync(status);
        }

        public async Task<Status?> UpdateStatusAsync(StatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);
            var data = await _statusRepository.GetByIdAsync(status.Id);

            if (data == null)
            {
                return null;
            }

            UpdateStatus(data, status);
            return await _statusRepository.UpdateStatusAsync(status);
        }
        public async Task<int?> DeleteStatusAsync(int id)
        {
            var data = await _statusRepository.GetByIdAsync(id);

            if (data == null)
            {
                return null;
            }

            return await _statusRepository.DeleteStatusAsync(data);
        }

        private static void UpdateStatus(Status oldStatus, Status newStatus)
        {
            oldStatus.StatusOption = newStatus.StatusOption;
        }
    }
}
