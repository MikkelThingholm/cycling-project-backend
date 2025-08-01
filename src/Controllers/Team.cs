using Microsoft.AspNetCore.Mvc;
using App.Data;
using App.Dto;
using App.Services.Interfaces;


namespace App.Controllers;

[ApiController]
[Route("api/teams")]
public class TeamController(ILogger<TeamController> logger, AppDbContext db, IRiderTeamService riderTeamService) : ControllerBase
{

    private readonly ILogger<TeamController> _logger = logger;
    private readonly AppDbContext _db = db;
    private readonly IRiderTeamService _riderTeamService = riderTeamService;

    [HttpPost]
    public async Task<ActionResult<TeamSimpleResponse>> CreateTeam([FromBody] TeamCreateRequest teamCreateRequest)
    {
        var team = await _riderTeamService.CreateTeam(teamCreateRequest);
        return CreatedAtAction(nameof(GetTeamById), new { id = team.Id }, team);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TeamResponse>> GetTeamById([FromRoute] int id)
    {
        var team = await _riderTeamService.GetTeamById(id);

        return Ok(team);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TeamSimpleResponse>> UpdateTeamById([FromRoute] int id, [FromBody] TeamUpdateRequest teamUpdateRequest)
    {
        var team = await _riderTeamService.UpdateTeam(id, teamUpdateRequest);
        return Ok(team);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTeamById([FromRoute] int id)
    {
        await _riderTeamService.RemoveTeam(id);
        return NoContent();
    }
}