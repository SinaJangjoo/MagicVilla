using MagicVillaAPI.Models;

namespace MagicVillaAPI.Repository.IRepository
{
    public interface IVillaRepository :IRepository<Villa>
    {
        public Task<Villa> UpdateAsync(Villa entity );
    }
}
