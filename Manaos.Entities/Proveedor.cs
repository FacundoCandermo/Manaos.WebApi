using Manaos.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Entities
{
    public class Proveedor : IEntidad, IClassMethods
    {
        public Proveedor()
        {
            OrdenesCompra = new HashSet<OrdenCompra>();
        }

        public Proveedor(string nombre)
        {
            SetNombre(nombre);
        }

        #region Properties
        public int Id { get; set; }
        [StringLength(100)]
        public string Nombre { get; private set; }
        [StringLength(13)]
        public string? Cuit { get; private set; }
        [StringLength(30)]
        public string? Telefono { get; private set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; private set; }
        [StringLength(200)]
        public string? Direccion { get; private set; }
        #endregion

        #region Virtual
        public virtual ICollection<OrdenCompra> OrdenesCompra { get; set; }
        #endregion

        #region setters y getters
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del proveedor no puede estar vacío.");
            Nombre = nombre;
        }

        public void SetCuit(string? cuit)
        {
            if (cuit != null && string.IsNullOrWhiteSpace(cuit))
                throw new ArgumentException("El CUIT del proveedor no puede estar vacío.");
            Cuit = cuit;
        }

        public void SetTelefono(string? telefono)
        {
            if (telefono != null && string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono del proveedor no puede estar vacío.");
            Telefono = telefono;
        }

        public void SetEmail(string? mail)
        {
            if (mail != null && (string.IsNullOrWhiteSpace(mail) || (!mail.Contains("@") && !mail.Contains(".com"))))
                throw new ArgumentException("El email del proveedor no puede estar vacío o contener un @.");
            Email = mail;
        }

        public void SetDireccion(string? direccion)
        {
            if (direccion != null && string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección del proveedor no puede estar vacía.");
            Direccion = direccion;
        }

        public string GetClassName()
        {
            return string.Join(": ", this.GetType().BaseType.Name, Nombre);
        }
        #endregion
    }
}
