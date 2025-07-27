using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class TeamDtoExtensions
{
    public static TeamResponse ToResponseDto(this Team team)
    {
        return new TeamResponse(
            Id: team.Id,
            Name: team.Name,
            Year: team.Year,
            RiderTeams: [.. team.RiderTeams.Select(rt => rt.ToResponseDto())],
            TeamOrganization: team.TeamOrganization.ToResponseDto()
        );
    }

    public static TeamSimpleResponse ToSimpleResponseDto(this Team team)
    {
        return new TeamSimpleResponse(
            Id: team.Id,
            Name: team.Name,
            Year: team.Year,
            TeamOrganizationId: team.TeamOrganizationId
        );
    }

    public static Team ToEntity(this TeamCreateRequest request)
    {
        return new Team
        {
            Name = request.Name,
            Year = request.Year,
            TeamOrganizationId = request.TeamOrganizationId
        };
    }

    public static void UpdateFromDto(this Team team, TeamUpdateRequest request)
    {
        team.Name = request.Name;
        team.Year = request.Year;
        team.TeamOrganizationId = request.TeamOrganizationId;
    }

}