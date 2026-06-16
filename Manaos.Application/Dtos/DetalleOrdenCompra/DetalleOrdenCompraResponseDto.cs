namespace Manaos.Application.Dtos.DetalleOrdenCompra
{
    public class DetalleOrdenCompraResponseDto
    {
        public int Id { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
