using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class RiderTeamConfiguration : IEntityTypeConfiguration<RiderTeam>
{
    public void Configure(EntityTypeBuilder<RiderTeam> builder)
    {
        builder.ToTable("riders_teams");

        builder.HasKey(rt => rt.Id);

    }

}