using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.Cliente
{
    public class ClienteRequestDto
    {
        [DefaultValue("Kiosco El Centro")]
        public string Nombre { get; set; }
        [DefaultValue("20-12345678-9")]
        public string? Cuit { get; set; }
        [DefaultValue("2227-555123")]
        public string? Telefono { get; set; }
        [DefaultValue("contacto@kioscocentro.com.ar")]
        public string? Email { get; set; }
        [DefaultValue("San Martín 450, Lobos")]
        public string? Direccion { get; set; }
    }
}
