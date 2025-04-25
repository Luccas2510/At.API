using At.API.Enums;

namespace At.API.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string EnderecoEntrega { get; set; }
        public StatusPedido Status { get; set; }
        public string ModoPagamento { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}
