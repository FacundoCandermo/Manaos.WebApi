using Manaos.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manaos.Entities
{
    public class Producto : IEntidad, IClassMethods
    {
        #region Properties
        public int Id { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(300)]
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        [ForeignKey(nameof(CategoriaProducto))]
        public int IdCategoriaProducto { get; set; }
        #endregion

        #region Virtual
        public virtual CategoriaProducto CategoriaProducto { get; set; }
        #endregion

        #region setters y getters
        public string GetClassName()
        {
            return string.Join(": ", this.GetType().BaseType.Name, Nombre);
        }
        #endregion
    }
}
