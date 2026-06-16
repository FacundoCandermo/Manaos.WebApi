namespace Manaos.Application.Dtos.StockBodega
{
    public class StockBodegaResponseDto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdBodega { get; set; }
        public int Cantidad { get; set; }
        public int StockMinimo { get; set; }
    }
}
