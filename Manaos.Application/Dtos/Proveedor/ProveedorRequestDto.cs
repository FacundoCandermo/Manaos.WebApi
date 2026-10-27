using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.Proveedor
{
    public class ProveedorRequestDto
    {
        [StringLength(100)]
        [DefaultValue("Manaos Fábrica Central")]
        public string Nombre { get; set; }
        [StringLength(13)]
        [DefaultValue("30-99887766-5")]
        public string? Cuit { get; set; }
        [StringLength(30)]
        [DefaultValue("011-4555-7800")]
        public string? Telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        [DefaultValue("ventas@manaos.com.ar")]
        public string? Email { get; set; }
        [StringLength(200)]
        [DefaultValue("Ruta 3 Km 45, Cañuelas")]
        public string? Direccion { get; set; }
    }
}
