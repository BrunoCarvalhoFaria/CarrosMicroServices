﻿using AutoMapper;
using Carros.Compra.Application.DTO;
using Carros.Compra.Application.Interfaces;
using Carros.Compra.Domain.Entities;
using Carros.Compra.Domain.Enums;
using Carros.Compra.Domain.Interfaces;
using Carros.Compra.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMensagemRepository _mensagemRepository;
        private readonly IModeloRepository _modeloRepository;
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IMapper _mapper;
        public PedidoService(
            IPedidoRepository pedidoRepository,
            IMensagemRepository mensagemRepository,
            IModeloRepository modeloRepository,
            IFabricanteRepository fabricanteRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;   
            _pedidoRepository = pedidoRepository;
            _mensagemRepository = mensagemRepository;
            _modeloRepository = modeloRepository;
            _fabricanteRepository = fabricanteRepository;
        }

        public async Task<long> AdicionarPedido(PedidoDTO pedidoDTO)
        {
            Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
            pedido.DataInclusao = DateTimeOffset.Now;
            pedido.Status = PedidoStatusEnum.Pendente;
            await _pedidoRepository.AddAsync(pedido);
            return pedido.Id;
        }

        public void ConfirmarEntrega(long PedidoId)
        {
            var pedido = _pedidoRepository.GetById(PedidoId);
            if (pedido == null)
                throw new Exception("Pedido não encontrado");
            if(pedido.Status == PedidoStatusEnum.Pendente)
                throw new Exception("Pedido ainda não foi comprado");
            if (pedido.Status == PedidoStatusEnum.Entregue)
                throw new Exception("Pedido já foi entregue");
            pedido.Status = PedidoStatusEnum.Entregue;
            _pedidoRepository.Update(pedido);
            var modelo = _modeloRepository.GetById(pedido.ModeloId);
            var fabricante = _fabricanteRepository.GetById(modelo.FabricanteId);
            _mensagemRepository.EnviarMensagem(new MensagemCarro
            {
                Nome = modelo.Nome,
                Fabricante = fabricante.Nome,
                Ano = modelo.Ano

            }, "carro-entregue");
        }

        public void EfetuarCompra(long PedidoId)
        {
            var pedido = _pedidoRepository.GetById(PedidoId);
            if (pedido == null)
                throw new Exception("Pedido não encontrado");
            if (pedido.Status != PedidoStatusEnum.Pendente)
                throw new Exception("Pedido já foi comprado");
            pedido.Status = PedidoStatusEnum.Comprado;
            _pedidoRepository.Update(pedido);
        }

        public void ExcluirPedido(long PedidoId)
        {
            var pedido = _pedidoRepository.GetById(PedidoId);
            if (pedido == null)
                throw new Exception("Pedido não encontrado");
            if(pedido.Status != PedidoStatusEnum.Pendente)
                throw new Exception("Pedido já foi processado, exclusão não permitida");
            pedido.Excluir();
            _pedidoRepository.Update(pedido);
        }

        public RetornoObterTodosPedidosDTO ObterTodosPedidos(long modeloId, int pagina = 1, int qtdRegistros = 99999)
        {
            RetornoObterTodosPedidosDTO retorno = new();
            var pedidos = _mapper.Map<List<PedidoDTO>>(_pedidoRepository.ObterTodosPedidos(modeloId));
            retorno.TotalRegistros = pedidos.Count();
            retorno.Dados = pedidos.Skip((pagina - 1) * qtdRegistros).Take(qtdRegistros).ToList();
            return retorno;
        }
    }
}
