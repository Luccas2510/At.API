using At.API.Data.Map;
using At.API.Models;
using Microsoft.EntityFrameworkCore;

namespace At.API.Data
{
    public class SistemaVendasDbContext : DbContext
    {
        public SistemaVendasDbContext(DbContextOptions<SistemaVendasDbContext> options) : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
