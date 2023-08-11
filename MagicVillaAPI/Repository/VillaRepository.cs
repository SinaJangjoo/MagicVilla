using MagicVillaAPI.Data;
using MagicVillaAPI.Models;
using MagicVillaAPI.Repository.IRepository;

namespace MagicVillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly MagicVillaDB db;

        public VillaRepository(MagicVillaDB _db):base(_db)
        {
            db = _db;
        }
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.updateDate = DateTime.Now;
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
