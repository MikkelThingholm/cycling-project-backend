using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;


namespace App.Controllers;

[ApiController]
[Route("api/riders")]
public class RiderController(ILogger<RiderController> logger, AppDbContext db) : ControllerBase
{

    private readonly ILogger<RiderController> _logger = logger;
    private readonly AppDbContext _db = db;

    [HttpPost]
    public async Task<ActionResult<RiderSimpleResponse>> CreateRider([FromBody] RiderCreateRequest riderCreateRequests)
    {


        Rider riderEntity = riderCreateRequests.ToEntity();

        await _db.Riders.AddAsync(riderEntity);

        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRiderById), new { id = riderEntity.Id }, riderEntity.ToResponseDto());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RiderResponse>> GetRiderById([FromRoute] int Id)
    {
        Rider? rider = await _db.Riders.Include(rider => rider.Nation)
                                .FirstOrDefaultAsync(rider => rider.Id == Id);

        if (rider is null)
        {
            return NotFound();
        }

        return Ok(rider.ToResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<RiderSimpleResponse>> UpdateRiderById([FromRoute] int id, [FromBody] RiderUpdateRequest riderUpdateRequest)
    {
        Rider? rider = await _db.Riders.FirstOrDefaultAsync(rider => rider.Id == id);

        if (rider is null)
        {
            return NotFound();
        }

        _db.Entry(rider).CurrentValues.SetValues(riderUpdateRequest.ToEntity(id));
        await _db.SaveChangesAsync();
        return Ok(rider.ToUpdateResponseDto());
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<RiderResponse>> Delete([FromRoute] int id)
    {
        _db.Riders.Remove(new() { Id = id });

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

