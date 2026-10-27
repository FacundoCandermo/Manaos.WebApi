using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.Cliente
{
    public class ClienteRequestDto
    {
        [StringLength(100)]
        [DefaultValue("Kiosco El Centro")]
        public string Nombre { get; set; }
        [StringLength(13)]
        [DefaultValue("20-12345678-9")]
        public string? Cuit { get; set; }
        [StringLength(30)]
        [DefaultValue("2227-555123")]
        public string? Telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        [DefaultValue("contacto@kioscocentro.com.ar")]
        public string? Email { get; set; }
        [StringLength(200)]
        [DefaultValue("San Martín 450, Lobos")]
        public string? Direccion { get; set; }
    }
}
