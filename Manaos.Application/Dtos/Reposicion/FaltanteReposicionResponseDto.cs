namespace Manaos.Application.Dtos.Reposicion
{
    public class FaltanteReposicionResponseDto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdBodega { get; set; }
        public string NombreBodega { get; set; }
        public int Cantidad { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int CantidadPendiente { get; set; }
        public int CantidadSugerida { get; set; }
    }
}
