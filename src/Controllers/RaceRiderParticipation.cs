using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;


namespace App.Controllers;

[ApiController]
[Route("api/races")]
public class RaceRiderParticipationController(ILogger<RaceRiderParticipationController> logger, AppDbContext db) : ControllerBase
{

    private readonly ILogger<RaceRiderParticipationController> _logger = logger;
    private readonly AppDbContext _db = db;

    [HttpPost]
    public async Task<ActionResult<RaceRiderParticipationSimpleResponse>> CreateRaceRiderParticipation([FromBody] RaceRiderParticipationCreateRequest raceRiderParticipationCreateRequest)
    {


        var raceRiderParticipationEntity = raceRiderParticipationCreateRequest.ToEntity();

        await _db.RaceRiderParticipations.AddAsync(raceRiderParticipationEntity);

        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRaceRiderParticipationById), new { id = raceRiderParticipationEntity.Id }, raceRiderParticipationEntity.ToSimpleResponseDto());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RaceRiderParticipationResponse>> GetRaceRiderParticipationById([FromRoute] int id)
    {

        var raceEntity = await _db.RaceRiderParticipations.FirstOrDefaultAsync(x => x.Id == id);

        if (raceEntity is null)
        {
            return NotFound();
        }

        return Ok(raceEntity.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<RaceRiderParticipationSimpleResponse>> UpdateRaceRiderParticipationById([FromRoute] int id, [FromBody] RaceRiderParticipationUpdateRequest raceRiderParticipationRequest)
    {
        var raceRiderParticipationsEntity = await _db.RaceRiderParticipations.FirstOrDefaultAsync(x => x.Id == id);

        if (raceRiderParticipationsEntity is null)
        {
            return NotFound();
        }

        raceRiderParticipationsEntity.UpdateFromDto(raceRiderParticipationRequest);

        await _db.SaveChangesAsync();
        return Ok(raceRiderParticipationsEntity.ToSimpleResponseDto());
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteRaceRiderParticipationById([FromRoute] int id)
    {
        _db.RaceRiderParticipations.Remove(new() { Id = id });

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return NotFound();
        }

        return NoContent();
    }



}

