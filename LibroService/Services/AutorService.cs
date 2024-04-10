using LibroService.Models;
using LibroService.DTOs;

namespace LibroService.Services
{
    public class AutorService
    {
        private readonly AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(AutorDto autorDto)
        {
            var autor = new Autor
            {
                Nombre = autorDto.Nombre
            };

            _context.Autores.Add(autor);
            _context.SaveChanges();
        }
    }
}
