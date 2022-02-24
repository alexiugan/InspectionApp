#nullable disable
using AutoMapper;
using InspectionApi.DTOs;
using InspectionApi.Interfaces;
using InspectionApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InspectionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InspectionTypesController : Controller
    {
        private readonly IInspectionTypeService _inspectionTypeService;
        private readonly IMapper _mapper;
        public InspectionTypesController(IInspectionTypeService inspectionTypeService, IMapper mapper)
        {
            _inspectionTypeService = inspectionTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _inspectionTypeService.GetInspectionTypesAsync();
            return Ok(data);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(InspectionTypeViewModel inspectionTypeViewModel)
        {
            var dto = _mapper.Map<InspectionTypeDto>(inspectionTypeViewModel);
            var data = await _inspectionTypeService.AddInspectionTypeAsync(dto);

            return Ok(data);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdteAsync(InspectionTypeViewModel inspectionTypeViewModel)
        {
            var dto = _mapper.Map<InspectionTypeDto>(inspectionTypeViewModel);
            var data = await _inspectionTypeService.UpdateInspectionTypeAsync(dto);

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
            var data = await _inspectionTypeService.DeleteInspectionTypeAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
