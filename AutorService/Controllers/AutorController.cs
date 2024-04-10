using AutorService.DTOs;
using AutorService.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AutorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AutorController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] AutorDto autorDto)
        {
            Models.Autor autor = new Autor()
            {
                Nombre = autorDto.Nombre
            };
            _context.Autores.Add(autor);
            _context.SaveChanges();
            EnviarMensajeAutorAgregado(autorDto);
            return Ok();
        }
        private void EnviarMensajeAutorAgregado(AutorDto autorDto)
        {
            // Configurar la conexión a RabbitMQ 
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Declarar el intercambio para enviar mensajes
                channel.ExchangeDeclare(exchange: "autor-agregado", type: ExchangeType.Fanout);

                // Serializar el mensaje (en formato JSON)
                var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(autorDto));

                // Publicar el mensaje al intercambio
                channel.BasicPublish(exchange: "autor-agregado",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: messageBody);
            }
        }
    }
}
