using At.API.Data;
using At.API.Models;
using At.API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace At.API.Repositorios
{
    public class PedidoProdutoRepositorio : IPedidoProdutoRepositorio
    {
        private readonly SistemaVendasDbContext _dbContext;

        public PedidoProdutoRepositorio(SistemaVendasDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PedidoProdutoModel> Adicionar(PedidoProdutoModel pedidoproduto)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidoproduto);
            await _dbContext.SaveChangesAsync();

            return pedidoproduto;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidoProdutoModel pedidoprodutoPorId = await BuscarPorId(id);

            if (pedidoprodutoPorId == null)
            {
                throw new Exception($"Pedidos de Produtos do Id: {id} não foi encontrados.");
            }

            _dbContext.PedidosProdutos.Remove(pedidoprodutoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PedidoProdutoModel> Atualizar(PedidoProdutoModel pedidoproduto, int id)
        {
            PedidoProdutoModel pedidoprodutoPorId = await BuscarPorId(id);

            if (pedidoprodutoPorId == null)
            {
                throw new Exception($"Pedidos de Produtos do Id: {id} não encontrados.");
            }

            pedidoprodutoPorId.Preco = pedidoproduto.Preco;
            pedidoprodutoPorId.Quantidade = pedidoproduto.Quantidade;
            pedidoprodutoPorId.PedidoId = pedidoproduto.PedidoId;
            pedidoprodutoPorId.ProdutoId = pedidoproduto.ProdutoId;

            _dbContext.PedidosProdutos.Update(pedidoprodutoPorId);
            await _dbContext.SaveChangesAsync();

            return pedidoprodutoPorId;
        }

        public async Task<PedidoProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.PedidosProdutos.Include(x => x.Pedido).Include(y => y.Produto).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidoProdutoModel>> BuscarPedidosProdutos()
        {
            return await _dbContext.PedidosProdutos.Include(x => x.Pedido).Include(y => y.Produto).ToListAsync();
        }
    }
}
