using GameStore.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace GameStore.Server.Configurations.Entities
{
    public class GameSeedConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(
                  new Game
                  {
                      Id = 1,
                      TitleId = 1,
                      DeveloperId = 1,
                      GenreId = 1,
                      PlatformId = 1,
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      CreatedBy = "System",
                      UpdatedBy = "System"
                  },
                  new Game
                  {
                      Id = 2,
                      TitleId = 2,
                      DeveloperId = 2,
                      GenreId = 2,
                      PlatformId = 2,
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      CreatedBy = "System",
                      UpdatedBy = "System"
                  }
            );
        }
    }
}
