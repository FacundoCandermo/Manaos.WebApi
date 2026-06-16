using AutoMapper;
using Manaos.Application.Dtos.StockBodega;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class StockBodegaMappingProfile : Profile
    {
        public StockBodegaMappingProfile()
        {
            CreateMap<StockBodega, StockBodegaResponseDto>();
            CreateMap<StockBodegaRequestDto, StockBodega>()
                .AfterMap((src, dest) =>
                {
                    dest.SetCantidad(src.Cantidad);
                    dest.SetStockMinimo(src.StockMinimo);
                });
        }
    }
}
