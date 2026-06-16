using AutoMapper;
using Manaos.Application.Dtos.MovimientoStock;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class MovimientoStockMappingProfile : Profile
    {
        public MovimientoStockMappingProfile()
        {
            CreateMap<MovimientoStock, MovimientoStockResponseDto>()
                .ForMember(dest => dest.Fecha, ori => ori.MapFrom(src => src.Fecha.ToShortDateString()))
                .ForMember(dest => dest.Tipo, ori => ori.MapFrom(src => src.Tipo.ToString()));
            CreateMap<MovimientoStockRequestDto, MovimientoStock>()
                .AfterMap((src, dest) =>
                {
                    dest.SetCantidad(src.Cantidad);
                    dest.SetObservaciones(src.Observaciones);
                });
        }
    }
}
