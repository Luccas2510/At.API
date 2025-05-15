using At.API.Models;

namespace At.API.Repositorios.Interfaces
{
    public interface IPedidoProdutoRepositorio
    {
        Task<List<PedidoProdutoModel>> BuscarPedidosProdutos();
        Task<PedidoProdutoModel> BuscarPorId(int id);
        Task<PedidoProdutoModel> Adicionar(PedidoProdutoModel pedidoproduto);
        Task<PedidoProdutoModel> Atualizar(PedidoProdutoModel pedidoproduto, int id);
        Task<bool> Apagar(int id);
    }
}
