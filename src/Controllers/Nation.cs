using App.Data;
using Microsoft.AspNetCore.Mvc;
using App.EntityModels;
using Microsoft.EntityFrameworkCore;
using App.Dto;
using App.Extensions;
using System.Net;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace App.Controllers;

[ApiController]
[Route("api/nations")]
public class NationsController(ILogger<NationsController> logger, AppDbContext db) : ControllerBase
{
    private readonly ILogger<NationsController> _logger = logger;
    private readonly AppDbContext _db = db;

    [HttpGet("{id}")]
    public async Task<ActionResult<NationResponse>> Get([FromRoute] int id)
    {

        var nation = await _db.Nations.FindAsync(id);

        if (nation is null)
        {
            return NotFound();
        }
        return Ok(nation.ToResponseDto());
    }

    [HttpPost]
    public async Task<ActionResult<NationResponse>> Post([FromBody] NationCreateRequest nation)
    {

        Nation nationEntity = nation.ToEntity();
        await _db.Nations.AddAsync(nationEntity);

        await _db.SaveChangesAsync();

        return Ok(nationEntity.ToResponseDto());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<NationResponse>> Post([FromRoute] int id)
    {

        int rowsAffected = await _db.Nations.Where(nation => nation.Id == id).ExecuteDeleteAsync();

        if (rowsAffected == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<NationResponse>> Put([FromRoute] int id, [FromBody] NationUpdateRequest nationUpdate)
    {

        Nation? nation = await _db.Nations.FirstOrDefaultAsync(nation => nation.Id == id);

        if (nation is null)
        {
            return NotFound();
        }

        nation.UpdateFromDto(nationUpdate);
        await _db.SaveChangesAsync();
        return Ok(nation.ToResponseDto());
    }

}