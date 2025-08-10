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

    [HttpPost]
    public async Task<ActionResult<StageSimpleResponse>> CreateStage([FromRoute] int raceEditionId, StageCreateRequest stageCreateRequest)
    {
        var stage = await _raceSetupService.CreateStage(stageCreateRequest);
        return Created((string?)null, stage);
    }


    [HttpGet("{slug}")]
    public async Task<ActionResult<StageResponse>> GetStageBySlug([FromRoute] string slug)
    {
        var stage = await _raceQueryService.GetStageBySlug(slug);
        return Ok(stage.ToResponseDto());
    }


    [HttpPut("{slug}")]
    public async Task<ActionResult<StageSimpleResponse>> UpdateStage([FromRoute] string slug, StageUpdateRequest stageUpdateRequest)
    {
        var stage = await _raceSetupService.UpdateStage(slug, stageUpdateRequest);
        return Ok(stage);
    }


    [HttpDelete("{slug}")]
    public async Task<ActionResult> DeleteStage([FromRoute] string slug)
    {
        await _raceSetupService.DeleteStage(slug);
        return NoContent();
    }

    [HttpPost("{slug}/mountain-climbs")]
    public async Task<ActionResult<MountainClimbSimpleResponse>> CreateMountainClimb([FromRoute] string slug, MountainClimbCreateRequest mountainClimbCreateRequest)
    {
        var mountainClimb = await _raceSetupService.CreateMountainClimb(slug, mountainClimbCreateRequest);
        return Created((string?)null, mountainClimb);
    }

    [HttpGet("{slug}/mountain-climbs/{mountainClimbNumber:int}")]
    public async Task<ActionResult<MountainClimbResponse>> GetMountainClimb([FromRoute] string slug, [FromRoute] int mountainClimbNumber)
    {
        var mountainClimb = await _raceQueryService.GetMountainClimbBySlug(slug, mountainClimbNumber);
        return Ok(mountainClimb.ToResponseDto());
    }

    [HttpPut("{slug}/mountain-climbs/{mountainClimbNumber:int}")]
    public async Task<ActionResult<MountainClimbSimpleResponse>> UpdateMountainClimb([FromRoute] string slug, [FromRoute] int mountainClimbNumber, MountainClimbUpdateRequest mountainClimbUpdateRequest)
    {
        var mountainClimb = await _raceSetupService.UpdateMountainClimb(slug, mountainClimbNumber, mountainClimbUpdateRequest);
        return Ok(mountainClimb);
    }
    [HttpDelete("{slug}/mountain-climbs/{mountainClimbNumber:int}")]
    public async Task<ActionResult> DeleteMountainClimb([FromRoute] string slug, [FromRoute] int mountainClimbNumber)
    {
        await _raceSetupService.DeleteMountainClimb(slug, mountainClimbNumber);
        return NoContent();
    }


    [HttpPost("{slug}/sprints")]
    public async Task<ActionResult<SprintSimpleResponse>> CreateSprint([FromRoute] string slug, SprintCreateRequest sprintCreateRequest)
    {
        var sprint = await _raceSetupService.CreateSprint(sprintCreateRequest);
        return Created((string?)null, sprint);
    }

    [HttpGet("{slug}/sprints/{sprintNumber:int}")]
    public async Task<ActionResult<SprintResponse>> GetSprint([FromRoute] string slug, [FromRoute] int sprintNumber)
    {
        var sprint = await _raceQueryService.GetSprintBySlug(slug, sprintNumber);
        return Ok(sprint.ToResponseDto());
    }
    [HttpPut("{slug}/sprints/{sprintNumber:int}")]
    public async Task<ActionResult<SprintSimpleResponse>> UpdateSprint([FromRoute] string slug, [FromRoute] int sprintNumber, SprintUpdateRequest sprintUpdateRequest)
    {
        var sprint = await _raceSetupService.UpdateSprint(slug, sprintNumber, sprintUpdateRequest);
        return Ok(sprint);
    }
    [HttpDelete("{slug}/sprints/{sprintNumber:int}")]
    public async Task<ActionResult> DeleteSprint([FromRoute] string slug, [FromRoute] int sprintNumber)
    {
        await _raceSetupService.DeleteSprint(slug, sprintNumber);
        return NoContent();
    }

}