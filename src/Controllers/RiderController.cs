using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using App.Dto;
using App.Extenstions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace cycling_project_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RiderController : ControllerBase
{

    private readonly ILogger<RiderController> _logger;
    private readonly AppDbContext _db;

    public RiderController(ILogger<RiderController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpPost]
    public async Task<ActionResult<RiderResponse>> Post([FromBody] RiderCreateRequest riderCreateRequests)
    {

        if (riderCreateRequests == null)
        {
            return BadRequest();
        }
        _logger.LogInformation(riderCreateRequests.ToString());
        Rider riderEntity = riderCreateRequests.ToEntity();

        await _db.Riders.AddAsync(riderEntity);

        int rowsAffected = await _db.SaveChangesAsync();
        if (rowsAffected == 0) {
            return BadRequest();
        }

        return Created(riderEntity.Id.ToString(), riderEntity);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<RiderResponse>> Get([FromRoute] int Id)
    {
        
        Rider rider = await _db.Riders.Include(rider => rider.Nation).Where(rider => rider.Id == Id).FirstAsync();

        if (rider is null)
        {
            return NotFound();
        }

        return Ok(rider.ToDto());
    }

    [HttpPatch]
    public async Task<ActionResult<RiderResponse>?> Patch([FromBody] List<RiderUpdateRequest> riderUpdateRequests)
    {
        if (riderUpdateRequests == null)
        {
            return BadRequest();
        }

        List<Rider> riders = riderUpdateRequests.Select(i => i.ToEntity()).ToList();

        /* foreach (var rider in riders)
        {
            await _db.Riders.Update(rider);
        }

        await _db.Riders.UpdateRange(riders); */

        int affected = await _db.SaveChangesAsync();


        
        return null;
    }

    [HttpDelete]
    public async Task<ActionResult<RiderResponse>> Delete(int Id)
    {
        //Rider? rider = await _db.Riders.FindAsync(Id);
        Rider rider = new(){Id=Id};

        var a = _db.Riders.Remove(rider);
        int affected = 0;
        try
        {
            affected = await _db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogInformation(e.Message);
        }

        if (affected == 1)
        {
            _logger.LogInformation("affected == 1");
        }
        
        return Ok(rider);
    }

    
}

