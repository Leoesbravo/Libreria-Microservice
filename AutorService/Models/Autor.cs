using System.ComponentModel.DataAnnotations;

namespace AutorService.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
    }
}
