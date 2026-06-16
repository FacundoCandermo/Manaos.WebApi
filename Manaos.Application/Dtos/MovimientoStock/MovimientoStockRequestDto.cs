using Manaos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.MovimientoStock
{
    public class MovimientoStockRequestDto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdBodega { get; set; }
        public TipoMovimientoStock Tipo { get; set; }
        public int Cantidad { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [StringLength(300)]
        public string? Observaciones { get; set; }
    }
}
