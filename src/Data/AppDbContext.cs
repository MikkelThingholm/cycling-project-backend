using Microsoft.EntityFrameworkCore;
using App.EntityModels;

namespace DataAccess;

public class AppDbContext : DbContext{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

    }

    public DbSet<Rider> Riders { get; set; }
    public DbSet<RaceEdition> RaceEditions { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Stage> Stages { get; set; } 
    public DbSet<MetaTeam> MetaTeam { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<StageIndividualResult> StageIndividualResult { get; set; }
    public DbSet<StageTeamResult> StageTeamResult { get; set; }
}