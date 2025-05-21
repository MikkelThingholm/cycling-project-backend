using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class StageRiderResultConfiguration : IEntityTypeConfiguration<StageRiderResult>
{
    public void Configure(EntityTypeBuilder<StageRiderResult> builder)
    {
        builder.ToTable("stage_rider_results");

        builder.HasAlternateKey(x => new { x.StageId, x.RaceRiderParticipationId });
    }
}
