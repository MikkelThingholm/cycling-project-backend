using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class MountainClimbConfiguration : IEntityTypeConfiguration<MountainClimb>
{
    public void Configure(EntityTypeBuilder<MountainClimb> builder)
    {
        builder.ToTable("mountain_climbs");

    }
}
