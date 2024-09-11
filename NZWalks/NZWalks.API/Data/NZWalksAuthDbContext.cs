using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerUserRole = "fa6586e9-1b47-40dc-a1c7-dab6be0a8f2d";
            var writerUserRole = "3d49df08-561c-4cf5-b21a-8934f7e35e1a";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerUserRole,
                    Name = "Reader",
                    ConcurrencyStamp = readerUserRole,
                    NormalizedName = "Reader".ToUpper()
                },

                new IdentityRole
                {
                    Id=writerUserRole,
                    Name="Writer",
                    ConcurrencyStamp=writerUserRole,
                    NormalizedName = "Writer".ToUpper()
                }
            };
        }
    }
}
