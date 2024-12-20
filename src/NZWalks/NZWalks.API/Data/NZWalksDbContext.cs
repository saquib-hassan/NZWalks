using Microsoft.EntityFrameworkCore;

using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
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

            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("3176866f-c7ac-412e-b676-07ae4e1bb97a"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl ="some-image-from-Auckland.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("07d44bb6-cf74-4b1c-99af-9472e30272b5"),
                    Name = "Welington",
                    Code = "WLT",
                    RegionImageUrl ="some-image-from-Welington.jpg"

                },
                new Region
                {
                    Id = Guid.Parse("0ebdfe73-77bb-4a85-b798-c3230f77f6d4"),
                    Name = "Bellingham",
                    Code = "BLH",
                    RegionImageUrl ="some-image-from-Bellingham.jpg"

                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
