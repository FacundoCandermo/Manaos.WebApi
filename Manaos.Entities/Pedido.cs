using Manaos.Abstractions;
using Manaos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manaos.Entities
{
    public class Pedido : IEntidad, IClassMethods
    {
        public Pedido()
        {
            DetallesPedido = new HashSet<DetallePedido>();
        }

        #region Properties
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public EstadoPedido Estado { get; set; }
        public decimal Total { get; private set; }
        [ForeignKey(nameof(Cliente))]
        public int IdCliente { get; set; }
        [ForeignKey(nameof(BodegaOrigen))]
        public int IdBodegaOrigen { get; set; }
        #endregion

        #region Virtual
        public virtual Cliente Cliente { get; set; }
        public virtual Bodega BodegaOrigen { get; set; }
        public virtual ICollection<DetallePedido> DetallesPedido { get; set; }
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
