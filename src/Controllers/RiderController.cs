using App.EntityModels;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using App.Dto;
using App.Extenstions;

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
        public async Task<ActionResult<RiderResponse>> Get(int Id)
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
        public async Task<ActionResult<RiderResponse>> Delete(int Id)
        {
            //Rider? rider = await _db.Riders.FindAsync(Id);
            Rider rider = new(){Id=Id};

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
            
            return Ok(rider.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult<List<RiderResponse>>?> Post([FromBody] List<RiderCreateRequest> riderCreateRequests)
        {

            if (riderCreateRequests == null)
            {
                return BadRequest();
            }

            List<Rider> riders = riderCreateRequests.Select(i => i.ToEntity()).ToList();
    
            await _db.Riders.AddRangeAsync(riders);
  
            int affected = await _db.SaveChangesAsync();

            List<RiderResponse> ridersReturn = riders.Select(i => i.ToDto()).ToList();

            return Ok(ridersReturn);
        }

        [HttpPatch]
        public async Task<ActionResult<RiderResponse>?> Patch([FromBody] List<RiderUpdateRequest> riderUpdateRequests)
        {
            if (riderUpdateRequests == null)
            {
                return BadRequest();
            }

            List<Rider> riders = riderUpdateRequests.Select(i => i.ToEntity()).ToList();

            foreach (var rider in riders)
            {
                await _db.Riders.Update(rider);
            }

            await _db.Riders.UpdateRange(riders);

            int affected = await _db.SaveChangesAsync();


            
            return null;
        }

    }
}
