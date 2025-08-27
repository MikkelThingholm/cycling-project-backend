using App.Services.Interfaces;
using App.Data;
using App.EntityModels;
using App.Exceptions;

namespace App.Services;


public class ResultsSetupService(ILogger<ResultsSetupService> logger, AppDbContext db, IRaceQueryService raceQueryService) : IResultsSetupService
{
    private readonly ILogger<ResultsSetupService> _logger = logger;
    private readonly AppDbContext _db = db;
    private readonly IRaceQueryService _raceQueryService = raceQueryService;

    // Team stage results

    private static void ValidateValidStageTeamResult(List<StageTeamResult> existingResults, StageTeamResult newResult)
    {
        if (existingResults.Count == 0)
        {
            return;
        }

        var higherPlacementResults = existingResults.Where(r => r.Placement < newResult.Placement);
        var lowerPlacementResults = existingResults.Where(r => r.Placement > newResult.Placement);

        if (higherPlacementResults.Any(r => r.FinishTimeMilliseconds > newResult.FinishTimeMilliseconds))
        {
            throw new BusinessRuleViolationException($"New stage team result with placement {newResult.Placement} and finish time {newResult.FinishTimeMilliseconds}ms has finish time lower than a higher placement result");
        }

        if (lowerPlacementResults.Any(r => r.FinishTimeMilliseconds < newResult.FinishTimeMilliseconds))
        {
            throw new BusinessRuleViolationException($"New stage team result with placement {newResult.Placement} and finish time {newResult.FinishTimeMilliseconds}ms has finish time greater than a lower placement result");
        }

    }



}