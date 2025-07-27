using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class TeamOrganizationDtoExtensions
{
    public static TeamOrganizationResponse ToResponseDto(this TeamOrganization teamOrganization)
    {
        return new TeamOrganizationResponse(
            Id: teamOrganization.Id,
            Teams: [.. teamOrganization.Teams.Select(t => t.ToResponseDto())]
        );
    }

    public static TeamOrganizationSimpleResponse ToSimpleResponseDto(this TeamOrganization teamOrganization)
    {
        return new TeamOrganizationSimpleResponse(
            Id: teamOrganization.Id
        );
    }

}