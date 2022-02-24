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
    public class InspectionsController : Controller
    {
        private readonly IInspectionService _inspectionService;
        private readonly IMapper _mapper;

        public InspectionsController(IInspectionService inspectionService, IMapper mapper)
        {
            _inspectionService = inspectionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _inspectionService.GetInspectionsAsync();
            return Ok(data);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(InspectionViewModel inspectionViewModel)
        {
            var dto = _mapper.Map<InspectionDto>(inspectionViewModel);
            var data = await _inspectionService.AddInspectionAsync(dto);

            return Ok(data);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdteAsync(InspectionViewModel inspectionViewModel)
        {
            var dto = _mapper.Map<InspectionDto>(inspectionViewModel);
            var data = await _inspectionService.UpdateInspectionAsync(dto);

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
            var data = await _inspectionService.DeleteInspectionAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
