namespace codigonaveia.services.cursos.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task Insert(T entity);
        Task Update(int Id, T entity);
        Task Delete(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
