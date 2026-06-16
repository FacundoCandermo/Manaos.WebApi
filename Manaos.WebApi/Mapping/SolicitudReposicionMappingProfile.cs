using AutoMapper;
using Manaos.Application.Dtos.SolicitudReposicion;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class SolicitudReposicionMappingProfile : Profile
    {
        public SolicitudReposicionMappingProfile()
        {
            CreateMap<SolicitudReposicion, SolicitudReposicionResponseDto>()
                .ForMember(dest => dest.Fecha, ori => ori.MapFrom(src => src.Fecha.ToShortDateString()))
                .ForMember(dest => dest.Estado, ori => ori.MapFrom(src => src.Estado.ToString()));
            CreateMap<SolicitudReposicionRequestDto, SolicitudReposicion>()
                .AfterMap((src, dest) => dest.SetObservaciones(src.Observaciones));
        }
    }
}
