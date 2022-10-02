namespace codigonaveia.services.cursos.WebApplication.Models
{
    public class CursosViewModel
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
