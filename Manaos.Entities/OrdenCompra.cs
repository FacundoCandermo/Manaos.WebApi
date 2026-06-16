using Manaos.Abstractions;
using Manaos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manaos.Entities
{
    public class OrdenCompra : IEntidad, IClassMethods
    {
        public OrdenCompra()
        {
            DetallesOrdenCompra = new HashSet<DetalleOrdenCompra>();
        }

        #region Properties
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public EstadoOrdenCompra Estado { get; set; }
        public decimal Total { get; private set; }
        [ForeignKey(nameof(Proveedor))]
        public int IdProveedor { get; set; }
        [ForeignKey(nameof(BodegaDestino))]
        public int IdBodegaDestino { get; set; }
        #endregion

        #region Virtual
        public virtual Proveedor Proveedor { get; set; }
        public virtual Bodega BodegaDestino { get; set; }
        public virtual ICollection<DetalleOrdenCompra> DetallesOrdenCompra { get; set; }
        #endregion

        #region setters y getters
        public void SetTotal(decimal total)
        {
            if (total < 0)
                throw new ArgumentException("El total no puede ser negativo.");
            Total = total;
        }

        public string GetClassName()
        {
            return string.Join(": ", this.GetType().BaseType.Name, Estado.ToString());
        }
        #endregion
    }
}
