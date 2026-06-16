namespace Manaos.Application.Dtos.OrdenCompra
{
    public class OrdenCompraResponseDto
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public int IdProveedor { get; set; }
        public int IdBodegaDestino { get; set; }
    }
}
