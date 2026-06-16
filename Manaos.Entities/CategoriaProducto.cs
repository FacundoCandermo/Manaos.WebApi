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
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(200)]
        public string? Descripcion { get; set; }
      

        public virtual ICollection<Producto> Productos { get; set; }

        public string GetClassName()
        {
            return string.Join(": ", this.GetType().BaseType.Name, Nombre);
        }
    }
}
