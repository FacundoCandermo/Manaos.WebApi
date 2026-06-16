using Manaos.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manaos.Entities
{
    public class DetallePedido : IEntidad
    {
        #region Properties
        public DetallePedido() { }
        public int Id { get; set; }
        [ForeignKey(nameof(Pedido))]
        public int IdPedido { get; set; }
        [ForeignKey(nameof(Producto))]
        public int IdProducto { get; set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal Subtotal { get; private set; }
        #endregion

        #region Virtual
        public virtual Pedido Pedido { get; set; }
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
