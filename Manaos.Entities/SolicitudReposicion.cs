using Manaos.Abstractions;
using Manaos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Entities
{
    public class SolicitudReposicion : IEntidad, IClassMethods
    {
        public SolicitudReposicion()
        {
            DetallesSolicitudReposicion = new HashSet<DetalleSolicitudReposicion>();
        }

        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public EstadoSolicitudReposicion Estado { get; set; }
        [StringLength(500)]
        public string? Observaciones { get; private set; }

        public virtual ICollection<DetalleSolicitudReposicion> DetallesSolicitudReposicion { get; set; }

        public void SetObservaciones(string? observaciones)
        {
            if (observaciones != null && string.IsNullOrWhiteSpace(observaciones))
                throw new ArgumentException("Las observaciones no pueden estar vacías.");
            Observaciones = observaciones;
        }

        public string GetClassName()
        {
            return string.Join(": ", this.GetType().BaseType.Name, Estado.ToString());
        }
    }
}
