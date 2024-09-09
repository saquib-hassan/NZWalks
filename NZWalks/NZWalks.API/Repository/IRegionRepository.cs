using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IRegionRepository
    {
         Task<List<Region>> GetAllAsync();

         Task<List<Region>> GetByIdAsync(Guid id);
    }
}
