using Manaos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.Pedido
{
    public class PedidoRequestDto
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public EstadoPedido Estado { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; }
        public int IdBodegaOrigen { get; set; }
    }
}
