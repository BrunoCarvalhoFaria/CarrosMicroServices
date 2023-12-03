using Carros.Compra.Application.DTO;

namespace Carros.Compra.Application.Interfaces
{
    public interface IModeloService
    {
        Task<long> AdicionarModelo(ModeloDTO modelo);
        void AlterarModelo(ModeloDTO modelo);
        void ExcluirModelo(long Id);
        RetornoObterTodosModelosDTO ObterTodosModelos(long fabricanteId, int pagina = 1, int qtdRegistros = 9999);
    }
}
