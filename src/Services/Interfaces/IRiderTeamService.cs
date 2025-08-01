using App.Dto;

namespace App.Services.Interfaces;

public interface IRiderTeamService
{
    // TeamOrganizations
    Task<TeamOrganizationSimpleResponse> CreateTeamOrganization();
    Task RemoveTeamOrganization(int id);
    Task<List<TeamOrganizationResponse>> GetAllTeamOrganizations();

    // Teams
    Task<TeamSimpleResponse> CreateTeam(TeamCreateRequest teamCreateRequest);
    Task RemoveTeam(int teamId);
    Task<TeamResponse> GetTeamById(int teamId);
    Task<TeamSimpleResponse> UpdateTeam(int teamId, TeamUpdateRequest teamUpdateRequest);

    // Riders
    Task<RiderSimpleResponse> CreateRider(RiderCreateRequest riderCreateRequest);
    Task RemoveRider(int riderId);
    Task<RiderResponse> GetRiderById(int riderId);
    Task<RiderSimpleResponse> UpdateRider(int riderId, RiderUpdateRequest riderUpdateRequest);

    // RiderTeams
    Task<RiderTeamSimpleResponse> AssignRiderToTeam(int riderId, int teamId, RiderTeamCreateRequest riderTeamCreateRequest);
    Task RemoveRiderFromTeam(int riderId, int teamId);
    Task<RiderTeamSimpleResponse> UpdateRiderTeamAssignment(int riderId, int teamId, RiderTeamUpdateRequest riderTeamUpdateRequest);

}