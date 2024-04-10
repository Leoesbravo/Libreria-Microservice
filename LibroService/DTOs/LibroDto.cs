using System.ComponentModel.DataAnnotations.Schema;

namespace LibroService.DTOs
{
    public class LibroDto
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public int Paginas { get; set; }
        public AutorDto Autor { get; set; }
    }
}
