using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public class SqlWalkRepository : IWalkRepository
    {
        public Task<Walk> CreateAsync(Walk walk)
        {
            throw new NotImplementedException();
        }
    }
}
