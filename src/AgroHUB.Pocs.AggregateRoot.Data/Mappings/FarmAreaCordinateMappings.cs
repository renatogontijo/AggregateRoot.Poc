using AggregateRoot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AggregateRoot.Data.Mappings
{
    public class FarmAreaCordinateMappings : IEntityTypeConfiguration<FarmAreaCoordinate>
    {
        public void Configure(EntityTypeBuilder<FarmAreaCoordinate> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Latitude)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(c => c.Longitude)
                .HasColumnType("float")
                .IsRequired();

            builder.HasOne(c => c.FarmArea)
                .WithMany(c => c.FarmAreaCoordinates)
                .HasForeignKey(c => c.FarmAreaId);
        }
    }
}
