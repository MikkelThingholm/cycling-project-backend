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
public class RaceEditionController(ILogger<RaceEditionController> logger, AppDbContext db, IRaceSetupService raceSetupService) : ControllerBase
{

    private readonly ILogger<RaceEditionController> _logger = logger;
    private readonly AppDbContext _db = db;
    private readonly IRaceSetupService _raceSetupService = raceSetupService;

    [HttpPost]
    public async Task<ActionResult<RaceEditionSimpleResponse>> CreateRaceEdition([FromBody] RaceEditionCreateRequest raceEditionCreateRequest)
    {
        var raceEdition = await _raceSetupService.CreateRaceEdition(raceEditionCreateRequest);

        return CreatedAtAction(nameof(GetRaceEditionById), new { id = raceEdition.Id }, raceEdition);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RaceEditionResponse>> GetRaceEditionById([FromRoute] int id)
    {
        var raceEdition = await _db.RaceEditions.Include(re => re.Race).Include(re => re.Stages).SingleOrDefaultAsync(re => re.Id == id);
        return Ok(raceEdition.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<RaceEditionSimpleResponse>> UpdateRaceEditionById([FromRoute] int id, [FromBody] RaceEditionUpdateRequest raceEditionUpdateRequest)
    {
        var raceEdition = await _raceSetupService.UpdateRaceEdition(id, raceEditionUpdateRequest);
        return Ok(raceEdition);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteRaceEditionById([FromRoute] int id)
    {
        await _raceSetupService.DeleteRaceEditionById(id);
        return NoContent();
    }

    [HttpPost("{raceEditionId:int}/stages")]
    public async Task<ActionResult<StageSimpleResponse>> CreateStage([FromRoute] int raceEditionId, StageCreateRequest stageCreateRequest)
    {
        var stage = await _raceSetupService.CreateStage(stageCreateRequest);
        return CreatedAtAction(nameof(GetStage), new { raceEditionId = raceEditionId, stageNum = stage.StageNumber }, stage);
    }

    [HttpGet("{raceEditionId:int}/stages/{stageNum:int}")]
    public async Task<ActionResult<StageResponse>> GetStage([FromRoute] int raceEditionId, [FromRoute] int stageNum)
    {
        var stage = await _db.Stages.Include(s => s.RaceEdition)
                            .Include(s => s.Sprints)
                            //.Include(s => s.MountainClimbs)
                            .SingleOrDefaultAsync(s => s.StageNumber == stageNum && s.RaceEditionId == raceEditionId);
        return Ok(stage.ToResponseDto());
    }

    [HttpPut("{raceEditionId:int}/stages/{stageNum:int}")]
    public async Task<ActionResult<StageSimpleResponse>> UpdateStage([FromRoute] int raceEditionId, [FromRoute] int stageNum, StageUpdateRequest stageUpdateRequest)
    {
        var stage = await _raceSetupService.UpdateStage(raceEditionId, stageNum, stageUpdateRequest);
        return Ok(stage);
    }


    [HttpDelete("{raceEditionId:int}/stages/{stageNum:int}")]
    public async Task<ActionResult> DeleteStageById([FromRoute] int raceEditionId, [FromRoute] int stageNum)
    {
        await _raceSetupService.DeleteStageById(raceEditionId, stageNum);
        return NoContent();
    }
}