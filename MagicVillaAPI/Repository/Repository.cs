using MagicVillaAPI.Data;
using MagicVillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVillaAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MagicVillaDB db;
        internal DbSet<T> dbSet;
        public Repository(MagicVillaDB _db)
        {
            db = _db;
            this.dbSet = db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? IncludeProperties=null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if(IncludeProperties != null)
            {
                foreach (var prop in IncludeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool IsTracked = true, string? IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!IsTracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (IncludeProperties != null)
            {
                foreach (var prop in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        Task<bool> IRepository<T>.AnyAsync(Expression<Func<T, bool>> filter)
        {
            return dbSet.AnyAsync(filter);
        }
    }
}
