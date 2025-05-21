using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configurations;

public class TeamOrganizationConfiguration : IEntityTypeConfiguration<TeamOrganization>
{
    public void Configure(EntityTypeBuilder<TeamOrganization> builder)
    {
        builder.ToTable("team_organizations");

    }

}