using ApplicationLayer.DTO;
using ApplicationLayer.EntityToInspect.Commands;
using ApplicationLayer.InspectionVisit.Commands;
using ApplicationLayer.Violation.Commands;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEntityToInspectCommand, Domain.Models.EntityToInspect>();
            CreateMap<Domain.Models.EntityToInspect, EntityDto>();

            CreateMap<UpdateInspectionVisitCommand, Domain.Models.InspectionVisit>();
            CreateMap<CreateInspectionVisitCommand, Domain.Models.InspectionVisit>();

            CreateMap<Domain.Models.InspectionVisit, InspectionVisitQueryDto>()
    .ForMember(dest => dest.EntityToInspectName, opt => opt.MapFrom(src => src.EntityToInspect.Name))
    .ForMember(dest => dest.InspectorName, opt => opt.MapFrom(src => src.Inspector.FullName));





            CreateMap<Domain.Models.InspectionVisit, InspectionVisitDto>()
    .ForMember(dest => dest.EntityToInspectName, opt => opt.MapFrom(src => src.EntityToInspect.Name));


            //CreateMap<Domain.Models.Violation, DTO.ViolationDto>().ReverseMap();
            CreateMap<CreateViolationCommand, Domain.Models.Violation>();
            CreateMap<Domain.Models.Violation, CreateViolationCommand>();


            CreateMap<Domain.Models.InspectionVisit, StatsDto>().ReverseMap();
            CreateMap<Domain.Models.InspectionVisit, UpcomingVisitDto>()
              .ForMember(dest => dest.EntityName, opt => opt.MapFrom(src => src.EntityToInspect.Name))
              .ForMember(dest => dest.InspectorName, opt => opt.MapFrom(src => src.Inspector.FullName));


            CreateMap<Domain.Models.Inspector, InspectorDTO>();

            //CreateMap<Domain.Models.InspectionVisit, DashboardStatsDto>().ReverseMap();

        }
    }
    public class EntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
