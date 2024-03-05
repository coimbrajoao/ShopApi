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
        
    }
}