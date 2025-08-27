using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;
using App.Services.Interfaces;


namespace App.Controllers;

[ApiController]
[Route("api/races")]
public class RaceController(ILogger<RaceController> logger, IRaceSetupService raceSetupService, IRaceQueryService raceQueryService) : ControllerBase
{

    private readonly ILogger<RaceController> _logger = logger;
    private readonly IRaceSetupService _raceSetupService = raceSetupService;
    private readonly IRaceQueryService _raceQueryService = raceQueryService;

    [HttpPost]
    public async Task<ActionResult<RaceSimpleResponse>> CreateRace([FromBody] RaceCreateRequest raceCreateRequest)
    {
        var race = await _raceSetupService.CreateRace(raceCreateRequest);
        return CreatedAtAction(nameof(GetRace), new { slug = race.Slug }, race);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RaceResponse>> GetRace([FromRoute] int id)
    {

        var race = await _raceQueryService.GetRaceById(id);

        return Ok(race.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<RaceSimpleResponse>> UpdateRace([FromRoute] int id, [FromBody] RaceUpdateRequest raceUpdateRequest)
    {
        var race = await _raceSetupService.UpdateRace(id, raceUpdateRequest);
        return Ok(race);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteRace([FromRoute] int id)
    {
        await _raceSetupService.DeleteRace(id);
        return NoContent();
    }

    [HttpPost("{id:int}/race-editions")]
    public async Task<ActionResult<RaceEditionSimpleResponse>> CreateRaceEdition([FromRoute] int id, [FromBody] RaceEditionCreateRequest raceEditionCreateRequest)
    {
        var raceEdition = await _raceSetupService.CreateRaceEdition(id, raceEditionCreateRequest);
        return Created((string?)null, raceEdition);
    }
}

