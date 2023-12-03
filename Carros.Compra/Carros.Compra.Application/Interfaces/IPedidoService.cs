using Carros.Compra.Application.DTO;

namespace Carros.Compra.Application.Interfaces
{
    public interface IPedidoService
    {
        void EfetuarCompra(long PedidoId);
        void ConfirmarEntrega(long PedidoId);
        long AdicionarPedido(PedidoDTO pedido);
        void ExcluirPedido(long PedidoId);
        RetornoObterTodosPedidosDTO ObterTodosPedidos(long? modeloId, long? fabricanteId, int pagina = 1, int qtdRegistros = 99999);
    }
}
