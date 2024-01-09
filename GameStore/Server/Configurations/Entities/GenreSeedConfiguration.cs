using GameStore.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace GameStore.Server.Configurations.Entities
{
    public class GenreSeedConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                  new Genre
                  {
                      Id = 1,
                      Name = "FPS",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      CreatedBy = "System",
                      UpdatedBy = "System"
                  },
                  new Genre
                  {
                      Id = 2,
                      Name = "Horror",
                      DateCreated = DateTime.Now,
                      DateUpdated = DateTime.Now,
                      CreatedBy = "System",
                      UpdatedBy = "System"
                  }
            );
        }
    }
}
