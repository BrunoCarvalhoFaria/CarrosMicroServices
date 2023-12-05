using System.Text;
using System.Text.Json;
using Carros.Consumer.Entities;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;



string connectionString = "Server=localhost;Database=carrosaluguel;Uid=root;Pwd=060787";

using MySqlConnection dbConnection = new MySqlConnection(connectionString);

dbConnection.Open();

// Aqui você pode realizar operações no banco de dados

Console.WriteLine("Conexão bem-sucedida!");
var factory = new ConnectionFactory
{
    HostName = "localhost",
    Port = 5672,
    UserName = "admin",
    Password = "admin"
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "carro-entregue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");
MensagemCompra mensagem = new();
var consumer = new EventingBasicConsumer(channel);
var tasks = new List<Task>();
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    mensagem = JsonSerializer.Deserialize<MensagemCompra>(message);
    
    // Exemplo de consulta simples
    using (MySqlCommand cmd = new MySqlCommand($@"INSERT INTO recebimento (nome, fabricante, ano, excluido, pendente) 
                                                                   VALUES ('{mensagem.Nome}','{mensagem.Fabricante}','{mensagem.Ano}',false,true)", dbConnection))
    {
        int rowsAffected = cmd.ExecuteNonQuery();
        Console.WriteLine("Mensagem recebida!");

    }
};
channel.BasicConsume(queue: "carro-entregue",
                     autoAck: true,
                     consumer: consumer);






Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();