using AutoMapper;
using Manaos.Application.Dtos.Cliente;
using Manaos.Entities;

namespace Manaos.WebApi.Mapping
{
    public class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            CreateMap<Cliente, ClienteResponseDto>();
            CreateMap<ClienteRequestDto, Cliente>()
                .ConstructUsing(dto => new Cliente(dto.Nombre))
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
