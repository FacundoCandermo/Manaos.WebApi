using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.CategoriaProducto
{
    public class CategoriaProductoRequestDto
    {
        [StringLength(50)]
        [DefaultValue("Gaseosas")]
        public string Nombre { get; set; }
        [StringLength(200)]
        [DefaultValue("Bebidas con gas, varias variedades")]
        public string? Descripcion { get; set; }
    }
}
