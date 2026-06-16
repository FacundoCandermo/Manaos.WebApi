using Manaos.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manaos.Entities
{
    public class DetalleOrdenCompra : IEntidad
    {
        #region Properties
        public DetalleOrdenCompra() { }
        public int Id { get; set; }
        [ForeignKey(nameof(OrdenCompra))]
        public int IdOrdenCompra { get; set; }
        [ForeignKey(nameof(Producto))]
        public int IdProducto { get; set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal Subtotal { get; private set; }
        #endregion

        #region Virtual
        public virtual OrdenCompra OrdenCompra { get; set; }
        public virtual Producto Producto { get; set; }
        #endregion

        #region setters y getters
        public void SetCantidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0.");
            Cantidad = cantidad;
        }

        public void SetPrecioUnitario(decimal precioUnitario)
        {
            if (precioUnitario < 0)
                throw new ArgumentException("El precio debe ser mayor a 0.");
            PrecioUnitario = precioUnitario;
        }

        public void SetSubtotal()
        {
            if (this.Cantidad <= 0 || this.PrecioUnitario < 0)
                throw new ArgumentException("Para realizar el cálculo es necesario cargar la cantidad y el precio unitario.");
            Subtotal = this.Cantidad * this.PrecioUnitario;
        }
        #endregion
    }
}
