using CpmPedidos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Interface
{
    public interface IPedidoRepository
    {
        decimal TicketMaximo();
        dynamic PedidosClientes();
        string SalvarPedido(PedidoDTO pedidoDTO);
    }
}
