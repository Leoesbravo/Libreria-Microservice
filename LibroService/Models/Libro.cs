using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace LibroService.Models
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public int Paginas { get; set; }
        [ForeignKey("Autor")]
        public int IdAutor { get; set; }
        public Autor Autor { get; set; }
    }
}
