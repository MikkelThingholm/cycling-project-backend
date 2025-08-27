using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;
using App.Services.Interfaces;


namespace App.Controllers;

[ApiController]
[Route("api/race-editions")]
public class RaceEditionController(ILogger<RaceEditionController> logger, IRaceSetupService raceSetupService, IRaceQueryService raceQueryService) : ControllerBase
{

    private readonly ILogger<RaceEditionController> _logger = logger;
    private readonly IRaceSetupService _raceSetupService = raceSetupService;
    private readonly IRaceQueryService _raceQueryService = raceQueryService;


    [HttpGet("{id:int}")]
    public async Task<ActionResult<RaceEditionResponse>> GetRaceEdition([FromRoute] int id)
    {
        var raceEdition = await _raceQueryService.GetRaceEditionById(id);
        return Ok(raceEdition.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<RaceEditionSimpleResponse>> UpdateRaceEdition([FromRoute] int id, [FromBody] RaceEditionUpdateRequest raceEditionUpdateRequest)
    {
        var raceEdition = await _raceSetupService.UpdateRaceEdition(id, raceEditionUpdateRequest);
        return Ok(raceEdition);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteRaceEditionById([FromRoute] int id)
    {
        await _raceSetupService.DeleteRaceEdition(id);
        return NoContent();
    }

    [HttpPost("{id:int}/stages")]
    public async Task<ActionResult<StageSimpleResponse>> CreateStage([FromRoute] int id, StageCreateRequest stageCreateRequest)
    {
        var stage = await _raceSetupService.CreateStage(id, stageCreateRequest);
        return Created((string?)null, stage);
    }

}