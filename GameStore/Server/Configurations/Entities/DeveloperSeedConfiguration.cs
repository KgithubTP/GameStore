using GameStore.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Server.Configurations.Entities
{
    namespace GameStore.Server.Configurations.Entities
    {
        public class DeveloperSeedConfiguration : IEntityTypeConfiguration<Developer>
        {
            public void Configure(EntityTypeBuilder<Developer> builder)
            {
                builder.HasData(
                      new Developer
                      {
                          Id = 1,
                          Name = "Obsidian",
                          DateCreated = DateTime.Now,
                          DateUpdated = DateTime.Now,
                          CreatedBy = "System",
                          UpdatedBy = "System"
                      },
                      new Developer
                      {
                          Id = 2,
                          Name = "Arkane",
                          DateCreated = DateTime.Now,
                          DateUpdated = DateTime.Now,
                          CreatedBy = "System",
                          UpdatedBy = "System"
                      }
                );
            }
        }
    }
}
