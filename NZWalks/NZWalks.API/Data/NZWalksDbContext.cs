using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties  { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id=Guid.Parse("a87e4c59-f395-4c65-a40a-7fea123374d0"),
                    Name="Easy"
                },
                new Difficulty
                {
                    Id=Guid.Parse("7565b2bc-e2f9-4812-a9dc-8ff367820d58"),
                    Name="Medium"
                },
                new Difficulty
                {
                    Id=Guid.Parse("42239bd9-c2f6-401c-8855-b62e1be64f68"),
                    Name="Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region
                {
                    Id=,
                    Code=,
                    Name=,
                    RegionImageUrl=
                }
            }
        }

        
    }
}
