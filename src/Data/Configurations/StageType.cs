using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageTypeConfiguration : IEntityTypeConfiguration<StageType>
{
    public void Configure(EntityTypeBuilder<StageType> builder)
    {
        builder.ToTable("stage_types");

        builder.Property(x => x.Name).HasMaxLength(64);

        builder.HasAlternateKey(x => x.Name);

        builder.HasData(
            new StageType { Id = 1, Name = "Flat" },
            new StageType { Id = 2, Name = "Hilly" },
            new StageType { Id = 3, Name = "Mountain" },
            new StageType { Id = 4, Name = "Individual time trial" },
            new StageType { Id = 5, Name = "Team time trial" },
            new StageType { Id = 6, Name = "Individual mountain time trial" },
            new StageType { Id = 7, Name = "Cobblestone" }
        );
    }
}