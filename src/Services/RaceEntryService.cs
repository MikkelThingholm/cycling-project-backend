using App.EntityModels;
using App.Data;
using App.Dto;
using App.Exceptions;
using App.Services.Interfaces;
using App.Extensions;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class RaceEntryService(ILogger<RaceEntryService> logger, AppDbContext db) : IRaceEntryService
{
    private readonly ILogger<RaceEntryService> _logger = logger;
    private readonly AppDbContext _db = db;

    public async Task TeamRaceEntry(int teamId, int raceEditionId)
    {
        var raceEdition = await _db.RaceEditions.FindAsync(raceEditionId) ?? throw new EntityNotFoundException(nameof(RaceEdition), raceEditionId);

        var team = await _db.Teams.FindAsync(teamId) ?? throw new EntityNotFoundException(nameof(Team), teamId);


        if (raceEdition.StartDate.Year != team.Year)
        {
            throw new BusinessRuleViolationException($"Team {team.Name} cannot participate");
        }

        var raceTeamParticipation = new RaceTeamParticipation
        {
            RaceEditionId = raceEditionId,
            TeamId = teamId,
        };

        await _db.RaceTeamParticipations.AddAsync(raceTeamParticipation);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteTeamRaceEntry(int teamId, int raceEditionId)
    {
        var raceTeamParticipation = await _db.RaceTeamParticipations
            .SingleOrDefaultAsync(rtp => rtp.TeamId == teamId && rtp.RaceEditionId == raceEditionId)
            ?? throw new EntityNotFoundException(nameof(RaceTeamParticipation), $"Team {teamId} not participating in race edition {raceEditionId}");

        _db.RaceTeamParticipations.Remove(raceTeamParticipation);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new EntityNotFoundException(nameof(RaceTeamParticipation), raceTeamParticipation.Id);
        }

    }

    public async Task RiderRaceEntry(int riderId, int raceEditionId)
    {
        var raceEdition = await _db.RaceEditions.FindAsync(raceEditionId) ?? throw new EntityNotFoundException(nameof(RaceEdition), raceEditionId);

        var rider = await _db.Riders.FindAsync(riderId) ?? throw new EntityNotFoundException(nameof(Rider), riderId);


        var riderTeamAtRace = await _db.RiderTeams.SingleOrDefaultAsync(rt => rt.RiderId == riderId && rt.JoinDate <= raceEdition.StartDate && raceEdition.EndDate <= rt.LeaveDate)
                             ?? throw new BusinessRuleViolationException($"Rider {rider.FirstName} {rider.LastName} is not part of a team during the race edition start and end dates");

        var raceTeamParticipation = await _db.RaceTeamParticipations.SingleOrDefaultAsync(rtp => rtp.RaceEditionId == raceEditionId && rtp.TeamId == riderTeamAtRace.TeamId)
                                   ?? throw new BusinessRuleViolationException($"Rider {rider.FirstName} {rider.LastName}'s team is not participating in race edition {raceEdition.Name}");

        var raceRiderParticipation = new RaceRiderParticipation
        {
            RiderId = riderId,
            RaceTeamParticipationId = raceTeamParticipation.Id,
        };

        await _db.RaceRiderParticipations.AddAsync(raceRiderParticipation);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteRiderRaceEntry(int riderId, int raceEditionId)
    {
        var raceRiderParticipation = await _db.RaceRiderParticipations
            .SingleOrDefaultAsync(rrp => rrp.RiderId == riderId && rrp.RaceTeamParticipation.RaceEditionId == raceEditionId)
            ?? throw new EntityNotFoundException(nameof(RaceRiderParticipation), $"Rider {riderId} not participating in race edition {raceEditionId}");


        _db.RaceRiderParticipations.Remove(raceRiderParticipation);
        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new EntityNotFoundException(nameof(RaceRiderParticipation), raceRiderParticipation.Id);
        }
    }
}