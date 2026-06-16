namespace Manaos.Application.Dtos.Producto
{
    public class ProductoResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdCategoriaProducto { get; set; }
    }
}
