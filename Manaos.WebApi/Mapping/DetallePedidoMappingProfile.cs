using AutoMapper;
using Manaos.Application.Dtos.DetallePedido;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class DetallePedidoMappingProfile : Profile
    {
        public DetallePedidoMappingProfile()
        {
            CreateMap<DetallePedido, DetallePedidoResponseDto>();
            CreateMap<DetallePedidoRequestDto, DetallePedido>()
                .AfterMap((src, dest) =>
                {
                    dest.SetCantidad(src.Cantidad);
                    dest.SetPrecioUnitario(src.PrecioUnitario);
                    dest.SetSubtotal();
                });
        }
    }
}
