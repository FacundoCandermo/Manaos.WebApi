namespace Manaos.Application.Dtos.MovimientoStock
{
    public class MovimientoStockResponseDto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdBodega { get; set; }
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public string Fecha { get; set; }
        public string? Observaciones { get; set; }
    }
}
