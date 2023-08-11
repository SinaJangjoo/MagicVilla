using MagicVillaAPI.Models;

namespace MagicVillaAPI.Repository.IRepository
{
    public interface IVillaNumberRepository :IRepository<VillaNumber>
    {
        public Task<VillaNumber> UpdateAsync(VillaNumber entity );
    }
}
