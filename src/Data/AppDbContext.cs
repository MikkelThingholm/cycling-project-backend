using Microsoft.EntityFrameworkCore;
using App.EntityModels;
using app.EntityModels;

namespace DataAccess;

public class AppDbContext : DbContext{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

    }

    public DbSet<Rider> Riders { get; set; }
    public DbSet<RaceEdition> RaceEditions { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Stage> Stages { get; set; } 
    public DbSet<MetaTeam> MetaTeams { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<StageRiderResult> StageRiderResults { get; set; }
    public DbSet<StageTeamResult> StageTeamResults { get; set; }
    public DbSet<StageFinishStatus> StageFinishStatuses { get; set; }
    public DbSet<RiderTeam> RiderTeams { get; set;}
    public DbSet<Nation> Nations { get; set;}

}