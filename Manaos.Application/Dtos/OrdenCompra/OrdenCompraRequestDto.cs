using Manaos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.OrdenCompra
{
    public class OrdenCompraRequestDto
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public EstadoOrdenCompra Estado { get; set; }
        public decimal Total { get; set; }
        public int IdProveedor { get; set; }
        public int IdBodegaDestino { get; set; }
    }
}
