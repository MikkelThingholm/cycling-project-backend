using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class RiderDtoExtensions
{
    public static RiderResponse ToResponseDto(this Rider riderEntity)
    {

        RiderResponse riderResponse = new(
            Id: riderEntity.Id,
            FirstName: riderEntity.FirstName,
            LastName: riderEntity.LastName,
            Slug: riderEntity.Slug,
            BirthDate: riderEntity.BirthDate,
            Nation: riderEntity.Nation.ToResponseDto(),
            Teams: [.. riderEntity.RiderTeams.Select(rt => new RiderTeamDto(
                TeamName: rt.Team.Name,
                TeamOrganizationId: rt.Team.TeamOrganizationId,
                TeamYear: rt.Team.Year,
                JoinDate: rt.JoinDate,
                LeaveDate: rt.LeaveDate
            ))]
        );
        return riderResponse;
    }

    public static RiderSimpleResponse ToSimpleResponseDto(this Rider riderEntity)
    {
        return new RiderSimpleResponse(
            Id: riderEntity.Id,
            FirstName: riderEntity.FirstName,
            LastName: riderEntity.LastName,
            Slug: riderEntity.Slug,
            BirthDate: riderEntity.BirthDate,
            NationId: riderEntity.NationId
        );
    }


    public static Rider ToEntity(this RiderCreateRequest riderCreateRequest)
    {
        return new Rider()
        {
            FirstName = riderCreateRequest.FirstName,
            LastName = riderCreateRequest.LastName,
            Slug = riderCreateRequest.Slug,
            NationId = riderCreateRequest.NationId,
            BirthDate = riderCreateRequest.BirthDate
        };
    }

    public static void UpdateFromDto(this Rider riderEntity, RiderUpdateRequest riderUpdateRequest)
    {
        riderEntity.FirstName = riderUpdateRequest.FirstName;
        riderEntity.LastName = riderUpdateRequest.LastName;
        riderEntity.Slug = riderUpdateRequest.Slug;
        riderEntity.NationId = riderUpdateRequest.NationId;
        riderEntity.BirthDate = riderUpdateRequest.BirthDate;
    }

}

