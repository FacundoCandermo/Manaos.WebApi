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

        #region Properties
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public EstadoSolicitudReposicion Estado { get; set; }
        [StringLength(500)]
        public string? Observaciones { get; private set; }
        #endregion

        #region Virtual
        public virtual ICollection<DetalleSolicitudReposicion> DetallesSolicitudReposicion { get; set; }
        #endregion

        #region setters y getters
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
        #endregion
    }
}
