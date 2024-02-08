using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace cycling_project_web_api.Controllers
{
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

        [HttpGet]
        public async Task<ActionResult<List<Rider>>> Get(int Id)
        {
            _logger.LogInformation("get");
            var rider = await _db.Riders.FindAsync(Id);
            if (rider is null)
            {
                return NotFound();
            }

            return Ok(rider);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Rider>>> Delete(int Id)
        {
            //Rider? rider = await _db.Riders.FindAsync(Id);
            Rider rider = new(){Id=1};

            if (rider is null)
            {
                return NotFound();
            }

            var a = _db.Riders.Remove(rider);
            int affected = await _db.SaveChangesAsync();

            if (affected == 1)
            {
                _logger.LogInformation("affected == 1");
            }
            
            return Ok(rider);
        }

        [HttpPost]
        public async Task<ActionResult<List<Rider>>?> Post([FromBody] Rider rider)
        {
            if (rider == null)
            {
                return BadRequest();
            }

            EntityEntry<Rider> addedRider = await _db.Riders.AddAsync(rider);

            int affected = await _db.SaveChangesAsync();

            if (affected == 1)
            {
                return new List<Rider>(){rider};
            }
            
            return null;
        }


    }
}
