using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Region> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            // return await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id ==id);
            throw(new NotImplementedException());
          
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Region?> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
