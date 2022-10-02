using codigonaveia.services.cursos.Data.Contexto;
using codigonaveia.services.cursos.Domain.Entities;
using codigonaveia.services.cursos.Repositories.Base;
using codigonaveia.services.cursos.Repositories.Interface;

namespace codigonaveia.services.cursos.Repositories.Repository
{
    public class CursosRepository : BaseRepository<EntidadeCursos>, ICursosRepository
    {
        public CursosRepository(DataContexto dataContexto) : base(dataContexto)
        {
        }
    }
}
