using GameOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameOps.Infrastructure.Persistence.Configurations
{
    public class StudioConfiguration : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.ToTable("Studios");

            builder.HasKey(x => x.Id);

            builder.Property(s => s.Name)
                .HasField("_name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.CreatedAt)
                .HasField("_createdAt")
                .IsRequired();

            builder.HasMany(s => s.Games)
                .WithOne()
                .HasForeignKey(g => g.StudioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(s => s.Games)
               .HasField("_games");
        }
    }
}
