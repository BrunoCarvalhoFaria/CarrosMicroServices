﻿using Carros.Compra.Application.DTO;

namespace Carros.Compra.Application.Interfaces
{
    public interface IFabricanteService
    {
        Task<long> CadastrarFabricante(FabricanteDTO fabricante);
        void ExcluirFabricante(long id);
        List<FabricanteDTO> ObterTodosFabricantes();
    }
}
