using AggregateRoot.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AggregateRoot.Data.Mappings
{
    public class FarmAreaMappings : IEntityTypeConfiguration<FarmArea>
    {
        public void Configure(EntityTypeBuilder<FarmArea> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.HasMany(c => c.FarmAreaCoordinates)
                .WithOne(c => c.FarmArea)
                .HasForeignKey(c => c.FarmAreaId);

            builder.Metadata
                .FindNavigation("FarmAreaCoordinates")
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
