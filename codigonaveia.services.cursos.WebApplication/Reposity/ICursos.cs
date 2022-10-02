using codigonaveia.services.cursos.WebApplication.Models;

namespace codigonaveia.services.cursos.WebApplication.Reposity
{
    public interface ICursos
    {
        Task Registrar(CursosViewModel mod);
    }
}
