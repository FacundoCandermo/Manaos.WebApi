using AutoMapper;
using Manaos.Application.Dtos.Bodega;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class BodegaMappingProfile : Profile
    {
        public BodegaMappingProfile()
        {
            CreateMap<Bodega, BodegaResponseDto>();
            CreateMap<BodegaRequestDto, Bodega>()
                .ConstructUsing(dto => new Bodega(dto.Nombre))
                .AfterMap((src, dest) => dest.SetDireccion(src.Direccion));
        }
    }
}
