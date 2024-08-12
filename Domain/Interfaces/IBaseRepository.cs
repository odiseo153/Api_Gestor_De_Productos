using Gestor_Productos.Domain.Entities;



namespace Gestor_Productos.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> Create(T entity);
        public Task<bool> Update(BaseEntity entity);
        public Task<bool> Delete(string Id);
        public Task<List<T>> GetAll(Func<T, bool> conditions = null);
        public Task<T> GetById(string Id);

    }
}








