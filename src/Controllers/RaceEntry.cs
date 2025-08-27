using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Services.Interfaces;
using App.Extensions;


namespace App.Controllers;

[ApiController]
[Route("api/race-editions/{raceEditionId:int}/")]
public class RaceEntryController(ILogger<RaceEntryController> logger, IRaceEntryService raceEntryService) : ControllerBase
{
    private readonly ILogger<RaceEntryController> _logger = logger;
    private readonly IRaceEntryService _raceEntryService = raceEntryService;


    [HttpPost("teams")]
    public async Task<ActionResult> TeamRaceEntry([FromRoute] int raceEditionId, [FromBody] RaceTeamParticipationCreateRequest request)
    {
        await _raceEntryService.TeamRaceEntry(request.TeamId, raceEditionId);
        return Created();
    }

    [HttpPost("riders")]
    public async Task<ActionResult> RiderRaceEntry([FromRoute] int raceEditionId, [FromBody] RiderRaceEntryCreateRequest request)
    {
        await _raceEntryService.RiderRaceEntry(request.RiderId, raceEditionId);
        return Created();
    }

    [HttpDelete("teams/{teamId:int}")]
    public async Task<ActionResult> RemoveTeamFromRaceEdition([FromRoute] int teamId, [FromRoute] int raceEditionId)
    {
        await _raceEntryService.DeleteTeamRaceEntry(teamId, raceEditionId);
        return NoContent();
    }
    [HttpDelete("riders/{riderId:int}")]
    public async Task<ActionResult> RemoveRiderFromRaceEdition([FromRoute] int riderId, [FromRoute] int raceEditionId)
    {
        await _raceEntryService.DeleteRiderRaceEntry(riderId, raceEditionId);
        return NoContent();
    }
}