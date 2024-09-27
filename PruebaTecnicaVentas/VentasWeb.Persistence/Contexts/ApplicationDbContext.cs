
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasWeb.Domain.Common;
using VentasWeb.Domain.Entities;

namespace VentasWeb.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        private readonly string _connectionString;
        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Producto> Productos => Set<Producto>();



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Venta>().ToTable("Ventas");
            modelBuilder.Entity<Venta>().HasKey(venta => venta.Id);
            modelBuilder.Entity<Venta>().HasOne(v => v.Cliente).WithMany(c => c.Compras).HasForeignKey(v => v.IdCliente);

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Cliente>().HasKey(cliente => cliente.Id);
            modelBuilder.Entity<Cliente>().HasMany(c => c.Compras).WithOne(v => v.Cliente).HasForeignKey(v => v.IdCliente);

            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Producto>().HasKey(producto => producto.Id);


            //..HasOne(employee => employee.IdentificationType)
            //   .WithMany(identificationType => identificationType.Employees)
            //   .HasForeignKey(employee => employee.IdentificationTypeId)
            //   .IsRequired(false)
            //   .OnDelete(DeleteBehavior.Cascade);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

           
            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
