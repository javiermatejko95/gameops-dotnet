using GameOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameOps.Infrastructure.Persistence.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");

            builder.HasKey(x => x.Id);

            builder.Property(g => g.Id)
                .HasField("_id")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .ValueGeneratedNever();

            builder.Property(g => g.Name)
                .HasField("_name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.CreatedAt)
                .HasField("_createdAt");

            builder.Property(g => g.StudioId)
                .HasField("_studioId");
        }
    }
}
