using codigonaveia.services.cursos.Data.DataConfig;
using codigonaveia.services.cursos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace codigonaveia.services.cursos.Data.Contexto
{
    public class DataContexto:DbContext
    {
        public DataContexto(DbContextOptions<DataContexto> options):base(options){}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EntidadeCursos>(new CursosConfiguration().Configure);
            base.OnModelCreating(builder);
        }

    }
}
