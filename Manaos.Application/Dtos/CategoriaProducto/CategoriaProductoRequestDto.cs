using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.CategoriaProducto
{
    public class CategoriaProductoRequestDto
    {
        [DefaultValue("Gaseosas")]
        public string Nombre { get; set; }
        [DefaultValue("Bebidas con gas, varias variedades")]
        public string? Descripcion { get; set; }
    }
}
