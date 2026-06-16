using AutoMapper;
using Manaos.Application.Dtos.CategoriaProducto;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class CategoriaProductoMappingProfile : Profile
    {
        public CategoriaProductoMappingProfile()
        {
            CreateMap<CategoriaProducto, CategoriaProductoResponseDto>();
            CreateMap<CategoriaProductoRequestDto, CategoriaProducto>();
        }
    }
}
