using System.ComponentModel.DataAnnotations;

namespace LibroService.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
    }
}
