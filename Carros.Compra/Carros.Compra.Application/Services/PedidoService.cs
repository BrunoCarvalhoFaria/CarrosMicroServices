﻿using AutoMapper;
using Carros.Compra.Application.DTO;
using Carros.Compra.Application.Interfaces;
using Carros.Compra.Domain.Entities;
using Carros.Compra.Domain.Enums;
using Carros.Compra.Domain.Interfaces;
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
        private readonly IMapper _mapper;
        public PedidoService(
            IPedidoRepository pedidoRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;   
            _pedidoRepository = pedidoRepository;
        }

        public long AdicionarPedido(PedidoDTO pedidoDTO)
        {
            Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
            _pedidoRepository.Add(pedido);
            return pedido.Id;
        }

        public void ConfirmarEntrega(long PedidoId)
        {
            var pedido = _pedidoRepository.GetById(PedidoId);
            if (pedido == null)
                throw new Exception("Pedido não encontrado");
            if(pedido.Status == PedidoStatusEnum.Pendente)
                throw new Exception("Pedido ainda não foi comprado");
            pedido.Status = PedidoStatusEnum.Entregue;
            _pedidoRepository.Update(pedido);
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
    }
}