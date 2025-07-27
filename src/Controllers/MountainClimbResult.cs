using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;


namespace App.Controllers;
/*
[ApiController]
[Route("api/mountain-climbs")]
public class MountainClimbResultController(ILogger<MountainClimbResultController> logger, AppDbContext db) : ControllerBase
{

    private readonly ILogger<MountainClimbResultController> _logger = logger;
    private readonly AppDbContext _db = db;

    [HttpPost]
    public async Task<ActionResult<MountainClimbSimpleResponse>> CreateMountainClimbResult([FromBody] MountainClimbCreateRequest mountainClimbCreateRequest)
    {


        var mountainClimbEntity = mountainClimbCreateRequest.ToEntity();

        await _db.Race.AddAsync(mountainClimbEntity);

        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMountainClimbById), new { id = mountainClimbEntity.Id }, mountainClimbEntity.ToSimpleResponseDto());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MountainClimbResponse>> GetMountainClimbById([FromRoute] int id)
    {

        var mountainClimb = await _db.Race.Include(mountainClimb => mountainClimb.Mountain)
                                .Include(mountainClimb => mountainClimb.Stage)
                                .FirstOrDefaultAsync(mountainClimb => mountainClimb.Id == id);

        if (mountainClimb is null)
        {
            return NotFound();
        }

        return Ok(mountainClimb.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MountainClimbSimpleResponse>> UpdateMountainClimbById([FromRoute] int id, [FromBody] MountainClimbUpdateRequest mountainClimbUpdateRequest)
    {
        MountainClimb? mountainClimb = await _db.Race.FirstOrDefaultAsync(mountain => mountain.Id == id);

        if (mountainClimb is null)
        {
            return NotFound();
        }

        mountainClimb.UpdateFromDto(mountainClimbUpdateRequest);
        await _db.SaveChangesAsync();
        return Ok(mountainClimb.ToSimpleResponseDto());
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<MountainClimbResponse>> DeleteMountainClimbById([FromRoute] int id)
    {
        _db.Race.Remove(new() { Id = id });

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

*/