using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;


namespace App.Controllers;

[ApiController]
[Route("api/races")]
public class RaceController(ILogger<RaceController> logger, AppDbContext db) : ControllerBase
{

    private readonly ILogger<RaceController> _logger = logger;
    private readonly AppDbContext _db = db;

    [HttpPost]
    public async Task<ActionResult<RaceSimpleResponse>> CreateRace([FromBody] RaceCreateRequest raceCreateRequest)
    {


        var raceEntity = raceCreateRequest.ToEntity();

        await _db.Races.AddAsync(raceEntity);

        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRaceById), new { id = raceEntity.Id }, raceEntity.ToSimpleResponseDto());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RaceResponse>> GetRaceById([FromRoute] int id)
    {

        var raceEntity = await _db.Races.Include(race => race.Nation)
                                .FirstOrDefaultAsync(race => race.Id == id);

        if (raceEntity is null)
        {
            return NotFound();
        }

        return Ok(raceEntity.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<RaceSimpleResponse>> UpdateRaceById([FromRoute] int id, [FromBody] RaceUpdateRequest raceUpdateRequest)
    {
        var raceEntity = await _db.Races.FirstOrDefaultAsync(race => race.Id == id);

        if (raceEntity is null)
        {
            return NotFound();
        }

        raceEntity.UpdateFromDto(raceUpdateRequest);
        await _db.SaveChangesAsync();
        return Ok(raceEntity.ToSimpleResponseDto());
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteRaceById([FromRoute] int id)
    {
        _db.Races.Remove(new() { Id = id });

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

