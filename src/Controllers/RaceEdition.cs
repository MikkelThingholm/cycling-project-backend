using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;


namespace App.Controllers;

[ApiController]
[Route("api/race-editions")]
public class RaceEditionController(ILogger<RaceEditionController> logger, AppDbContext db) : ControllerBase
{

    private readonly ILogger<RaceEditionController> _logger = logger;
    private readonly AppDbContext _db = db;

    [HttpPost]
    public async Task<ActionResult<RaceEditionSimpleResponse>> CreateRaceEdition([FromBody] RaceEditionCreateRequest raceEditionCreateRequest)
    {


        var raceEditionEntity = raceEditionCreateRequest.ToEntity();

        await _db.RaceEditions.AddAsync(raceEditionEntity);

        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRaceEditionById), new { id = raceEditionEntity.Id }, raceEditionEntity.ToSimpleResponseDto());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RaceEditionResponse>> GetRaceEditionById([FromRoute] int id)
    {

        var raceEntity = await _db.Races.Include(raceEdition => raceEdition.Nation)
                                .FirstOrDefaultAsync(raceEdition => raceEdition.Id == id);

        if (raceEntity is null)
        {
            return NotFound();
        }

        return Ok(raceEntity.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<RaceEditionSimpleResponse>> UpdateRaceEditionById([FromRoute] int id, [FromBody] RaceEditionUpdateRequest raceEditionUpdateRequest)
    {
        var raceEditionEntity = await _db.RaceEditions.FirstOrDefaultAsync(raceEdition => raceEdition.Id == id);

        if (raceEditionEntity is null)
        {
            return NotFound();
        }

        raceEditionEntity.UpdateFromDto(raceEditionUpdateRequest);

        await _db.SaveChangesAsync();
        return Ok(raceEditionEntity.ToSimpleResponseDto());
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteRaceEditionById([FromRoute] int id)
    {
        _db.RaceEditions.Remove(new() { Id = id });

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

