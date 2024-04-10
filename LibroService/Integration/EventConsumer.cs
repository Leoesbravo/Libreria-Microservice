using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using LibroService.DTOs;
using RabbitMQ.Client.Events;
using LibroService.Models;
using Microsoft.EntityFrameworkCore;

namespace LibroService.Integration
{
    public class EventConsumer : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public EventConsumer()
        {

            // Configurar la conexión a RabbitMQ
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: "autor-agregado", type: ExchangeType.Fanout);
            
            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName, exchange: "autor-agregado", routingKey: "");
           
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var autorDto = JsonConvert.DeserializeObject<AutorDto>(message);

                //Insertar el registro en la base de datos de libro
            };

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
