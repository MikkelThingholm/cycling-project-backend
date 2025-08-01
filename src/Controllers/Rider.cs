using Microsoft.AspNetCore.Mvc;
using App.Data;
using App.Dto;
using App.Services.Interfaces;


namespace App.Controllers;

[ApiController]
[Route("api/riders")]
public class RiderController(ILogger<RiderController> logger, AppDbContext db, IRiderTeamService riderTeamService) : ControllerBase
{

    private readonly ILogger<RiderController> _logger = logger;
    private readonly AppDbContext _db = db;
    private readonly IRiderTeamService _riderTeamService = riderTeamService;

    [HttpPost]
    public async Task<ActionResult<RiderSimpleResponse>> CreateRider([FromBody] RiderCreateRequest riderCreateRequests)
    {
        var rider = await _riderTeamService.CreateRider(riderCreateRequests);

        return CreatedAtAction(nameof(GetRiderById), new { id = rider.Id }, rider);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RiderResponse>> GetRiderById([FromRoute] int id)
    {
        var rider = await _riderTeamService.GetRiderById(id);

        return Ok(rider);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<RiderSimpleResponse>> UpdateRiderById([FromRoute] int id, [FromBody] RiderUpdateRequest riderUpdateRequest)
    {
        var rider = await _riderTeamService.UpdateRider(id, riderUpdateRequest);
        return Ok(rider);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<RiderResponse>> Delete([FromRoute] int id)
    {
        await _riderTeamService.RemoveRider(id);

        return NoContent();
    }

    [HttpPost("{riderId:int}/teams/{teamId:int}")]
    public async Task<ActionResult> AddRiderToTeam([FromRoute] int riderId, [FromRoute] int teamId, [FromBody] RiderTeamCreateRequest riderTeamCreateRequest)
    {
        var riderTeam = await _riderTeamService.AssignRiderToTeam(riderId, teamId, riderTeamCreateRequest);
        return Created((string?)null, riderTeam);
    }

    [HttpDelete("{riderId:int}/teams/{teamId:int}")]
    public async Task<ActionResult> RemoveRiderFromTeam([FromRoute] int riderId, [FromRoute] int teamId)
    {
        await _riderTeamService.RemoveRiderFromTeam(riderId, teamId);
        return NoContent();
    }

    [HttpPut("{riderId:int}/teams/{teamId:int}")]
    public async Task<ActionResult<RiderTeamSimpleResponse>> UpdateRiderTeamAssignment([FromRoute] int riderId, [FromRoute] int teamId, [FromBody] RiderTeamUpdateRequest riderTeamUpdateRequest)
    {
        var riderTeam = await _riderTeamService.UpdateRiderTeamAssignment(riderId, teamId, riderTeamUpdateRequest);
        return Ok(riderTeam);
    }

}

