using AutoMapper;
using Manaos.Application.Dtos.Proveedor;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class ProveedorMappingProfile : Profile
    {
        public ProveedorMappingProfile()
        {
            CreateMap<Proveedor, ProveedorResponseDto>();
            CreateMap<ProveedorRequestDto, Proveedor>()
                .ConstructUsing(dto => new Proveedor(dto.Nombre))
                .AfterMap((src, dest) =>
                {
                    dest.SetCuit(src.Cuit);
                    dest.SetTelefono(src.Telefono);
                    dest.SetEmail(src.Email);
                    dest.SetDireccion(src.Direccion);
                });
        }
    }
}
