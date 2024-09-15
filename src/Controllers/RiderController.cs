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
[Route("api/[controller]s")]
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
    public async Task<ActionResult<RiderCreateResponse>> Post([FromBody] RiderCreateRequest riderCreateRequests)
    {

        
        Rider riderEntity = riderCreateRequests.ToEntity();

        await _db.Riders.AddAsync(riderEntity);

        int rowsAffected = await _db.SaveChangesAsync();

        if (rowsAffected == 0) 
        {
            return BadRequest();
        }

        return Created(riderEntity.Id.ToString(), riderEntity.ToDtoCreate());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<RiderResponse>> Get([FromRoute] int Id)
    {
        Rider? rider = await _db.Riders.Include(rider => rider.Nation)
                                .FirstOrDefaultAsync(rider => rider.Id == Id);

        if (rider is null) 
        { 
            return NotFound();
        }
   
        return Ok(rider.ToDto());
    }
    
    [HttpPut("{Id:int}")]
    public async Task<ActionResult<RiderUpdateResponse>> Patch([FromRoute] int Id, [FromBody] RiderUpdateRequest riderUpdateRequest)
    {
        Rider? rider = await _db.Riders.FirstOrDefaultAsync(rider => rider.Id == Id);

        if (rider is null) 
        { 
            return NotFound();
        }

        _db.Entry(rider).CurrentValues.SetValues(riderUpdateRequest.ToEntity(Id));
        await _db.SaveChangesAsync();
        return Ok(rider.ToDtoUpdate());
    }
    

    [HttpDelete("{Id:int}")]
    public async Task<ActionResult<RiderResponse>> Delete([FromRoute]int Id)
    {

        _db.Riders.Remove(new(){Id=Id});

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

