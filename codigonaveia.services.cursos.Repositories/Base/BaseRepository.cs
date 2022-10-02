using codigonaveia.services.cursos.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace codigonaveia.services.cursos.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContexto _dataContexto;

        public BaseRepository(DataContexto dataContexto)
        {
            _dataContexto = dataContexto;
        }
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            _dataContexto.Set<T>().Remove(entity);
            await _dataContexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dataContexto.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dataContexto.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
           await _dataContexto.Set<T>().AddAsync(entity);
            await _dataContexto.SaveChangesAsync();
        }

        public async Task Update(int Id, T entity)
        {
            _dataContexto.Set<T>().Update(entity);
            await _dataContexto.SaveChangesAsync();
        }
    }
}
