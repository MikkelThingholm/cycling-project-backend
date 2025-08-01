using App.Data;
using App.Services.Interfaces;
using App.Dto;
using App.Extensions;
using App.Exceptions;
using App.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class RiderTeamService(ILogger<RiderTeamService> logger, AppDbContext db) : IRiderTeamService
{
    private readonly ILogger<RiderTeamService> _logger = logger;
    private readonly AppDbContext _db = db;

    // TeamOrganizations

    public async Task<TeamOrganizationSimpleResponse> CreateTeamOrganization()
    {
        var teamOrganization = new TeamOrganization { };

        _db.TeamOrganizations.Add(teamOrganization);
        await _db.SaveChangesAsync();
        return teamOrganization.ToSimpleResponseDto();
    }

    public async Task RemoveTeamOrganization(int id)
    {
        var teamOrganization = await _db.TeamOrganizations.FindAsync(id)
            ?? throw new EntityNotFoundException(nameof(TeamOrganization), id);

        _db.TeamOrganizations.Remove(teamOrganization);
        await _db.SaveChangesAsync();
    }

    public async Task<List<TeamOrganizationResponse>> GetAllTeamOrganizations()
    {
        var teamOrganizations = await _db.TeamOrganizations
            .Include(to => to.Teams)
            .ToListAsync();

        return [.. teamOrganizations.Select(to => to.ToResponseDto())];
    }


    // Teams

    public async Task<TeamSimpleResponse> CreateTeam(TeamCreateRequest teamCreateRequest)
    {
        var team = teamCreateRequest.ToEntity();

        _db.Teams.Add(team);
        await _db.SaveChangesAsync();
        return team.ToSimpleResponseDto();
    }

    public async Task RemoveTeam(int teamId)
    {
        var team = await _db.Teams.FindAsync(teamId)
            ?? throw new EntityNotFoundException(nameof(Team), teamId);

        _db.Teams.Remove(team);
        await _db.SaveChangesAsync();
    }

    public async Task<TeamSimpleResponse> UpdateTeam(int teamId, TeamUpdateRequest teamUpdateRequest)
    {
        var team = await _db.Teams.FindAsync(teamId)
                    ?? throw new EntityNotFoundException(nameof(Team), teamId);


        team.UpdateFromDto(teamUpdateRequest);
        _db.Teams.Update(team);
        await _db.SaveChangesAsync();
        return team.ToSimpleResponseDto();
    }

    public async Task<TeamResponse> GetTeamById(int teamId)
    {
        var team = await _db.Teams
            .Include(t => t.RiderTeams)
            .ThenInclude(rt => rt.Rider)
            .Include(t => t.TeamOrganization)
            .SingleOrDefaultAsync(t => t.Id == teamId)
            ?? throw new EntityNotFoundException(nameof(Team), teamId);

        return team.ToResponseDto();
    }

    // Riders

    public async Task<RiderSimpleResponse> CreateRider(RiderCreateRequest riderCreateRequest)
    {
        var rider = riderCreateRequest.ToEntity();

        _db.Riders.Add(rider);
        await _db.SaveChangesAsync();
        return rider.ToSimpleResponseDto();
    }

    public async Task RemoveRider(int riderId)
    {
        var rider = await _db.Riders.FindAsync(riderId)
            ?? throw new EntityNotFoundException(nameof(Rider), riderId);

        _db.Riders.Remove(rider);
        await _db.SaveChangesAsync();
    }

    public async Task<RiderSimpleResponse> UpdateRider(int riderId, RiderUpdateRequest riderUpdateRequest)
    {
        var rider = await _db.Riders.FindAsync(riderId)
            ?? throw new EntityNotFoundException(nameof(Rider), riderId);

        rider.UpdateFromDto(riderUpdateRequest);
        _db.Riders.Update(rider);
        await _db.SaveChangesAsync();
        return rider.ToSimpleResponseDto();
    }

    public async Task<RiderResponse> GetRiderById(int riderId)
    {
        var rider = await _db.Riders
            .Include(r => r.RiderTeams)
            .ThenInclude(rt => rt.Team)
            .Include(r => r.Nation)
            .SingleOrDefaultAsync(r => r.Id == riderId)
            ?? throw new EntityNotFoundException(nameof(Rider), riderId);

        return rider.ToResponseDto();
    }

    //RiderTeams

    public async Task<RiderTeamSimpleResponse> AssignRiderToTeam(int riderId, int teamId, RiderTeamCreateRequest riderTeamCreateRequest)
    {
        var riderTeam = riderTeamCreateRequest.ToEntity(riderId, teamId);

        var team = await _db.Teams.FindAsync(riderTeam.TeamId)
            ?? throw new EntityNotFoundException(nameof(Team), riderTeam.TeamId);

        if (!(riderTeam.JoinDate.Year == team.Year && riderTeam.LeaveDate.Year == team.Year))
        {
            throw new BusinessRuleViolationException($"RiderTeam dates must be within the team's year {team.Year}");
        }

        _db.RiderTeams.Add(riderTeam);
        await _db.SaveChangesAsync();
        return riderTeam.ToSimpleResponseDto();
    }

    public async Task RemoveRiderFromTeam(int riderId, int teamId)
    {
        var riderTeam = await _db.RiderTeams.SingleOrDefaultAsync(rt => rt.RiderId == riderId && rt.TeamId == teamId)
            ?? throw new EntityNotFoundException(nameof(RiderTeam), new { RiderId = riderId, TeamId = teamId });

        _db.RiderTeams.Remove(riderTeam);
        await _db.SaveChangesAsync();
    }

    public async Task<RiderTeamSimpleResponse> UpdateRiderTeamAssignment(int riderId, int teamId, RiderTeamUpdateRequest riderTeamUpdateRequest)
    {
        var riderTeam = await _db.RiderTeams.Include(rt => rt.Team)
                                            .SingleOrDefaultAsync(rt => rt.RiderId == riderId && rt.TeamId == teamId)
                    ?? throw new EntityNotFoundException(nameof(RiderTeam), new { RiderId = riderId, TeamId = teamId });

        if (!(riderTeamUpdateRequest.JoinDate.Year == riderTeam.Team.Year &&
              riderTeamUpdateRequest.LeaveDate.Year == riderTeam.Team.Year))
        {
            throw new BusinessRuleViolationException($"RiderTeam dates must be within the team's year {riderTeam.Team.Year}");
        }

        var riderRaceParticipations = await _db.RaceRiderParticipations
                                              .Include(rrp => rrp.RaceTeamParticipation)
                                                 .ThenInclude(rtp => rtp.RaceEdition)
                                              .Where(rrp => rrp.RiderId == riderId && rrp.RaceTeamParticipation.TeamId == teamId)
                                              .ToListAsync();

        if (!riderRaceParticipations.All(rrp => riderTeamUpdateRequest.JoinDate <= rrp.RaceTeamParticipation.RaceEdition.StartDate && rrp.RaceTeamParticipation.RaceEdition.EndDate <= riderTeamUpdateRequest.LeaveDate))
        {
            throw new BusinessRuleViolationException("New rider team join leave dates conflict with race participations");
        }

        riderTeam.UpdateFromDto(riderTeamUpdateRequest);
        _db.RiderTeams.Update(riderTeam);
        await _db.SaveChangesAsync();
        return riderTeam.ToSimpleResponseDto();
    }

}