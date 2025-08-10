using App.Data;
using App.EntityModels;
using App.Exceptions;
using App.Extensions;
using Microsoft.EntityFrameworkCore;
using App.Services.Interfaces;


namespace App.Services;

public class RaceQueryService(ILogger<RaceQueryService> logger, AppDbContext db) : IRaceQueryService
{
    private readonly ILogger<RaceQueryService> _logger = logger;
    private readonly AppDbContext _db = db;

    // Races

    public async Task<Race> GetRaceById(int raceId)
    {
        var race = await _db.Races.Include(r => r.Nation)
                                  .Include(r => r.RaceEditions)
                                  .SingleOrDefaultAsync(r => r.Id == raceId)
                                  ?? throw new EntityNotFoundException(nameof(Race), raceId);
        return race;
    }

    public async Task<Race> GetRaceBySlug(string raceSlug)
    {
        var race = await _db.Races.Include(r => r.Nation)
                                  .Include(r => r.RaceEditions)
                                  .SingleOrDefaultAsync(r => r.Slug == raceSlug)
                                  ?? throw new EntityNotFoundException(nameof(Race), new { Slug = raceSlug });
        return race;
    }


    // RaceEditions

    public async Task<RaceEdition> GetRaceEditionById(int raceEditionId)
    {
        var raceEdition = await _db.RaceEditions.Include(re => re.Race)
                                                .Include(re => re.Stages)
                                                .SingleOrDefaultAsync(re => re.Id == raceEditionId)
                                                ?? throw new EntityNotFoundException(nameof(RaceEdition), raceEditionId);
        return raceEdition;
    }

    private static (string, int) SplitRaceEditionSlug(string raceEditionSlug)
    {
        var parts = raceEditionSlug.Split('-');
        if (parts.Length != 2)
        {
            throw new BusinessRuleViolationException($"Race edition slug {raceEditionSlug} doesnt have 2 parts (split by '-')");
        }

        if (!int.TryParse(parts.Last(), out int year))
        {
            throw new BusinessRuleViolationException($"Last part of race edition slug {parts.Last()} could not be converted to int");
        }

        if (!(1900 <= year && year <= DateTime.UtcNow.Year + 5))
        {
            throw new BusinessRuleViolationException($"Race edition year must be between 1900 and {DateTime.UtcNow.Year + 5}");
        }

        return (string.Join("-", parts.Take(parts.Length - 1)), year);
    }

    public async Task<RaceEdition> GetRaceEditionBySlug(string raceEditionSlug)
    {

        var (raceSlug, year) = SplitRaceEditionSlug(raceEditionSlug);

        var raceEdition = await _db.RaceEditions.Include(re => re.Race)
                                                .Include(re => re.Stages)
                                                .SingleOrDefaultAsync(re => re.Race.Slug == raceSlug && re.Year == year)
                                                ?? throw new EntityNotFoundException(nameof(RaceEdition), new { RaceSlug = raceSlug, Year = year });
        return raceEdition;
    }

    // Stages 

    public async Task<Stage> GetStageById(int stageId)
    {
        var stage = await _db.Stages.Include(s => s.RaceEdition)
                                    .Include(s => s.Sprints)
                                    .Include(s => s.MountainClimbs)
                                    .Include(s => s.StageTeamResults)
                                    .Include(s => s.StageRiderResults)
                                    .SingleOrDefaultAsync(s => s.Id == stageId)
                                    ?? throw new EntityNotFoundException(nameof(Stage), stageId);
        return stage;
    }

    private static (string, int, int) SplitStageSlug(string stageSlug)
    {
        var parts = stageSlug.Split("-");
        if (parts.Length != 3 && parts.Length != 4)
        {
            throw new BusinessRuleViolationException($"Stage slug {stageSlug} doesnt have 3 or 4 parts (split by '-')");
        }

        var (raceSlug, raceEditionYear) = SplitRaceEditionSlug(string.Join('-', parts.Take(2).ToList()));

        if (parts[2] == "prologue")
        {
            var stageNum_ = 0;
            return (raceSlug, raceEditionYear, stageNum_);
        }

        if (parts.Length != 4)
        {
            throw new BusinessRuleViolationException($"Non prologue stage slugs must have 4 parts (split by '-')");
        }

        if (!int.TryParse(parts[3], out int stageNum))
        {
            throw new BusinessRuleViolationException($"Last part of stage slug {parts.Last()} could not be converted to int");
        }

        if (!(1 <= stageNum && stageNum <= 25))
        {
            throw new BusinessRuleViolationException($"Last part of stage slug {parts.Last()} could not be converted to int");
        }

        return (raceSlug, raceEditionYear, stageNum);
    }

    public async Task<Stage> GetStageBySlug(string stageSlug)
    {
        var (raceSlug, raceEditionYear, stageNum) = SplitStageSlug(stageSlug);

        var stage = await _db.Stages.Include(s => s.RaceEdition)
                                    .Include(s => s.Sprints)
                                    .Include(s => s.MountainClimbs)
                                    .Include(s => s.StageTeamResults)
                                    .Include(s => s.StageRiderResults)
                                    .SingleOrDefaultAsync(s => s.StageNumber == stageNum && s.RaceEdition.Year == raceEditionYear && s.RaceEdition.Race.Slug == raceSlug)
                                    ?? throw new EntityNotFoundException(nameof(Stage), new { StageNumber = stageNum, RaceEditionYear = raceEditionYear, RaceSlug = raceSlug });

        return stage;
    }

    // MountainClimbs

    public async Task<MountainClimb> GetMountainClimbById(int mountainClimbId)
    {
        var mountainClimb = await _db.MountainClimbs.Include(mc => mc.Stage)
                                                    .Include(mc => mc.Mountain)
                                                    .SingleOrDefaultAsync(mc => mc.Id == mountainClimbId)
                                                    ?? throw new EntityNotFoundException(nameof(MountainClimb), mountainClimbId);
        return mountainClimb;
    }

    public async Task<MountainClimb> GetMountainClimbBySlug(string stageSlug, int mountainClimbNumber)
    {
        var (raceSlug, raceEditionYear, stageNum) = SplitStageSlug(stageSlug);

        var mountainClimb = await _db.MountainClimbs.Include(mc => mc.Stage)
                                                    .Include(mc => mc.Mountain)
                                                    .Where(mc => mc.Stage.StageNumber == stageNum &&
                                                                                 mc.Stage.RaceEdition.Year == raceEditionYear &&
                                                                                 mc.Stage.RaceEdition.Race.Slug == raceSlug)
                                                    .OrderBy(mc => mc.DistanceFromStartMeters)
                                                    .Skip(mountainClimbNumber - 1)
                                                    .FirstOrDefaultAsync()
                                                    ?? throw new EntityNotFoundException(nameof(MountainClimb), new { StageSlug = stageSlug, MountainClimbNumber = mountainClimbNumber });
        return mountainClimb;
    }

    // Sprints

    public async Task<Sprint> GetSprintById(int sprintId)
    {
        var sprint = await _db.Sprints.Include(s => s.Stage)
                                      .SingleOrDefaultAsync(s => s.Id == sprintId)
                                      ?? throw new EntityNotFoundException(nameof(Sprint), sprintId);
        return sprint;
    }

    public async Task<Sprint> GetSprintBySlug(string stageSlug, int sprintNumber)
    {
        var (raceSlug, raceEditionYear, stageNum) = SplitStageSlug(stageSlug);

        var sprint = await _db.Sprints.Include(s => s.Stage)
                                      .Where(s => s.Stage.StageNumber == stageNum &&
                                                  s.Stage.RaceEdition.Year == raceEditionYear &&
                                                  s.Stage.RaceEdition.Race.Slug == raceSlug)
                                      .OrderBy(s => s.DistanceFromStartMeters)
                                      .Skip(sprintNumber - 1)
                                      .FirstOrDefaultAsync()
                                      ?? throw new EntityNotFoundException(nameof(Sprint), new { StageSlug = stageSlug, SprintNumber = sprintNumber });
        return sprint;
    }
}