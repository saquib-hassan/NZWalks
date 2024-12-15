using Microsoft.EntityFrameworkCore;

using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id =Guid.Parse("75fac35a-7795-460c-be95-bc89514b6817"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id =Guid.Parse("7f5e1f21-4f05-45e1-95b5-3d5be3aca5f0"),
                    Name = "Medium"
                    
                },
                new Difficulty
                {
                    Id =Guid.Parse("7887e703-bad7-4c34-be97-112605673f74"),
                    Name = "Hard"
                }

            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
}
