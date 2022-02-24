#nullable disable
using AutoMapper;
using InspectionApi.DTOs;
using InspectionApi.Interfaces;
using InspectionApi.Models;
using InspectionApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InspectionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;
        public StatusController(IStatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;

         }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _statusService.GetStatusesAsync();
            return Ok(data);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(StatusViewModel statusViewModel)
        {
            var dto = _mapper.Map<StatusDto>(statusViewModel);
            var data = await _statusService.AddStatusAsync(dto);

            return Ok(data);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdteAsync(StatusViewModel statusViewModel)
        {
            var dto = _mapper.Map<StatusDto>(statusViewModel);
            var data = await _statusService.UpdateStatusAsync(dto);

            if (data == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _statusService.DeleteStatusAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
