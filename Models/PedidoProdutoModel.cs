namespace At.API.Models
{
    public class PedidoProdutoModel
    {
        public int Id { get; set; }
        public int? PedidoId { get; set; }
        public int? ProdutoId { get; set; }
        public string Quantidade { get; set; }
        public string Preco {  get; set; }
        public PedidoModel? Pedido { get; set; }
        public ProdutoModel? Produto { get; set; }
    }
}
