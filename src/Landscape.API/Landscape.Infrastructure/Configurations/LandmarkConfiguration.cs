using Landscape.Domain.Landmark;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Landscape.Infrastructure.Configurations;

internal sealed  class LandmarkConfiguration : IEntityTypeConfiguration<Landmark>
{
    public void Configure(EntityTypeBuilder<Landmark> builder)
    {
        builder.ToTable("landmarks");

        builder.HasKey(landmark => landmark.Id);
        
        builder.Property(landmark => landmark.Name)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new Name(value));
        
        builder.Property(landmark => landmark.Description)
            .HasMaxLength(2000)
            .HasConversion(description => description.Value, value => new Description(value));

        builder.OwnsOne(landmark => landmark.Address);
        builder.OwnsOne(landmark => landmark.Coordinate);
        
        builder.Property<uint>("Version").IsRowVersion();
    }
}