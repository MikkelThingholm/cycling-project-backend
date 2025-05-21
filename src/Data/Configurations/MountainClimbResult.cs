using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class MountainClimbResultConfiguration : IEntityTypeConfiguration<MountainClimbResult>
{
    public void Configure(EntityTypeBuilder<MountainClimbResult> builder)
    {
        builder.ToTable("mountain_climb_reults");

    }
}
