using AutoMapper;
using InspectionApi.DTOs;
using InspectionApi.Models;
using InspectionApi.ViewModels;

namespace InspectionApi.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<InspectionViewModel, InspectionDto>();
            CreateMap<InspectionDto, Inspection>();
            CreateMap<InspectionTypeViewModel, InspectionTypeDto>();
            CreateMap<InspectionTypeDto, InspectionType>();
            CreateMap<StatusViewModel, StatusDto>();
            CreateMap<StatusDto, Status>();
        }
    }
}
