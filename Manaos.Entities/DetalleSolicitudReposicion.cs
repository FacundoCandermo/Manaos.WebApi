using Manaos.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manaos.Entities
{
    public class DetalleSolicitudReposicion : IEntidad
    {
        public DetalleSolicitudReposicion() { }
        public int Id { get; set; }
        [ForeignKey(nameof(SolicitudReposicion))]
        public int IdSolicitudReposicion { get; set; }
        [ForeignKey(nameof(Producto))]
        public int IdProducto { get; set; }
        public int Cantidad { get; private set; }

        public virtual SolicitudReposicion SolicitudReposicion { get; set; }
        public virtual Producto Producto { get; set; }

        public void SetCantidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0.");
            Cantidad = cantidad;
        }
    }
}
