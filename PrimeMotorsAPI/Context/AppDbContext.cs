using Microsoft.EntityFrameworkCore;
using PrimeMotorsAPI.Models;

namespace PrimeMotorsAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioToken> UsuariosTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Corrigido aqui
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}