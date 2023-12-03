using Carros.Aluguel.Domain.Entities;
using Carros.Aluguel.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Carros.Aluguel.Infra.Data.Repository
{
    public class MensagemRepository : IMensagemRepository
    {
        private readonly IConfiguration _configuration;
        public MensagemRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ReceberMensagem(string fila)
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

            channel.QueueDeclare(queue: "bibliotecaMensagem",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                MensagemCarro mensagem = JsonSerializer.Deserialize<MensagemCarro>(message);
                                
            };
            channel.BasicConsume(queue: fila,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
