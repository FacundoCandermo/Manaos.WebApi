using AutoMapper;
using Manaos.Application.Dtos.Pedido;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class PedidoMappingProfile : Profile
    {
        public PedidoMappingProfile()
        {
            CreateMap<Pedido, PedidoResponseDto>()
                .ForMember(dest => dest.Fecha, ori => ori.MapFrom(src => src.Fecha.ToShortDateString()))
                .ForMember(dest => dest.Estado, ori => ori.MapFrom(src => src.Estado.ToString()));
            CreateMap<PedidoRequestDto, Pedido>()
                .AfterMap((src, dest) => dest.SetTotal(src.Total));
        }
    }
}
