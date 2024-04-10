namespace LibroService.DTOs
{
    public class ResultDto
    {
        public object? Object { get; set; }
        public List<object> Objects { get; set; }
        public bool Correct { get; set; }
        public string ErrorMessage { get; set; }
    }
}
