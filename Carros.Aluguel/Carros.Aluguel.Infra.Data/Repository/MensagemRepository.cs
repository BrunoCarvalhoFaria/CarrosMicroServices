using Carros.Aluguel.Domain.Entities;
using Carros.Aluguel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Aluguel.Infra.Data.Repository
{
    public class MensagemRepository: Repository<Mensagem>, IMensagemRepository
    {
        private readonly DbContextOptions<CarrosCompraDbContext> _optionsBuilder;

        public MensagemRepository(CarrosCompraDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<CarrosCompraDbContext>();
        }

        public async Task BuscarRecebimentoPendente()
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

            channel.QueueDeclare(queue: "carro-entregue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");
            Recebimento retorno = new();
            Mensagem mensagem = new();
            var consumer = new EventingBasicConsumer(channel);
            var tasks = new List<Task>();
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                mensagem = JsonSerializer.Deserialize<Mensagem>(message);
                retorno.Ano = mensagem.Ano;
                retorno.Nome = mensagem.Nome;
                retorno.Fabricante = mensagem.Fabricante;
                retorno.Pendente = true;
                tasks.Add(AdicionarRecebimento(retorno));
            };
            channel.BasicConsume(queue: "carro-entregue",
                                 autoAck: true,
                                 consumer: consumer);
            Task.WaitAll(tasks.ToArray());
        }
    }
}
