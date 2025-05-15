using At.API.Models;
using At.API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace At.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoProdutoController : ControllerBase
    {

            private readonly IPedidoProdutoRepositorio _pedidoprodutoRepositorio;

            public PedidoProdutoController(IPedidoProdutoRepositorio pedidoprodutoRepositorio)
            {
                _pedidoprodutoRepositorio = pedidoprodutoRepositorio;
            }

            [HttpGet]
            public async Task<ActionResult<List<PedidoProdutoModel>>> BuscarPedidosProdutos()
            {
                List<PedidoProdutoModel> pedidosprodutos = await _pedidoprodutoRepositorio.BuscarPedidosProdutos();
                return Ok(pedidosprodutos);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<PedidoProdutoModel>> BuscarPorId(int id)
            {
                PedidoProdutoModel pedidoproduto = await _pedidoprodutoRepositorio.BuscarPorId(id);
                return Ok(pedidoproduto);
            }

            [HttpPost]

            public async Task<ActionResult<PedidoProdutoModel>> Adicionar([FromBody] PedidoProdutoModel pedidoprodutoModel)
            {
                PedidoProdutoModel pedidoproduto = await _pedidoprodutoRepositorio.Adicionar(pedidoprodutoModel);
                return Ok(pedidoproduto);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<PedidoProdutoModel>> Atualizar(int id, [FromBody] PedidoProdutoModel pedidoprodutoModel)
            {
                pedidoprodutoModel.Id = id;
                PedidoProdutoModel pedidoproduto = await _pedidoprodutoRepositorio.Atualizar(pedidoprodutoModel, id);
                return Ok(pedidoproduto);
            }

            [HttpDelete("{id}")]

            public async Task<ActionResult<PedidoProdutoModel>> Apagar(int id)
            {
                bool apagado = await _pedidoprodutoRepositorio.Apagar(id);
                return Ok(apagado);
            }
    }
}
