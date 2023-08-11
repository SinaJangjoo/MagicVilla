using System.Linq.Expressions;

namespace MagicVillaAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task CreateAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task<List<T>> GetAllAsync(Expression<Func<T,bool>>? filter=null,string? IncludeProperties=null);
        public Task<T> GetAsync(Expression<Func<T,bool>> filter=null,bool IsTracked=true, string? IncludeProperties = null);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null);
        public Task SaveAsync();
    }
}
