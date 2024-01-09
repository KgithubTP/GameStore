using GameStore.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Server.Configurations.Entities
{
    public class PlatformSeedConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.HasData(
                  new Platform
                  {
                      Id = 1,
                      Name = "PC",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      CreatedBy = "System",
                      UpdatedBy = "System"
                  },
                  new Platform
                  {
                      Id = 2,
                      Name = "Switch",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      CreatedBy = "System",
                      UpdatedBy = "System"
                  }
            );
        }
    }
}