using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;
using App.Services.Interfaces;


namespace App.Controllers;

[ApiController]
[Route("api/mountain-climbs")]
public class MountainClimbController(ILogger<MountainClimbController> logger, IRaceSetupService raceSetupService) : ControllerBase
{

    private readonly ILogger<MountainClimbController> _logger = logger;

    private readonly IRaceSetupService _raceSetupService = raceSetupService;

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MountainClimbSimpleResponse>> UpdateMountainClimb([FromRoute] int id, [FromRoute] int mountainClimbNumber, MountainClimbUpdateRequest mountainClimbUpdateRequest)
    {
        var mountainClimb = await _raceSetupService.UpdateMountainClimb(id, mountainClimbUpdateRequest);
        return Ok(mountainClimb);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMountainClimb([FromRoute] int id)
    {
        await _raceSetupService.DeleteMountainClimb(id);
        return NoContent();
    }

}

