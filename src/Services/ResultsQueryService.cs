using App.Services.Interfaces;
using App.Data;
using App.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class ResultsQueryService(ILogger<ResultsQueryService> logger, AppDbContext db, IRaceQueryService raceQueryService)
{
    private readonly ILogger<ResultsQueryService> _logger = logger;
    private readonly AppDbContext _db = db;
    private readonly IRaceQueryService _raceQueryService = raceQueryService;

    // Team stage results

    public async Task<IEnumerable<StageTeamResult>> GetStageTeamResults(int stageId)
    {
        var StageTeamResults = await _db.StageTeamResults
                                .Include(r => r.RaceTeamParticipation)
                                .ThenInclude(rtp => rtp.Team)
                                .Where(r => r.StageId == stageId)
                                .OrderBy(r => r.Placement)
                                .ToListAsync();

        return StageTeamResults;
    }

    // Rider stage results

    public async Task<IEnumerable<StageRiderResult>> GetStageRiderResults(int stageId)
    {
        var stageRiderResults = await _db.StageRiderResults
                                .Include(r => r.RaceRiderParticipation)
                                .ThenInclude(rrp => rrp.Rider)
                                .Include(r => r.RaceRiderParticipation)
                                .ThenInclude(rrp => rrp.RaceTeamParticipation)
                                .ThenInclude(rtp => rtp.Team)
                                .Where(r => r.StageId == stageId)
                                .OrderBy(r => r.Placement)
                                .ToListAsync();

        return stageRiderResults;
    }

    // Mountain Climb Results

    public async Task<IEnumerable<MountainClimbResult>> GetMountainClimbResults(int mountainClimbId)
    {
        var mountainClimbResults = await _db.MountainClimbResults
                                        .Include(m => m.RaceRiderParticipation)
                                        .ThenInclude(rrp => rrp.Rider)
                                        .OrderBy(m => m.Placement)
                                        .Where(m => m.MountainClimbId == mountainClimbId)
                                        .ToListAsync();

        return mountainClimbResults;
    }

    // Sprint Results

    public async Task<IEnumerable<SprintResult>> GetSprintResults(int sprintId)
    {
        var sprintResults = await _db.SprintResults
                                .Include(s => s.RaceRiderParticipation)
                                .ThenInclude(rrp => rrp.Rider)
                                .OrderBy(s => s.Placement)
                                .Where(s => s.SprintId == sprintId)
                                .ToListAsync();
        return sprintResults;
    }


}