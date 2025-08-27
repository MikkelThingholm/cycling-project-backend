using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;
using App.Services.Interfaces;


namespace App.Controllers;

[ApiController]
[Route("api/sprints")]
public class SprintController(ILogger<SprintController> logger, IRaceSetupService raceSetupService) : ControllerBase
{

    private readonly ILogger<SprintController> _logger = logger;
    private readonly IRaceSetupService _raceSetupService = raceSetupService;

    [HttpPut("{id:int}")]
    public async Task<ActionResult<SprintSimpleResponse>> UpdateSprint([FromRoute] int id, SprintUpdateRequest sprintUpdateRequest)
    {
        var sprint = await _raceSetupService.UpdateSprint(id, sprintUpdateRequest);
        return Ok(sprint);
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteSprint([FromRoute] int id)
    {
        await _raceSetupService.DeleteSprint(id);
        return NoContent();
    }

}





