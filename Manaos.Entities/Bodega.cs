using Manaos.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Entities
{
    public class Bodega : IEntidad, IClassMethods
    {
        public Bodega()
        {
            StocksBodegas = new HashSet<StockBodega>();
            MovimientosStock = new HashSet<MovimientoStock>();
        }

        public Bodega(string nombre)
        {
            SetNombre(nombre);
        }

        #region Properties
        public int Id { get; set; }
        [StringLength(100)]
        public string Nombre { get; private set; }
        [StringLength(200)]
        public string? Direccion { get; private set; }
        #endregion

        #region Virtual
        public virtual ICollection<StockBodega> StocksBodegas { get; set; }
        public virtual ICollection<MovimientoStock> MovimientosStock { get; set; }
        #endregion

        #region setters y getters
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la bodega no puede estar vacío.");
            Nombre = nombre;
        }

        public void SetDireccion(string? direccion)
        {
            if (direccion != null && string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección de la bodega no puede estar vacía.");
            Direccion = direccion;
        }

        public string GetClassName()
        {
            return string.Join(": ", this.GetType().BaseType.Name, Nombre);
        }
        #endregion
    }
}
