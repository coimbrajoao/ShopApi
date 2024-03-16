using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Entities;

namespace ShopApi.Domain.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property<Guid>("ClienteId"); // Adiciona uma nova propriedade para armazenar a foreign key

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Cliente)
                .WithOne()
                .HasForeignKey<Usuario>("ClienteId"); // Define a foreign key para a relação um-para-um entre Usuario e Cliente

            base.OnModelCreating(modelBuilder);
        }
    }
}