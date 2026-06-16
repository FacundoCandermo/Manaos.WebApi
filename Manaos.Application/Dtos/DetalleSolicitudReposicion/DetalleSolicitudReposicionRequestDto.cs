namespace Manaos.Application.Dtos.DetalleSolicitudReposicion
{
    public class DetalleSolicitudReposicionRequestDto
    {
        public int Id { get; set; }
        public int IdSolicitudReposicion { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
