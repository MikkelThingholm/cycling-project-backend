using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;


namespace App.Controllers;

[ApiController]
[Route("api/mountains")]
public class MountainController(ILogger<MountainController> logger, AppDbContext db) : ControllerBase
{

    private readonly ILogger<MountainController> _logger = logger;
    private readonly AppDbContext _db = db;

    [HttpPost]
    public async Task<ActionResult<MountainResponse>> CreateMountain([FromBody] MountainCreateRequest mountainCreateRequest)
    {


        var mountainEntity = mountainCreateRequest.ToEntity();

        await _db.Mountains.AddAsync(mountainEntity);

        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMountainById), new { id = mountainEntity.Id }, mountainEntity.ToResponseDto());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MountainResponse>> GetMountainById([FromRoute] int id)
    {

        var mountain = await _db.Mountains.Include(mountain => mountain.MountainClimbs)
                                .FirstOrDefaultAsync(mountain => mountain.Id == id);

        if (mountain is null)
        {
            return NotFound();
        }

        return Ok(mountain.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MountainResponse>> UpdateMountainById([FromRoute] int id, [FromBody] MountainUpdateRequest mountainUpdateRequest)
    {
        Mountain? mountain = await _db.Mountains.FirstOrDefaultAsync(mountain => mountain.Id == id);

        if (mountain is null)
        {
            return NotFound();
        }

        mountain.UpdateFromDto(mountainUpdateRequest);
        await _db.SaveChangesAsync();
        return Ok(mountain.ToResponseDto());
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<MountainResponse>> DeleteMountainById([FromRoute] int id)
    {
        _db.Mountains.Remove(new() { Id = id });

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

