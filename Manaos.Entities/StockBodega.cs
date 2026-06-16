using Manaos.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manaos.Entities
{
    public class StockBodega : IEntidad
    {
        #region Properties
        public StockBodega() { }
        public int Id { get; set; }
        [ForeignKey(nameof(Producto))]
        public int IdProducto { get; set; }
        [ForeignKey(nameof(Bodega))]
        public int IdBodega { get; set; }
        public int Cantidad { get; private set; }
        public int StockMinimo { get; private set; }
        #endregion

        #region Virtual
        public virtual Producto Producto { get; set; }
        public virtual Bodega Bodega { get; set; }
        #endregion

        #region setters y getters
        public void SetCantidad(int cantidad)
        {
            if (cantidad < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");
            Cantidad = cantidad;
        }

        public void SetStockMinimo(int stockMinimo)
        {
            if (stockMinimo < 0)
                throw new ArgumentException("El stock mínimo no puede ser negativo.");
            StockMinimo = stockMinimo;
        }
        #endregion
    }
}
