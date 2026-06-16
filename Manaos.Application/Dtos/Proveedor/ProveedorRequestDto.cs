using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.Proveedor
{
    public class ProveedorRequestDto
    {
        [DefaultValue("Manaos Fábrica Central")]
        public string Nombre { get; set; }
        [DefaultValue("30-99887766-5")]
        public string? Cuit { get; set; }
        [DefaultValue("011-4555-7800")]
        public string? Telefono { get; set; }
        [DefaultValue("ventas@manaos.com.ar")]
        public string? Email { get; set; }
        [DefaultValue("Ruta 3 Km 45, Cañuelas")]
        public string? Direccion { get; set; }
    }
}
