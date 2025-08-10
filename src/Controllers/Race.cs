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

    [HttpGet("{slug}")]
    public async Task<ActionResult<RaceResponse>> GetRace([FromRoute] string slug)
    {

        var race = await _raceQueryService.GetRaceBySlug(slug);

        return Ok(race.ToResponseDto());
    }

    [HttpPut("{slug}")]
    public async Task<ActionResult<RaceSimpleResponse>> UpdateRace([FromRoute] string slug, [FromBody] RaceUpdateRequest raceUpdateRequest)
    {
        var race = await _raceSetupService.UpdateRace(slug, raceUpdateRequest);
        return Ok(race);
    }


    [HttpDelete("{slug}")]
    public async Task<ActionResult> DeleteRace([FromRoute] string slug)
    {
        await _raceSetupService.DeleteRace(slug);
        return NoContent();
    }

    [HttpPost("{slug}/race-editions")]
    public async Task<ActionResult<RaceEditionSimpleResponse>> CreateRaceEdition([FromRoute] string slug, [FromBody] RaceEditionCreateRequest raceEditionCreateRequest)
    {
        var raceEdition = await _raceSetupService.CreateRaceEdition(raceEditionCreateRequest);

        return Created((string?)null, raceEdition);
    }
}

