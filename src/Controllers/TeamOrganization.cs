using Microsoft.AspNetCore.Mvc;
using App.Data;
using App.Dto;
using App.Services.Interfaces;


namespace App.Controllers;

[ApiController]
[Route("api/team-organizations")]
public class TeamOrganizationController(ILogger<TeamOrganizationController> logger, AppDbContext db, IRiderTeamService riderTeamService) : ControllerBase
{

    private readonly ILogger<TeamOrganizationController> _logger = logger;
    private readonly AppDbContext _db = db;
    private readonly IRiderTeamService _riderTeamService = riderTeamService;

    [HttpPost]
    public async Task<ActionResult<TeamOrganizationSimpleResponse>> CreateTeamOrganization()
    {
        var teamOrganization = await _riderTeamService.CreateTeamOrganization();
        return Created((string?)null, teamOrganization);
    }

    [HttpGet]
    public async Task<ActionResult<List<TeamOrganizationResponse>>> GetAllTeamOrganization()
    {
        var teamOrganizations = await _riderTeamService.GetAllTeamOrganizations();

        return Ok(teamOrganizations);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTeamOrganizationById([FromRoute] int id)
    {
        await _riderTeamService.RemoveTeamOrganization(id);
        return NoContent();
    }
}