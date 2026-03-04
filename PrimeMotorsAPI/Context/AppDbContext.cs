using Microsoft.EntityFrameworkCore;
using PrimeMotorsAPI.Models;
using PrimeMotorsAPI.Models.Cliente;
using PrimeMotorsAPI.Models.Venda;

namespace PrimeMotorsAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioToken> UsuarioTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Corrigido aqui
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}