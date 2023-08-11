using MagicVillaAPI.Data;
using MagicVillaAPI.Models;
using MagicVillaAPI.Repository.IRepository;

namespace MagicVillaAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly MagicVillaDB db;

        public VillaNumberRepository(MagicVillaDB _db):base(_db)
        {
            db = _db;
        }
        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
