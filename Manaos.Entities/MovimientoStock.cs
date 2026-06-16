using Manaos.Abstractions;
using Manaos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manaos.Entities
{
    public class MovimientoStock : IEntidad
    {
        #region Properties
        public MovimientoStock() { }
        public int Id { get; set; }
        [ForeignKey(nameof(Producto))]
        public int IdProducto { get; set; }
        [ForeignKey(nameof(Bodega))]
        public int IdBodega { get; set; }
        public TipoMovimientoStock Tipo { get; set; }
        public int Cantidad { get; private set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [StringLength(300)]
        public string? Observaciones { get; private set; }
        #endregion

        #region Virtual
        public virtual Producto Producto { get; set; }
        public virtual Bodega Bodega { get; set; }
        #endregion

        #region setters y getters
        public void SetCantidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0.");
            Cantidad = cantidad;
        }

        public void SetObservaciones(string? observaciones)
        {
            if (observaciones != null && string.IsNullOrWhiteSpace(observaciones))
                throw new ArgumentException("Las observaciones no pueden estar vacías.");
            Observaciones = observaciones;
        }
        #endregion
    }
}
