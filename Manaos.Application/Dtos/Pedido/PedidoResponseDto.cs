namespace Manaos.Application.Dtos.Pedido
{
    public class PedidoResponseDto
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; }
        public int IdBodegaOrigen { get; set; }
    }
}
