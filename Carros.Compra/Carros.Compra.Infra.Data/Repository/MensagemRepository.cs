using Carros.Compra.Domain.DTO;
using Carros.Compra.Domain.Entities;
using Carros.Compra.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Carros.Compra.Infra.Data.Repository
{
    public class MensagemRepository : IMensagemRepository
    {
        private readonly IConfiguration _configuration;
        public MensagemRepository( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarMensagem(MensagemCarro mensagem, string fila)
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration.GetSection("RabbitMQ:HostName").Value,
                Port = int.Parse(_configuration.GetSection("RabbitMQ:Port").Value),
                UserName = _configuration.GetSection("RabbitMQ:UserName").Value,
                Password = _configuration.GetSection("RabbitMQ:Password").Value
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: fila,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string json = JsonSerializer.Serialize(mensagem);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: fila,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
