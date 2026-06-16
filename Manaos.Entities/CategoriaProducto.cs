using Manaos.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Entities
{
    public class CategoriaProducto : IEntidad, IClassMethods
    {
        public CategoriaProducto()
        {
            Productos = new HashSet<Producto>();
        }
        #region Properties
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(200)]
        public string? Descripcion { get; set; }
        #endregion

        #region Virtual
        public virtual ICollection<Producto> Productos { get; set; }
        #endregion

        #region setters y getters
        public string GetClassName()
        {
            return string.Join(": ", this.GetType().BaseType.Name, Nombre);
        }
        #endregion
    }
}
