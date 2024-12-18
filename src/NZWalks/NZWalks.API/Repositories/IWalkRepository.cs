using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk>CreateAsync(Walk walks);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?>GetByIdAsync(Guid id);
    }
}
