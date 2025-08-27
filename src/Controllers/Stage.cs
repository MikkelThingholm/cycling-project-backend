using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;
using App.Services.Interfaces;


namespace App.Controllers;

[ApiController]
[Route("api/stages")]
public class StageController(ILogger<StageController> logger, IRaceSetupService raceSetupService, IRaceQueryService raceQueryService) : ControllerBase
{

    private readonly ILogger<StageController> _logger = logger;
    private readonly IRaceSetupService _raceSetupService = raceSetupService;
    private readonly IRaceQueryService _raceQueryService = raceQueryService;


    [HttpGet("{id:int}")]
    public async Task<ActionResult<StageResponse>> GetStage([FromRoute] int id)
    {
        var stage = await _raceQueryService.GetStageById(id);
        return Ok(stage.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<StageSimpleResponse>> UpdateStage([FromRoute] int id, StageUpdateRequest stageUpdateRequest)
    {
        var stage = await _raceSetupService.UpdateStage(id, stageUpdateRequest);
        return Ok(stage);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteStage([FromRoute] int id)
    {
        await _raceSetupService.DeleteStage(id);
        return NoContent();
    }

    [HttpPost("{id:int}/mountain-climbs")]
    public async Task<ActionResult<MountainClimbSimpleResponse>> CreateMountainClimb([FromRoute] int id, MountainClimbCreateRequest mountainClimbCreateRequest)
    {
        var mountainClimb = await _raceSetupService.CreateMountainClimb(id, mountainClimbCreateRequest);
        return Created((string?)null, mountainClimb);
    }

    [HttpPost("{id:int}/sprints")]
    public async Task<ActionResult<SprintSimpleResponse>> CreateSprint([FromRoute] int id, SprintCreateRequest sprintCreateRequest)
    {
        var sprint = await _raceSetupService.CreateSprint(id, sprintCreateRequest);
        return Created((string?)null, sprint);
    }

}