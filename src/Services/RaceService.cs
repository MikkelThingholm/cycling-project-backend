using App.Data;
using App.Services.Interfaces;
using App.Dto;
using App.Extensions;
using App.Exceptions;
using App.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class RaceService(ILogger<RaceService> logger, AppDbContext db) : IRaceService
{
    private readonly ILogger<RaceService> _logger = logger;
    private readonly AppDbContext _db = db;

    public async Task<RaceSimpleResponse> AddRace(RaceCreateRequest raceCreateRequest)
    {
        var race = raceCreateRequest.ToEntity();
        await _db.Races.AddAsync(race);
        await _db.SaveChangesAsync();
        return race.ToSimpleResponseDto();
    }

    public async Task<RaceResponse> GetRaceById(int raceId)
    {
        var race = await _db.Races.Include(r => r.Nation)
                                  .Include(r => r.RaceEditions)
                                    .ThenInclude(re => re.Stages)
                                  .SingleOrDefaultAsync(r => r.Id == raceId)
                                  ?? throw new EntityNotFoundException(nameof(Race), raceId);

        return race.ToResponseDto();
    }

    public async Task<RaceSimpleResponse> UpdateRace(int raceId, RaceUpdateRequest raceUpdateRequest)
    {
        var race = await _db.Races.FindAsync(raceId) ?? throw new EntityNotFoundException(nameof(Race), raceId);

        race.UpdateFromDto(raceUpdateRequest);
        await _db.SaveChangesAsync();
        return race.ToSimpleResponseDto();
    }

    public async Task DeleteRace(int raceId)
    {
        var race = new Race { Id = raceId };
        _db.Races.Remove(race);
        await _db.SaveChangesAsync();
    }
}