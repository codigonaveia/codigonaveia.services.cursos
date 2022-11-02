using codigonaveia.services.cursos.WebApplication.Models;
using Refit;

namespace codigonaveia.services.cursos.WebApplication.Interfaces
{
    public interface ICursosRepository
    {
        [Post("/v1/Cursos/Register")]
        Task Registrar(CursosViewModel mod);

        [Get("/v1/Cursos/ObterTodosCursos")]
        Task<IEnumerable<CursosViewModel>> ObterCursos();

        [Get("/v1/Cursos/ObterCursoPorId/{Id}")]
        Task<CursosViewModel> ObterCursosPorId(int Id);

        [Delete("/v1/Cursos/Delete/{Id}")]
        Task Excluir(int Id);
        [Put("/v1/Cursos/{Id}")]
        Task Update(int Id, CursosViewModel mod);
    }
}
