using AutoMapper;
using Manaos.Application.Dtos.DetalleSolicitudReposicion;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class DetalleSolicitudReposicionMappingProfile : Profile
    {
        public DetalleSolicitudReposicionMappingProfile()
        {
            CreateMap<DetalleSolicitudReposicion, DetalleSolicitudReposicionResponseDto>();
            CreateMap<DetalleSolicitudReposicionRequestDto, DetalleSolicitudReposicion>()
                .AfterMap((src, dest) => dest.SetCantidad(src.Cantidad));
        }
    }
}
