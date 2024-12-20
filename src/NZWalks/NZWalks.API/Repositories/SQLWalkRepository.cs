using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walks)
        {
            await dbContext.Walks.AddAsync(walks);
            await dbContext.SaveChangesAsync();
            return walks;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
                                                    string? sortBy = null, bool isAscending = true,
                                                        int pageNumber = 1, int pageSize = 1000)
        {
           var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            //return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

            // filtering
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }

            }

            // sorting

            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Contains("Name",StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x=> x.Name);
                }
                else if(sortBy.Contains("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x=>x.LengthInKm) : walks.OrderByDescending(x=> x.LengthInKm);
                }
                
            }

            // pagination

            var skipResult = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResult).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.
                Include("Difficulty").
                Include("Region").
                FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Walk?> UpdateAsync(Walk walk, Guid id)
        {
            var existingWalk =  await dbContext.Walks.FirstOrDefaultAsync(x=> x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
           
            existingWalk.Name = walk.Name;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;

            await dbContext.SaveChangesAsync();
            return existingWalk;


        }


    }
}
