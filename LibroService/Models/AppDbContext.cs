using Microsoft.EntityFrameworkCore;

namespace LibroService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}
