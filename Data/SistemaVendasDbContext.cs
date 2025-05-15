using At.API.Data.Map;
using At.API.Models;
using Microsoft.EntityFrameworkCore;

namespace At.API.Data
{
    public class SistemaVendasDbContext : DbContext
    {
        public SistemaVendasDbContext(DbContextOptions<SistemaVendasDbContext> options) : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PedidoProdutoModel> PedidosProdutos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
