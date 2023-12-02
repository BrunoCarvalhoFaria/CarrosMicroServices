using Carros.Compra.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Application.Interfaces
{
    public interface IPedidoService
    {
        void EfetuarCompra(long PedidoId);
        void ConfirmarEntrega(long PedidoId);
        long AdicionarPedido(PedidoDTO pedido);
        void ExcluirPedido(long PedidoId); 
    }
}
