using App.Data;
using App.Services.Interfaces;
using App.Dto;
using App.Extensions;
using App.Exceptions;
using App.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class RiderTeamService(ILogger<RiderTeamService> logger, AppDbContext db)
{
    private readonly ILogger<RiderTeamService> _logger = logger;
    private readonly AppDbContext _db = db;

    // TeamOrganizations

    public async Task<TeamOrganizationSimpleResponse> CreateTeamOrganization(int id)
    {
        var teamOrganization = new TeamOrganization
        {
            Id = id,
        };

        _db.TeamOrganizations.Add(teamOrganization);
        await _db.SaveChangesAsync();
        return teamOrganization.ToSimpleResponseDto();
    }

    public async void DeleteTeamOrganization(int id)
    {
        var teamOrganization = await _db.TeamOrganizations.FindAsync(id)
            ?? throw new EntityNotFoundException(nameof(TeamOrganization), id);

        _db.TeamOrganizations.Remove(teamOrganization);
        await _db.SaveChangesAsync();
    }


    // Teams

    public async Task<TeamSimpleResponse> CreateTeam(TeamCreateRequest teamCreateRequest)
    {
        var team = teamCreateRequest.ToEntity();

        _db.Teams.Add(team);
        await _db.SaveChangesAsync();
        return team.ToSimpleResponseDto();
    }

    public async void DeleteTeam(int teamId)
    {
        var team = await _db.Teams.FindAsync(teamId)
            ?? throw new EntityNotFoundException(nameof(Team), teamId);

        _db.Teams.Remove(team);
        await _db.SaveChangesAsync();
    }


    // Riders

    public async Task<RiderSimpleResponse> CreateRider(RiderCreateRequest riderCreateRequest)
    {
        var rider = riderCreateRequest.ToEntity();

        _db.Riders.Add(rider);
        await _db.SaveChangesAsync();
        return rider.ToSimpleResponseDto();
    }

    public async void DeleteRider(int riderId)
    {
        var rider = await _db.Riders.FindAsync(riderId)
            ?? throw new EntityNotFoundException(nameof(Rider), riderId);

        _db.Riders.Remove(rider);
        await _db.SaveChangesAsync();
    }

    //RiderTeams

    public async Task<RiderTeamSimpleResponse> CreateRiderTeam(RiderTeamCreateRequest riderTeamCreateRequest)
    {
        var riderTeam = riderTeamCreateRequest.ToEntity();

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

    public async void DeleteRiderTeam(int riderTeamId)
    {
        var riderTeam = await _db.RiderTeams.FindAsync(riderTeamId)
            ?? throw new EntityNotFoundException(nameof(RiderTeam), riderTeamId);

        _db.RiderTeams.Remove(riderTeam);
        await _db.SaveChangesAsync();
    }

}