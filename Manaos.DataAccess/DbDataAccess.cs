using Manaos.Entities;
using Manaos.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Manaos.DataAccess
{
    public class DbDataAccess : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriasProductos { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Bodega> Bodegas { get; set; }
        public virtual DbSet<StockBodega> StocksBodegas { get; set; }
        public virtual DbSet<MovimientoStock> MovimientosStock { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<DetallePedido> DetallesPedidos { get; set; }
        public virtual DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public virtual DbSet<DetalleOrdenCompra> DetallesOrdenesCompra { get; set; }
        public virtual DbSet<SolicitudReposicion> SolicitudesReposicion { get; set; }
        public virtual DbSet<DetalleSolicitudReposicion> DetallesSolicitudesReposicion { get; set; }
        public DbDataAccess(DbContextOptions<DbDataAccess> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine).EnableDetailedErrors();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
