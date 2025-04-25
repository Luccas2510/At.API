using System.ComponentModel;

namespace At.API.Enums
{
    public enum StatusPedido
    {
        [Description("Em Pendencia")]
        Pendente = 1,
        [Description("Em Processo")]
        AmAndamento = 2,
        [Description("Enviado")]
        Enviado = 3,
        [Description("Entregue")]
        Entregu = 4,
    }
}
