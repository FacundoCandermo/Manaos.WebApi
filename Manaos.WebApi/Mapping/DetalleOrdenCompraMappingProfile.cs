using AutoMapper;
using Manaos.Application.Dtos.DetalleOrdenCompra;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class DetalleOrdenCompraMappingProfile : Profile
    {
        public DetalleOrdenCompraMappingProfile()
        {
            CreateMap<DetalleOrdenCompra, DetalleOrdenCompraResponseDto>();
            CreateMap<DetalleOrdenCompraRequestDto, DetalleOrdenCompra>()
                .AfterMap((src, dest) =>
                {
                    dest.SetCantidad(src.Cantidad);
                    dest.SetPrecioUnitario(src.PrecioUnitario);
                    dest.SetSubtotal();
                });
        }
    }
}
