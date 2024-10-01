using AutoMapper;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs;
using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;

namespace Codium.Interview.EmployeeEvidenceApp.Server.Helpers
{
    /// <summary>
    /// Class that contains the mapping between the entities and the DTOs
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Position, PositionDTO>()
                .ForMember(dest => dest.PositionID, opt => opt.MapFrom(src => src.PositionID))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.PositionName));

            CreateMap<PositionDTO, Position>()
                .ForMember(dest => dest.PositionID, opt => opt.MapFrom(src => src.PositionID))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.PositionName));


            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.EployeeID, opt => opt.MapFrom(src => src.EployeeID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.IPCountryCode, opt => opt.MapFrom(src => src.IPCountryCode))
                .ForMember(dest => dest.IPaddress, opt => opt.MapFrom(src => src.IPaddress))
                .ForMember(dest => dest.PositionID, opt => opt.MapFrom(src => src.PositionID));


            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.EployeeID, opt => opt.MapFrom(src => src.EployeeID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.IPCountryCode, opt => opt.MapFrom(src => src.IPCountryCode))
                .ForMember(dest => dest.IPaddress, opt => opt.MapFrom(src => src.IPaddress))
                .ForMember(dest => dest.PositionID, opt => opt.MapFrom(src => src.PositionID));

            CreateMap<Employee, EmployeeListDTO>()
                .ForMember(dest => dest.EployeeID, opt => opt.MapFrom(src => src.EployeeID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate));

            CreateMap<EmployeeListDTO, Employee>()
                .ForMember(dest => dest.EployeeID, opt => opt.MapFrom(src => src.EployeeID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate));



        }
    }
}
