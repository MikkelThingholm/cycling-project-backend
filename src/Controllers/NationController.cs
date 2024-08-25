using DataAccess;
using Microsoft.AspNetCore.Mvc;
using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extenstions;
using System.Net;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace cycling_project_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NationsController : ControllerBase
{
    private readonly ILogger<NationsController> _logger;
    private readonly AppDbContext _db;

    public NationsController(ILogger<NationsController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<NationResponse>> Get([FromRoute] int Id)
    {

        var nation = await _db.Nations.FindAsync(Id);

        if (nation is null)
        {
            return NotFound();
        }
        return Ok(nation.ToDto());
    }

    [HttpPost]
    public async Task<ActionResult<NationResponse>> Post([FromBody] NationCreateRequest nation)
    {

        Nation nationEntity = nation.ToEntity();
        await _db.Nations.AddAsync(nationEntity);

        int affected = await _db.SaveChangesAsync();


        return Ok(nationEntity.ToDto());
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<NationResponse>> Post([FromRoute] int Id)
    {

        int rowsAffected = await _db.Nations.Where(nation => nation.Id == Id).ExecuteDeleteAsync();
        
        if (rowsAffected == 0) {
            return NotFound();
        }
        
        return Ok();
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<NationResponse>> Post([FromRoute] int Id, [FromBody] NationPutRequest nation)
    {

        int rowsAffected = await _db.Nations
                                    .Where(n => n.Id == Id)
                                    .ExecuteUpdateAsync(updates =>
                                        updates.SetProperty(n => n.Name, nation.Name)
                                               .SetProperty(n => n.StillExists, nation.StillExists)  
        );

        if (rowsAffected == 0) {
            return NotFound();
        }

        return Ok(new NationResponse(Id:Id,Name:nation.Name,StillExists:nation.StillExists));
    }

}