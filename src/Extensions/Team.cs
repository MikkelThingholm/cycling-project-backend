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
            Slug: team.Slug,
            RiderTeams: [.. team.RiderTeams.Select(rt => rt.ToResponseDto())],
            TeamOrganization: team.TeamOrganization.ToResponseDto()
        );
    }

    public static TeamSimpleResponse ToSimpleResponseDto(this Team team)
    {
        return new TeamSimpleResponse(
            Id: team.Id,
            Name: team.Name,
            Slug: team.Slug,
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
            Slug = request.Slug,
            TeamOrganizationId = request.TeamOrganizationId
        };
    }

    public static void UpdateFromDto(this Team team, TeamUpdateRequest request)
    {
        team.Name = request.Name;
        team.Slug = request.Slug;
        team.TeamOrganizationId = request.TeamOrganizationId;
    }

}