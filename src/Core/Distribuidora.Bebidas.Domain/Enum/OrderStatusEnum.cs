using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Bebidas.Domain.Enum
{
    public enum OrderStatusEnum
    {
        [Description("Pedido criado, aguardando processamento.")]
        Pending,
        [Description("Sendo separado/produzido para envio.")]
        Preparation,
        [Description("Já despachado, em movimento para o destino.")]
        InTransit,
        [Description("Entregue ao destinatário.")]
        Delivered,
        [Description("Pedido Cancelado.")]
        Canceled
    }
}
