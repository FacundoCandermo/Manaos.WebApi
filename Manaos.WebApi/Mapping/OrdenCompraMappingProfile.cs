using AutoMapper;
using Manaos.Application.Dtos.OrdenCompra;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class OrdenCompraMappingProfile : Profile
    {
        public OrdenCompraMappingProfile()
        {
            CreateMap<OrdenCompra, OrdenCompraResponseDto>()
                .ForMember(dest => dest.Fecha, ori => ori.MapFrom(src => src.Fecha.ToShortDateString()))
                .ForMember(dest => dest.Estado, ori => ori.MapFrom(src => src.Estado.ToString()));
            CreateMap<OrdenCompraRequestDto, OrdenCompra>()
                .AfterMap((src, dest) => dest.SetTotal(src.Total));
        }
    }
}
