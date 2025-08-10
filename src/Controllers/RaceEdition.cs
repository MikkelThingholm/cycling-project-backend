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

    [HttpPost]
    public async Task<ActionResult<RaceEditionSimpleResponse>> CreateRaceEdition([FromBody] RaceEditionCreateRequest raceEditionCreateRequest)
    {
        var raceEdition = await _raceSetupService.CreateRaceEdition(raceEditionCreateRequest);

        return Created((string?)null, raceEdition);
    }

    [HttpGet("{slug}")]
    public async Task<ActionResult<RaceEditionResponse>> GetRaceEdition([FromRoute] string slug)
    {
        var raceEdition = await _raceQueryService.GetRaceEditionBySlug(slug);
        return Ok(raceEdition.ToResponseDto());
    }

    [HttpPut("{slug}")]
    public async Task<ActionResult<RaceEditionSimpleResponse>> UpdateRaceEdition([FromRoute] string slug, [FromBody] RaceEditionUpdateRequest raceEditionUpdateRequest)
    {
        var raceEdition = await _raceSetupService.UpdateRaceEdition(slug, raceEditionUpdateRequest);
        return Ok(raceEdition);
    }


    [HttpDelete("{slug}")]
    public async Task<ActionResult> DeleteRaceEditionById([FromRoute] string slug)
    {
        await _raceSetupService.DeleteRaceEdition(slug);
        return NoContent();
    }

}