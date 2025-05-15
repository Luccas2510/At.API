using At.API.Data;
using At.API.Migrations;
using At.API.Models;
using At.API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace At.API.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly SistemaVendasDbContext _dbContext;

        public PedidoRepositorio(SistemaVendasDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PedidoModel> Adicionar(PedidoModel pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidoModel pedidoPorId = await BuscarPorId(id);

            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do Id: {id} não foi encontrado.");
            }

            _dbContext.Pedidos.Remove(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PedidoModel> Atualizar(PedidoModel pedido, int id)
        {
            PedidoModel pedidoPorId = await BuscarPorId(id);

            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido do Id: {id} não encontrado.");
            }

            pedidoPorId.EnderecoEntrega = pedido.EnderecoEntrega;
            pedidoPorId.ModoPagamento = pedido.ModoPagamento;
            pedidoPorId.Status = pedido.Status;
            pedidoPorId.UsuarioId = pedido.UsuarioId;

            _dbContext.Pedidos.Update(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return pedidoPorId;
        }

        public async Task<PedidoModel> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidoModel>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos.Include(x => x.Usuario).ToListAsync();
        }
    }
}
