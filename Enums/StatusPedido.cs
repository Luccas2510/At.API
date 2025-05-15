using System.ComponentModel;

namespace At.API.Enums
{
    public enum StatusPedido
    {
        [Description("Pendente")]
        EmPendência = 1,
        [Description("Processando")]
        EmProcesso = 2,
        [Description("Enviado")]
        EmEnvio = 3,
        [Description("Entregue")]
        Entregue = 4
    }
}
