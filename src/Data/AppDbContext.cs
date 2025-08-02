using Microsoft.EntityFrameworkCore;
using App.EntityModels;

namespace App.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Mountain> Mountains { get; set; }
    public DbSet<MountainClimb> MountainClimbs { get; set; }
    public DbSet<MountainClimbResult> MountainClimbResults { get; set; }
    public DbSet<Nation> Nations { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceEdition> RaceEditions { get; set; }
    public DbSet<RaceRiderParticipation> RaceRiderParticipations { get; set; }
    public DbSet<RaceTeamParticipation> RaceTeamParticipations { get; set; }
    public DbSet<Rider> Riders { get; set; }
    public DbSet<RiderTeam> RiderTeams { get; set; }
    public DbSet<Sprint> Sprints { get; set; }
    public DbSet<SprintResult> SprintResults { get; set; }
    public DbSet<Stage> Stages { get; set; }
    public DbSet<StageCombativityAward> StageCombativeAwards { get; set; }
    public DbSet<StageNonFinish> StageDidNotStart { get; set; }
    public DbSet<StageRiderResult> StageRiderResults { get; set; }
    public DbSet<StageRiderStanding> StageRiderStandings { get; set; }
    public DbSet<StageTeamResult> StageTeamResults { get; set; }
    public DbSet<StageTeamStanding> StageTeamStandings { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamOrganization> TeamOrganizations { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }


}