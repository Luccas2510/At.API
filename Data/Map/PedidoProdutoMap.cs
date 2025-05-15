using At.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace At.API.Data.Map
{
    public class PedidoProdutoMap
    {
        public void Configure(EntityTypeBuilder<PedidoProdutoModel> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.Preco).IsRequired();
            builder.Property(x => x.PedidoId).IsRequired();
            builder.Property(x => x.ProdutoId).IsRequired();
        }
    }
}
