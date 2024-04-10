using Microsoft.EntityFrameworkCore;

namespace AutorService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Autor> Autores { get; set; }
    }
}
