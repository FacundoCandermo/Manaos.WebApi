using AutoMapper;
using Manaos.Application.Dtos.Producto;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class ProductoMappingProfile : Profile
    {
        public ProductoMappingProfile()
        {
            CreateMap<Producto, ProductoResponseDto>();
            CreateMap<ProductoRequestDto, Producto>();
        }
    }
}
