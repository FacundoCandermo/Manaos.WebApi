using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.Producto
{
    public class ProductoRequestDto
    {
        [DefaultValue("Manaos Cola 2.25L")]
        public string Nombre { get; set; }
        [DefaultValue("Gaseosa sabor cola, botella retornable")]
        public string? Descripcion { get; set; }
        [DefaultValue(1250.00)]
        public decimal Precio { get; set; }
        [DefaultValue(1)]
        public int IdCategoriaProducto { get; set; }
    }
}
