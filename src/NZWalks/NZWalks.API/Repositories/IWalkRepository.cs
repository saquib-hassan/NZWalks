using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk>CreateAsync(Walk walks);
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null);
        Task<Walk?>GetByIdAsync(Guid id);
        Task<Walk?>UpdateAsync(Walk walk, Guid id);
        Task<Walk?>DeleteAsync(Guid id);
    }
}
